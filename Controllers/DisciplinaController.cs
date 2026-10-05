using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentAPI.Models;
using StudentAPI.Context;

/*public class Disciplina
{

public int Id { get; set; }
public string? Nome { get; set; }
public int CursoId { get; set; }
public Curso? Course { get; set; }
}*/

namespace StudentAPI.Controllers
{
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
        public ActionResult<IEnumerable<Disciplina>> Get(Disciplina disciplina)
        {
            if(disciplina is null)
            return NotFound("Disciplina não encontrada");
            return _context.Disciplinas.ToList();
        }

        [HttpGet("{id:int}", Name ="ObterDisciplina")]
        public ActionResult<Disciplina> Get (Disciplina disciplina, int id)
        {
            if(disciplina is null) return NotFound("Disciplina não encontrada");
            _context.Disciplinas.FirstOrDefault(disciplina => disciplina.Id == id ); 
            return Ok(disciplina);       
        }
        
        [HttpPost]
        public ActionResult Post (Disciplina disciplina)
        {
            if(disciplina is null) return BadRequest("Péssima requisição\n");
            _context.Disciplinas.Add(disciplina);
            _context.SaveChanges();
            return new CreatedAtRouteResult("ObterDisciplina", new {id = disciplina.Id }, disciplina);
        }
    }
}
