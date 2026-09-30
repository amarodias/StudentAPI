using System;
using System.Collections.Generic;
namespace StudentAPI.Models;

public class Estudante
{
public int Id { get; set; }
public string? Nome { get; set; }
public string? Email { get; set; } //Email institucional
public string? Telefone { get; set; }
public int CursoId { get; set; }
public Curso? Course { get; set; } //Variável de navegação para a entidade de domínioCurso
ICollection<Matricula>? Matriculas { get; set; } = new List<Matricula>();

}
