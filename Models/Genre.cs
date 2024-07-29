using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("genre")]
public class Genre
{
    [Key]
    [Column("id")]
    public string? Id { get; set; }

    [Column("nom")]
    [Required]
    public string? Nom { get; set; }
}
