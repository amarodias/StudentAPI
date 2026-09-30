using System;

namespace StudentAPI.Models;

public class Matricula
{
    public int Id { get; set;}
public bool? Estado { get; set; }
public int EstudanteId { get; set; } 
public Estudante? Estudante { get; set; }
 public int DisciplinaId { get; set; } 
 public Disciplina? Discipline { get; set; }
}
