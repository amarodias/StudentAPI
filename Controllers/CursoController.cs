using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentAPI.Context;
using StudentAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace StudentAPI.Controllers;
    [Route("api/[controller]")]
    [ApiController]
    //Métodos Actions Assíncronos para CursoController
    public class CursoController : ControllerBase{ 
        private readonly AppDbContext _context;
        public CursoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult <IEnumerable<Curso>>> Get()
        {

            //O await libera a thread enquanto enquantos o banco de dados faz consultas
            var cursos = await _context.Cursos.ToListAsync();
            if(!cursos.Any())
            return NotFound("Nenhum curso encontrado");
            return Ok(cursos);
        
        }

        //Um Id único!
        [HttpGet("{id:int}", Name = "ObterCurso")]
        public async Task<ActionResult<Curso>> Get(int id)
        {
         var curso = await _context.Cursos.FirstOrDefaultAsync(curso => curso.Id == id);
         if(curso is null)
          return NotFound("Nenhum curso encontrado");

         return Ok(curso);
        }

        [HttpPost]
        public async Task<ActionResult> Post (Curso curso)
    {
        if(curso is null) return BadRequest("O body do request não é válido");
        await _context.Cursos.AddAsync(curso);
        await _context.SaveChangesAsync();
        
        return new CreatedAtRouteResult("ObterCurso", new {id = curso.Id}, curso);
        //return Ok($"Curso de {curso} adicionado com sucesso");
    }


    [HttpPut("{id:int}")]
    public async Task<ActionResult> Put (int id, Curso curso)
    {
        if(id != curso.Id)
        return BadRequest("O id do não existe");
        var cursoExistente = _context.Cursos.FirstOrDefaultAsync(curso => curso.Id == id);
        if(cursoExistente is null)
        return NotFound("O curso não existe");
     _context.Entry(curso).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
     await _context.SaveChangesAsync();
     return Ok($"Dados do curso de {curso.Nome} atualizado com sucesso");
        
  
    }

    [HttpDelete("{id:int}")]
    public async Task <ActionResult> Delete (int id)
    {
       var curso = await _context.Cursos.FindAsync(id);
       if(curso is null) return NotFound($"Curso com id {id} não existe");
       else 
     _context.Cursos.Remove(curso);
     await _context.SaveChangesAsync();
       return Ok($"Eliminação de {curso.Nome} realizada com sucesso");
    }



    }

