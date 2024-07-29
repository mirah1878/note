using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using CsvHelper;

[Table("note_temporaire")]
public class NoteTemporaire
{
    [Column("numetu")]
    public string? NumEtu { get; set; }

    [Column("nom")]
    public string? Nom { get; set; }

    [Column("prenom")]
    public string? Prenom { get; set; }

    [Column("genre")]
    public string? Genre { get; set; }

    [Column("datedenaissance")]
    public DateTime DateDeNaissance { get; set; }

    [Column("promotion")]
    public string? Promotion { get; set; }

    [Column("codematiere")]
    public string? CodeMatiere { get; set; }

    [Column("semestre")]
    public string? Semestre { get; set; }

    [Column("note")]
    public double? Note { get; set; }

    public static NoteTemporaire MapNoteTemporaire(CsvReader csv)
    {
        return new NoteTemporaire
        {
            NumEtu = csv.GetField<string>("NumETU"),
            Nom = csv.GetField<string>("Nom"),
            Prenom = csv.GetField<string>("Prénom"),
            Genre = csv.GetField<string>("Genre"),
            DateDeNaissance = Contrainte.ParseDate(csv.GetField<string>("DateNaissance")),
            Promotion = csv.GetField<string>("Promotion"),
            CodeMatiere = csv.GetField<string>("CodeMatiere"),
            Semestre = csv.GetField<string>("Semestre"),
            Note = csv.GetField<double>("Note")
        };
    }
}
