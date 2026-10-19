using System.Linq.Expressions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentAPI.Models;
using StudentAPI.Services;

namespace StudentAPI.Controllers;
    [Route("api/[controller]")]
    [ApiController]
    public class EstudanteController : ControllerBase
    {
        private readonly IEstudanteService estudanteService;
        public EstudanteController(IEstudanteService _estudanteService)
    {
        estudanteService = _estudanteService;     
    }
        
        [HttpGet]
        public async Task<ActionResult <IEnumerable<Estudante>>> Get()
        {
            var estudantes = await estudanteService.ListarTodosAsync();
            return Ok(estudantes);

        }

        [HttpGet("{id:int}", Name = "GetEstudante")]
        public async Task <ActionResult<Estudante>> Get (int id){
        var estudante = await estudanteService.BuscarPorIdAsync(id);
            if(estudante is null) 
                return NotFound("Estudante não encontrado");
                return Ok(estudante);
    }
    [HttpPost]
    public async Task<ActionResult> Post (Estudante estudante)
    {
        if(estudante is null) return BadRequest("Dados inválidos");
        try
        {
           var e = await estudanteService.CriarAsync(estudante);
           if (e is null) return Problem(
            detail: "Não possível registrar o estudante no Sistema.",
            statusCode: 500,
            title: "Falha na Criação"
           );
           return new CreatedAtRouteResult ("GetEstudante", new {id = e.Id}, e);
        }
        catch(Exception)
        {

            return Problem(
                detail: "Ocorreu um erro interno ao tentar processar o registro",
                statusCode: 500,
                title: "Erro Interno"
            );
            
        }
    

    }

    [HttpPut("{id:int}")]
public async Task <ActionResult> Put (int id, Estudante estudante)
    {
        if(estudante is null) return BadRequest("Dados Inválidos");
        try
        {
            var e = await estudanteService.AtualizarAsync(id, estudante);
            if(e is null)
            return Problem(
              detail: "Erro ao atualizar",
              statusCode: 500,
              title: "Erro de Servidor"  
            );
            else return Ok(e);
        }
        catch(Exception)
        {
            return Problem(
                detail: "Erro ao atualizar",
                statusCode: 500,
                title: "Erro de Servidor"

            );
        }
    }


    [HttpDelete("{id:int}")]
public async Task <ActionResult>  Delete(int id)
    {
        var e = await estudanteService.EliminarAsync(id);
        if(!e) return NotFound("Estudante não encontrado.");
        else return Ok("Estudante removido com sucesso.");

    }
    }
