using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentAPI.Context;
using StudentAPI.Models;
using StudentAPI.Services;

namespace StudentAPI.Controllers;
    [Route("api/[controller]")]
    [ApiController]
    public class EstudanteController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _config;
        public EstudanteController(AppDbContext context, IConfiguration config)
        {
            _config = config;
            _context = context;
        }

  /*      [HttpGet("UsarFromServices/{nome}")]
        public async Task<ActionResult <string> > saudacaoFromServices ([FromServices] MeuServico meuservico, string nome)
    {
        return meuservico.saudacao(nome);
    }*/
        
        [HttpGet]
        public async Task<ActionResult <IEnumerable<Estudante>>> Get(IEstudanteService estudanteService)
        {
            var estudantes = await estudanteService.ListarTodosAsync();
            return Ok(estudantes);

        }

        [HttpGet("{id:int}", Name = "GetEstudante")]
        public async Task <ActionResult<Estudante>> Get (int id, IEstudanteService estudanteService){
        var estudante = await estudanteService.BuscarPorIdAsync(id);
            if(estudante is null) 
                return NotFound("Estudante não encontrado");
                return Ok(estudante);
    }
    [HttpPost]
    public async Task<ActionResult> Post (Estudante estudante, IEstudanteService estudanteService)
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
        catch(Exception e)
        {

            return Problem(
                detail: "Ocorreu um erro interno ao tentar processar o registro",
                statusCode: 500,
                title: "Erro interno"
            );
            
        }
    

    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> Put(int id, Estudante estudante) {
    //Verifcar se o id do estudante é diferente do id passado na URL
    if(id != estudante.Id) 
    return BadRequest();
    //Efetivar a atualização do estudante no banco de dados
    _context.Entry(estudante).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
    await _context.SaveChangesAsync();
    return Ok(estudante);
    } 


    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(int id)
    {
 var estudante = _context.Estudantes.FirstOrDefault(estudante => estudante.Id == id);
    if(estudante is null) return NotFound("Estudante não encontrado");
    _context.Estudantes.Remove(estudante);
    await _context.SaveChangesAsync();
    return Ok("Estudante removido com sucesso");
 

    }
                
    }

