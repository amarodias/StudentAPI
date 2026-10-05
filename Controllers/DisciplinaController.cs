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

namespace StudentAPI.Controllers;
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
        try
        {
         if(disciplina is null) return NotFound("Disciplina não encontrada");
        _context.Disciplinas.FirstOrDefault(disciplina => disciplina.Id == id ); 
         return Ok(disciplina);     
        }
        catch(Exception)
        {
         return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um problema ao tratar a solicitação");   
        }
      
        }

        [HttpPost]
        public ActionResult Post (Disciplina disciplina)
        {
            if(disciplina is null) return BadRequest("Péssima requisição\n");
            _context.Disciplinas.Add(disciplina);
            _context.SaveChanges();
            return new CreatedAtRouteResult("ObterDisciplina", new {id = disciplina.Id }, disciplina);
        }
        [HttpPut("{id:int}")]

        public ActionResult Put (int id, Disciplina disciplina)
    {
        if(disciplina.Id!=id)
        return BadRequest("Id não identificado");
        //Autoriza a atualização de dados
        _context.Entry(disciplina).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        _context.SaveChanges();
        return Ok(disciplina);
    }


    [HttpDelete("{id:int}")]
    public ActionResult Delete (int id)

    {
        var disciplina = _context.Disciplinas.FirstOrDefault(disciplina => disciplina.Id==id);
        if(disciplina is null) return NotFound("Não encontrado");
        _context.Disciplinas.Remove(disciplina);
        _context.SaveChanges();
        return Ok("Disciplina eliminada");
        
    }


    }

