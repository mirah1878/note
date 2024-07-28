using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading;

[Table("note")]
public class Note
{
    [Key]
    [Column("id")]
    public string? Id { get; set; }

    [Column("id_etudiant")]
    public string? IdEtudiant { get; set; }

    [Column("id_matiere")]
    public string? IdMatiere { get; set; }

    [Column("note")]
    public string? Notes { get; set; }

}
