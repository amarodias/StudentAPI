using System;
using Microsoft.EntityFrameworkCore;
using StudentAPI.Context;
using StudentAPI.Models;

namespace StudentAPI.Services;

public class DisciplinaService : IDisciplinaService
{

private readonly AppDbContext _context;
public DisciplinaService(AppDbContext context)
    {
        _context = context;
    }

public async Task <IEnumerable<Disciplina>> ListarDisciplinaAsync()
    {
       return await _context.Disciplinas.ToListAsync();
    }
public async Task <Disciplina?> ObterPeloIdAsync (int id)
    {
        return await _context.Disciplinas.FirstOrDefaultAsync(disciplina => disciplina.Id == id);
    }  
public async Task <Disciplina?> CriarAsync (Disciplina disciplina)
    {
        await _context.Disciplinas.AddAsync(disciplina);
        await _context.SaveChangesAsync();
        return disciplina;   
    } 
    
public async Task <Disciplina?> AtualizarAsync (int id, Disciplina disciplina)
    {
        if (id!=disciplina.Id) return null;
        _context.Entry(disciplina).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return disciplina;   
    } 
public async Task <bool> DeletarAsync(int id)
    {
        var disciplina = _context.Disciplinas.FindAsync(id);
        _context.Remove(disciplina);
        await _context.SaveChangesAsync();
        return true;

    }       
}
