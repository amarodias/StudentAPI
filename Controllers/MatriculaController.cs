using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentAPI.Context;
using StudentAPI.Models;

namespace StudentAPI.Controllers;

    [Route("api/[controller]")] //Gera a rota /api/matricula
    [ApiController]
    public class MatriculaController : ControllerBase
    {
            private readonly AppDbContext _context; 
        
        public MatriculaController(AppDbContext context)
        {
        _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Matricula>> Get()
        {
            return _context.Matriculas.ToList();
          

        }
        // api/matricula/id
        [HttpGet("{id:int}", Name = "ObterMatricula")]
        public ActionResult Get(int id)
        {
           var matricula = _context.Matriculas.FirstOrDefault(matricula => matricula.Id == id);
           if(matricula is null) return NotFound("A matrícula não existe");
           return Ok(matricula);

        }
    [HttpPost]
    public ActionResult Post (Matricula matricula)
        {
            if(matricula is null) return BadRequest();
            _context.Matriculas.Add(matricula);
            _context.SaveChanges();
            return new CreatedAtRouteResult("ObterMatricula", new {id = matricula.Id}, matricula);
        
        }

     [HttpPut("{id:int}")]
     public ActionResult Put (Matricula matricula, int id)
    {
        if(id == matricula.Id)
        if(matricula is null) return BadRequest("Dados inválidados");
        
          _context.Matriculas.Entry(matricula).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
          _context.SaveChanges();
          return Ok(matricula);
     }  

    [HttpDelete("{id:int}")] 
    public ActionResult Delete (int id)
    {
        var matricula = _context.Matriculas.FirstOrDefault(matricula => matricula.Id == id);
        if(matricula is null) return NotFound("Matrícula não encontrada");
        _context.Matriculas.Remove(matricula);
        _context.SaveChanges();
        return Ok("Matrícula eliminada");
    }
    }

