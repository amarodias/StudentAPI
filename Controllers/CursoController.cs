using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentAPI.Context;
using StudentAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace StudentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursoController : ControllerBase
    {
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
            if(cursos is null)
            return NotFound();
            else return Ok(cursos);
        
        }

    }
}
