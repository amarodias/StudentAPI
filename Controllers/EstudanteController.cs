using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentAPI.Context;
using StudentAPI.Models;

namespace StudentAPI.Controllers
{
    [Route("api/[Estudantes]")]
    [ApiController]
    public class EstudanteController : ControllerBase
    {
        private readonly AppDbContext _context;
        public EstudanteController(AppDbContext context)
        {
            _context = context;
        }
        //Primeiro endpoint para listar todos os estudantes
        [HttpGet]
        public ActionResult <IEnumerable<Estudante>> Get(Estudante estudante)
        {
            if(estudante is null) return NotFound("Estudante não encontrado");
            return _context.Estudantes.ToList();

        }
        [HttpGet("{id:int}", Name = "GetEstudante")]
        public ActionResult<Estudante> Get(int id)

        {
            var estudante = _context.Estudantes.FirstOrDefault(estudante => estudante.Id == id);

     if(estudante is null || id!=estudante.Id)return NotFound("Estudante não encontrado");
            return Ok(estudante);
        }

    }
}
