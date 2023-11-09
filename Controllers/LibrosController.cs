using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppAutores.Entities;

namespace WebAppAutores.Controllers
{
    [ApiController]
    [Route("api/libros")]
    public class LibrosController : ControllerBase
    {
        private readonly AppDbContext context;

        public LibrosController(AppDbContext context)
        {
            this.context = context;       
        }

        [HttpGet("{id:int}")]
        public async Task<Libro> Get(int id)
        {
            return await context.Libros.Include(x => x.Autor).FirstOrDefaultAsync(x => x.ID == id);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Libro libro)
        {
            var existAutor = await context.Autores.AnyAsync(x => x.ID == libro.AutorId);
            if (!existAutor)
            {
                return BadRequest($"No existe el autor con id: {libro.AutorId}");
            }

            context.Add(libro);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
