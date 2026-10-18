using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentAPI.Context;
using StudentAPI.Models;
using StudentAPI.Services;

namespace StudentAPI.Controllers;

    [Route("api/[controller]")] //Gera a rota /api/matricula
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


}

