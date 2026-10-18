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
        private readonly ICursoService  _cursoService;
        public CursoController(ICursoService  cursoService)
    {
         _cursoService = cursoService ;
        
    }

        [HttpGet]
        public async Task<ActionResult <IEnumerable<Curso>>> Get()
        {  
           var cursos = await _cursoService.ListarCursosAsync();
           if(cursos is null) return NotFound("Não há cursos disponíveis");
           return Ok(cursos);
        }

        [HttpGet("{id:int}", Name = "ObterCurso")]
        public async Task<ActionResult<Curso>> Get(int id)
        {
            var curso = await _cursoService.ObterCursoPeloIdAsync(id);
            if (curso is null) return NotFound("O curso não existe");
            return Ok(curso);
        }

        [HttpPost]
        public async Task<ActionResult> Post (Curso curso)
    {
        if (curso is null) return BadRequest("Dados inválidos");
        try
        {
         var novo = await _cursoService.CriarAsync(curso);
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
    public async Task<ActionResult> Put (int id, Curso curso)
    {
        if (curso is null) return BadRequest("Dados Inválidos"); 
        var atualizar = await _cursoService.AtualizarAsync(id, curso);
        return Ok($"Curso de {atualizar?.Nome} atualizado");
    }

    [HttpDelete("{id:int}")]
    public async Task <ActionResult> Delete (int id)
    {
        var Deletado = await _cursoService.EliminarAsync(id);
        if(!Deletado) return NotFound("Curso não encontrado");
        return Ok($"Curso de deletado");
    }
}
