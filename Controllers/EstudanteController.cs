using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentAPI.Context;

namespace StudentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudanteController : ControllerBase
    {
        private readonly AppDbContext _context;
        public EstudanteController(AppDbContext context)
        {
            _context = context;
        }
    }
}
