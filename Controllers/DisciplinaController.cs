using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentAPI.Models;
using StudentAPI.Context;
using StudentAPI.Services;
using Microsoft.EntityFrameworkCore;

namespace StudentAPI.Controllers;
    [Route("api/[controller]")]
    [ApiController]
    public class DisciplinaController : ControllerBase
    {
        private readonly IDisciplinaService disciplinaService;
        public DisciplinaController(IDisciplinaService _disciplinaService)
    {
     disciplinaService = _disciplinaService;   
    }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Disciplina>>> Get()
        {
            var disciplinas = await disciplinaService.ListarDisciplinaAsync();
            if(disciplinas is null) return NotFound("Não foram encontradas disciplinas");
            return Ok(disciplinas);

        }

        [HttpGet("{id:int}", Name ="ObterDisciplina")]
        public async Task<ActionResult<Disciplina>> Get (int id)
    {
        var disciplina = await disciplinaService.ObterPeloIdAsync(id);
        if(disciplina is null) return NotFound("Disciplina não encontrada");
        return Ok(disciplina);
        
    }

        [HttpPost]
        public async Task<ActionResult> Post (Disciplina subject)
    {
        if(subject is null) return BadRequest("Dados Inválidos");
        try{ 
        var disciplina = await disciplinaService.CriarAsync(subject);
        if (disciplina is null) return Problem(
            detail: "Erro interno",
            statusCode: 500,
            title: "Erro interno do Servidor"
        );
        return Ok();
        }
        catch (Exception)
        {
            return Problem(
            detail: "Erro interno",
            statusCode: 500,
            title: "Erro interno do Servidor"
        );

            
        }
    }

[HttpPut("{id:int}")]
public async Task<ActionResult> Put (int id, Disciplina disciplina)
    {
        if(disciplina is null) return BadRequest();
        var subject = await disciplinaService.AtualizarAsync(id, disciplina);
        return Ok(subject);
    }
    
[HttpDelete("{id:int}")]
public async Task<ActionResult> Delete(int id) 

{
    var deletado = await disciplinaService.DeletarAsync(id);
    if(!deletado)
    return NotFound("A disciplina não existe");
    return Ok("Deletado com sucesso");
}


    }