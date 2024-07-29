using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Transactions;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Npgsql;

public class Import
{
 private readonly ApplicationDbContext _dbContext;

    public Import(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void ImportCsvToDatabase<T>(string table,IFormFile file, Func<CsvReader, T> mapFunc, CsvConfiguration? csvConfig = null) where T : class
    {
        if (file == null || file.Length == 0)
        {
            throw new ArgumentException("Le fichier est vide ou n'existe pas.");
        }

        if (csvConfig == null)
        {
            csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ",",
                BadDataFound = null,
                MissingFieldFound = null
            };
        }

        using (var reader = new StreamReader(file.OpenReadStream(), Encoding.UTF8))
        using (var csv = new CsvReader(reader, csvConfig))
        {
            csv.Read();
            csv.ReadHeader();

            var entities = new List<T>();

            while (csv.Read())
            {
                var entity = mapFunc(csv);
                entities.Add(entity);
            }

            // Bulk insert using raw SQL
            foreach (var entity in entities)
            {
                var sql = GetInsertSql<T>(table);
                var parameters = GetSqlParameters<T>(entity);
                _dbContext.Database.ExecuteSqlRaw(sql, parameters);
            }
        }
    }

    private string GetInsertSql<T>(string table)
    {
        var tableName = table; // Assume que le nom de la classe correspond au nom de la table
        var properties = typeof(T).GetProperties();
        var valueParams = string.Join(", ", properties.Select(p => $"@{p.Name.ToLower()}"));
        return $"INSERT INTO {tableName} VALUES ({valueParams})";
    }

    private NpgsqlParameter[] GetSqlParameters<T>(T entity)
    {
        var properties = typeof(T).GetProperties();
        var parameters = new List<NpgsqlParameter>();
        foreach (var property in properties)
        {
            parameters.Add(new NpgsqlParameter($"@{property.Name.ToLower()}", property.GetValue(entity) ?? DBNull.Value));
        }

        return parameters.ToArray();
    }
    
    public void InsertDataNote()
    {
        using (var transaction = _dbContext.Database.BeginTransaction())
        {
            try
            {
                // promotion
                _dbContext.Database.ExecuteSqlRaw(@"
                    INSERT INTO promotion(nom) 
                    SELECT DISTINCT promotion
                    FROM note_temporaire");

                //genre
                _dbContext.Database.ExecuteSqlRaw(@"
                    INSERT INTO genre(nom) 
                    SELECT DISTINCT genre
                    FROM note_temporaire");

                // semestre
                _dbContext.Database.ExecuteSqlRaw(@"
                    INSERT INTO semestre(nom) 
                    SELECT DISTINCT semestre
                    FROM note_temporaire");

               

                //matiere                   
                _dbContext.Database.ExecuteSqlRaw(@"
                    INSERT INTO matiere (id_semestre,code)
                    SELECT 
                        sm.id as id_semestre,
                        nt.codematiere
                    FROM 
                        note_temporaire nt
                    JOIN 
                        semestre sm ON nt.semestre = sm.nom"
                );

                //etudiant
                _dbContext.Database.ExecuteSqlRaw(@"
                    INSERT INTO etudiant (id_promotion, id_genre, num_etu, nom, prenom, date_de_naissance)
                    SELECT
                        pr.id AS id_promotion,
                        gr.id AS id_genre,
                        nt.numetu AS etu,
                        nt.nom AS nom,
                        nt.prenom AS prenom,
                        nt.datedenaissance AS dtn
                    FROM 
                        (SELECT DISTINCT ON (numetu) *
                         FROM note_temporaire
                         ORDER BY numetu) AS nt
                    JOIN 
                        promotion pr ON nt.promotion = pr.nom
                    JOIN 
                        genre gr ON gr.nom = nt.genre
                    "
                );

                //note
                _dbContext.Database.ExecuteSqlRaw(@"
                    INSERT INTO note (id_etudiant, id_matiere, note)
                        SELECT 
                            et.id AS id_etudiant,
                            mt.id AS id_matiere,
                            nt.note
                        FROM 
                            note_temporaire nt
                        JOIN 
                            etudiant et ON nt.numetu = et.num_etu
                        JOIN 
                            matiere mt ON mt.code = nt.codematiere"
                );
    
                transaction.Commit(); // Commit la transaction
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                Console.WriteLine("Une erreur s'est produite lors de l'insertion des données : " + ex.Message);
                // La transaction sera rollback automatiquement car Commit() n'a pas été appelé
            }
        }
    }
    
}
