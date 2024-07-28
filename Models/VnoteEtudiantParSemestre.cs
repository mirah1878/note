using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("v_notes_etudiants_par_semestre")]
public class VnoteEtudiantParSemestre
{
    [Key]
    [Column("id")]
    public string? Id { get; set; }

    [Column("id_promotion")]
    public string? IdPromotion { get; set; }

    [Column("num_etu")]
    public string? NumEtu { get; set; }

    [Column("nom")]
    public string? Nom { get; set; }

    [Column("prenom")]
    public string? Prenom { get; set; }

    [Column("date_de_naissance")]
    public DateTime? DateDeNaissance { get; set; }

    [Column("nom_promotion")]
    public string? NomPromotion { get; set; }

    [Column("id_semestre")]
    public string? IdSemestre { get; set; }

    [Column("nom_semestre")]
    public string? NomSemestre { get; set; }

    [Column("id_matiere")]
    public string? IdMatiere { get; set; }

    [Column("nom_matiere")]
    public string? NomMatiere { get; set; }

    [Column("code_matiere")]
    public string? CodeMatiere { get; set; }

    [Column("credit_matiere")]
    public int? CreditMatiere { get; set; }

    [Column("optionnelle")]
    public string? Optionnelle { get; set; }

    [Column("note")]
    public double? Note { get; set; }

    [Column("moyenne")]
    public decimal? Moyenne { get; set; }

    [Column("etat")]
    public int? Etat { get; set; }
}
