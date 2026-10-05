using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentAPI.Context;
using StudentAPI.Models;

namespace StudentAPI.Controllers;
    [Route("api/[controller]")]
    [ApiController]
    public class EstudanteController : ControllerBase
    {
        private readonly AppDbContext _context;
        public EstudanteController(AppDbContext context)
        {
            _context = context;
        }
        //Primeiro endpoint para listar todos os estudantes
        /*api/estudante/{id} a variável id é do tipo inteiro, e o nome do endpoint é GetEstudante.
        Quem define seu valor é o front-end ou cliente que consome a API.
        */
        [HttpGet]
        public ActionResult <IEnumerable<Estudante>> Get()
        {
            return _context.Estudantes.ToList();
        }

        [HttpGet("{id:int}", Name = "GetEstudante")]
        public ActionResult<Estudante> Get(int id){
        var estudante = _context.Estudantes.FirstOrDefault(estudante => estudante.Id == id);if(estudante is null || id!=estudante.Id)return NotFound("Estudante não encontrado");
            return Ok(estudante);
    }
    [HttpPost]
    public ActionResult Post(Estudante estudante)

    {
        if(estudante is null) return BadRequest("Dados inválidos");
        _context.Estudantes.Add(estudante);
        _context.SaveChanges();
        return new CreatedAtRouteResult("GetEstudante", new {id = estudante.Id}, estudante);
    


    }
    [HttpPut("{id:int}")]
    public ActionResult Put(int id, Estudante estudante) {
    //Verifcar se o id do estudante é diferente do id passado na URL
    if(id != estudante.Id) 
    return BadRequest();
    //Efetivar a atualização do estudante no banco de dados
    _context.Entry(estudante).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
    _context.SaveChanges();
    return Ok(estudante);
    } 
/*Att caso eu queira fazer uma atualização parcial do estudante,
 devo usar o PATCH para atualizar apenas alguns campos do estudante*/

    [HttpDelete("{id:int}")]
    public ActionResult Delete(int id)
    {
 var estudante = _context.Estudantes.FirstOrDefault(estudante => estudante.Id == id);
    if(estudante is null) return NotFound("Estudante não encontrado");
    _context.Estudantes.Remove(estudante);
    _context.SaveChanges();
    return Ok("Estudante removido com sucesso");
 

    }
                
    }

