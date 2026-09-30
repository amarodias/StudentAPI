using StudentAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace StudentAPI.Context;

public class AppDbContext : DbContext
{

public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
{}
public DbSet<Curso> Cursos { get; set;}
public DbSet<Matricula> Matriculas { get; set;}
public DbSet<Disciplina> Disciplinas { get; set;}
public DbSet<Estudante> Estudantes { get; set;}
}