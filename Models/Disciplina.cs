using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentAPI.Models;

public class Disciplina
{
    [Key]
public int Id { get; set; }

[Required]
[StringLength(80)]
public string? Nome { get; set; }

[ForeignKey("CursoId")]
public int CursoId { get; set; }

public Curso? Course { get; set; }
}
