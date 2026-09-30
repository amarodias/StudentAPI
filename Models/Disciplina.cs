using System;

namespace StudentAPI.Models;

public class Disciplina
{
public int Id { get; set; }
public string? Nome { get; set; }
public int CursoId { get; set; }
public Curso? Course { get; set; }
}
