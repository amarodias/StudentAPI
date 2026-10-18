using System;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using StudentAPI.Context;
using StudentAPI.Models;

namespace StudentAPI.Services;

public class MatriculaService : IMatriculaService
{
    private readonly AppDbContext _context;
public MatriculaService(AppDbContext context)
    {
        _context = context;
    }

public async Task <IEnumerable<Matricula>> ListarMatriculaAsync()
    {
       var matriculas = await _context.Matriculas.ToListAsync();
       return matriculas;

    }
public async Task <Matricula?> ObterPeloIdAsync(int id)
    {
        var matricula = await _context.Matriculas.FindAsync(id);
        return matricula;
    }    
public async Task <Matricula?> CriarAsync(Matricula matricula)
    {
        await _context.Matriculas.AddAsync(matricula);
        await _context.SaveChangesAsync();

        return matricula;
    }    
public async Task <Matricula?> AtualizarAsync(int id, Matricula matricula)
    {
        if(id!=matricula.Id) return null;
         _context.Entry(matricula).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
         await _context.SaveChangesAsync();
         return matricula; 
    }
public async Task <bool> DeletarAsync(int id)
    {
        var matricula = await _context.Matriculas.FindAsync(id);
        if(matricula is null) return false;
        _context.Matriculas.Remove(matricula);
        return true;
    }    
}
