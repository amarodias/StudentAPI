using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentAPI.Models;

public class Matricula
{
    [Key]
public int Id { get; set;}
public bool? Estado { get; set; }
[ForeignKey("Id")]
public int EstudanteId { get; set; } 
public Estudante? Estudante { get; set; }
 public int DisciplinaId { get; set; } 
 public Disciplina? Discipline { get; set; }
}
