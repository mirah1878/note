using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading;

[Table("etudiant")]
public class Etudiant
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

}
