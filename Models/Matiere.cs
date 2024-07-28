using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading;

[Table("matiere")]
public class Matiere
{
    [Key]
    [Column("id")]
    public string? Id { get; set; }

    [Column("id_semestre")]
    public string? IdSemestre { get; set; }

    [Column("nom")]
    public string? Nom { get; set; }

    [Column("code")]
    public string? Code { get; set; }

    [Column("credit")]
    public int? Credit { get; set; }

    [Column("optionnelle")]
    public string? Optionnelle { get; set; }

}
