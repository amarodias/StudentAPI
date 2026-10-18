using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentAPI.Context;
using StudentAPI.Models;
using StudentAPI.Services;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Http.HttpResults;

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
        public async Task<ActionResult <IEnumerable<Curso>>> Get(ICursoService cursoService)
        {  
           var cursos = await cursoService.ListarCursosAsync();
           if(cursos is null) return NotFound("Não há cursos disponíveis");
           return Ok(cursos);
        }

        [HttpGet("{id:int}", Name = "ObterCurso")]
        public async Task<ActionResult<Curso>> Get(int id, ICursoService cursoService)
        {
            var curso = await cursoService.ObterCursoPeloIdAsync(id);
            if (curso is null) return NotFound("O curso não existe");
            return Ok(curso);
        }

        [HttpPost]
        public async Task<ActionResult> Post (Curso curso, ICursoService cursoService)
    {
        if (curso is null) return BadRequest("Dados inválidos");
        try
        {
         var novo = await cursoService.CriarAsync(curso);
         if(novo is null) return Problem(
            detail : "Erro ao criar",
            statusCode: 500,
            title: "Erro Interno de Servidor"
         );
         return new CreatedAtRouteResult ("ObterCurso", new{id = novo.Id}, novo);
        }
        catch (Exception)
        {
           return Problem(
            detail : "Erro ao criar",
            statusCode: 500,
            title: "Erro Interno de Servidor"
         ); 
        }

    }


    [HttpPut("{id:int}")]
    public async Task<ActionResult> Put (int id, Curso curso, ICursoService cursoService)
    {
        if (curso is null) return BadRequest("Dados Inválidos"); 
        var atualizar = await cursoService.AtualizarAsync(id, curso);
        return Ok($"Curso de {atualizar?.Nome} atualizado");
    }

    [HttpDelete("{id:int}")]
    public async Task <ActionResult> Delete (int id, ICursoService cursoService)
    {
        var Deletado = await cursoService.EliminarAsync(id);
        if(!Deletado) return NotFound("Curso não encontrado");
        return Ok($"Curso de deletado");
    }
}
