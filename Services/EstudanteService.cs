using System;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using StudentAPI.Context;
using StudentAPI.Models;

namespace StudentAPI.Services;

public class EstudanteService : IEstudanteService
{
private readonly AppDbContext _context;

public EstudanteService (AppDbContext context)
    {
    _context = context;    
    }
    public async Task <IEnumerable<Estudante>> ListarTodosAsync()
    {
        return await _context.Estudantes.ToListAsync();
    }

    public async Task <Estudante?> BuscarPorIdAsync(int id)
    {
        return await _context.Estudantes.FirstOrDefaultAsync(e=> e.Id == id);
    }
    public async Task <Estudante?> CriarAsync(Estudante estudante)
    {
        await _context.Estudantes.AddAsync(estudante);
        await _context.SaveChangesAsync();
        return estudante;
    }
    public async Task <Estudante?> AtualizarAsync(int id, Estudante estudante)
    {
     if(id != estudante.Id) return null;
     _context.Entry(estudante).State = Microsoft.EntityFrameworkCore.EntityState.Modified; 
     await _context.SaveChangesAsync(); 
     return estudante;
    }

    public async Task <bool> EliminarAsync(int id)
    {
        var e = await _context.Estudantes.FirstOrDefaultAsync(e=> e.Id == id);
        if(e is null) return false;
        _context.Remove(e);
        await _context.SaveChangesAsync();
        return true;
    }

}
