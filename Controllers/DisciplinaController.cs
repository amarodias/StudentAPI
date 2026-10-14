using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentAPI.Models;
using StudentAPI.Context;
using Microsoft.EntityFrameworkCore;

namespace StudentAPI.Controllers;
    [Route("api/[controller]")]
    [ApiController]
    public class DisciplinaController : ControllerBase
    {
        private readonly AppDbContext _context;
        public DisciplinaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Disciplina>>> Get()
        {
            var subjects =  await _context.Disciplinas.ToListAsync();
            if(!subjects.Any())
            return NotFound("Disciplinas não encontradas.");
            return Ok(subjects);
        }

        [HttpGet("{id:int}", Name ="ObterDisciplina")]
        public async Task<ActionResult<Disciplina>> Get (int id)
        {
 
        var subject = await _context.Disciplinas.FirstOrDefaultAsync(disciplina => disciplina.Id == id ); 
        if(subject is null)
        return NotFound("Disciplina não encontrada");
        return Ok(subject);
       
        }

        [HttpPost]
        public async Task<ActionResult> Post (Disciplina subject)
        {
          if(subject is null) 
             return BadRequest("Péssima requisição\n");
             await _context.Disciplinas.AddAsync(subject);
             await _context.SaveChangesAsync();
             return new CreatedAtRouteResult("ObterDisciplina", new {id = subject.Id }, subject);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put (int id, Disciplina subject)
    {
        if(subject.Id!=id)
        return BadRequest("Id não identificado");
       
        var sub = await _context.Disciplinas.AnyAsync(sub => sub.Id == id);

        if(!sub)
        return NotFound("Disciplina não encontrada");

        //Autoriza a atualização de dados
        _context.Entry(subject).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return Ok(subject);
    }


    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete (int id)

    {
        var subject = await _context.Disciplinas.FirstOrDefaultAsync(disciplina => disciplina.Id==id);
       
        if(subject is null) return NotFound("Não encontrado");

        _context.Disciplinas.Remove(subject);
        await _context.SaveChangesAsync();

        return Ok("Disciplina eliminada");
        
    }


    }

