using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentAPI.Context;
using StudentAPI.Models;

namespace StudentAPI.Controllers;

    [Route("api/[controller]")] //Gera a rota /api/matricula
    [ApiController]
    public class MatriculaController : ControllerBase
    {
            private readonly AppDbContext _context; 
        
        public MatriculaController(AppDbContext context)
        {
        _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Matricula>>> Get()
        {
            return await _context.Matriculas.ToListAsync();
        }


        [HttpGet("{id:int}", Name = "ObterMatricula")]
        public async Task<ActionResult<Matricula>> Get(int id)
        {
           var matricula = await _context.Matriculas.FirstOrDefaultAsync(matricula => matricula.Id == id);
           if(matricula is null) return NotFound("A matrícula não existe");
           return Ok(matricula);

        }
    [HttpPost]
    public async Task<ActionResult> Post (Matricula matricula)
        {
            if(matricula is null) return BadRequest();
            await _context.Matriculas.AddAsync(matricula);
            await _context.SaveChangesAsync();
            return new CreatedAtRouteResult("ObterMatricula", new {id = matricula.Id}, matricula);
        
        }

     [HttpPut("{id:int}")]
     public async Task<ActionResult> Put (Matricula matricula, int id)
    {
        if(id == matricula.Id)
        if(matricula is null) return BadRequest("Dados inválidados");
        
        _context.Matriculas.Entry(matricula).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        await _context.SaveChangesAsync();
        return Ok(matricula);
     }  

    [HttpDelete("{id:int}")] 
    public async Task <ActionResult> Delete (int id)
    {
        var matricula = _context.Matriculas.FirstOrDefault(matricula => matricula.Id == id);
        if(matricula is null) return NotFound("Matrícula não encontrada");
        _context.Matriculas.Remove(matricula);
        await _context.SaveChangesAsync();
        return Ok("Matrícula eliminada");
    }
    }

