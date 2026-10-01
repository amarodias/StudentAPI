using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace StudentAPI.Models;

public class Estudante
{
    [ Key ]
public int Id { get; set; }

[Required]
[StringLength(80)]
public string? Nome { get; set; }

[Required]
[StringLength(40)]
public string? Email { get; set; } //Email institucional

[Required]
[StringLength(9)]
public string? Telefone { get; set; }

[ForeignKey("CursoId")]
public int CursoId { get; set; }
public Curso? Course { get; set; } //Variável de navegação para a entidade de domínioCurso
ICollection<Matricula>? Matriculas { get; set; } = new List<Matricula>();

}
