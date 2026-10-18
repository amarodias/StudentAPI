using System;
using Microsoft.EntityFrameworkCore;
using StudentAPI.Context;
using StudentAPI.Models;
namespace StudentAPI.Services;

public class CursoService : ICursoService
{
    private readonly AppDbContext _context;

    public CursoService(AppDbContext context)
    {
     _context = context;
    }
public async Task <IEnumerable<Curso>> ListarCursosAsync()
    {
      return await _context.Cursos.ToListAsync(); 

    }
public async Task <Curso?> ObterCursoPeloIdAsync(int id)
    {
        return await _context.Cursos.FirstOrDefaultAsync(c => c.Id == id);
    }   
public async Task <Curso?> CriarAsync(Curso curso)
    {
        await _context.Cursos.AddAsync(curso);
        await _context.SaveChangesAsync();
        return curso;
    }    
public async Task <Curso?> AtualizarAsync(int id, Curso curso)
    {
        if(id != curso.Id) return null;
        _context.Entry(curso).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return curso;
    }    
public async Task <bool> EliminarAsync (int id)
{
    var curso = await _context.Cursos.FirstOrDefaultAsync(e=> e.Id == id);
    if(curso is null) return false;
   _context.Remove(curso);
    await _context.SaveChangesAsync();
    return true;    
}   
}
