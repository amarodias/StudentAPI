using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentAPI.Context;
using StudentAPI.Models;
using StudentAPI.Services;

namespace StudentAPI.Controllers;

    [Route("api/[controller]")]
    [ApiController]
    public class MatriculaController : ControllerBase
    {
        private readonly IMatriculaService _matriculaService;
        public MatriculaController(IMatriculaService matriculaService)
         {
        _matriculaService = matriculaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Matricula>>> Get()
        {
             var matriculas = _matriculaService.ListarMatriculasAsync();
             if (matriculas is null) return NotFound("Não foram encontradas matrículas");
             return Ok(matriculas);
        }

[HttpGet("{id:int}")]
public async Task<ActionResult<Matricula>> Get(int id)
    {
        var matricula = await _matriculaService.ObterPeloIdAsync(id);
        return Ok(matricula);
    }
[HttpPost]
public async Task<ActionResult> Post(Matricula matricula)
    {
        if(matricula is null) 
        return BadRequest("Dados Inválidos");
        var aux = await _matriculaService.CriarAsync(matricula);
        if(aux is null) return Problem(
            detail : "Erro ao confirmar matrícula", statusCode : "500", tiltle: "Erro de Servidor"
        );
        return Ok(aux);

        
    }    
}

