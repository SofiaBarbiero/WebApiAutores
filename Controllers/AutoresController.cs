using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppAutores.Entities;

namespace WebAppAutores.Controllers
{
    //decoradores
    [ApiController]
    [Route("api/autores")]
    public class AutoresController : ControllerBase
    {
        private readonly AppDbContext context;

        public AutoresController(AppDbContext context) //injecto el context
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Autor>>> Get() //include: para traer datos de otra tabla con la cual tiene relacion
        {
            return await context.Autores.Include(x => x.Libros).ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Post(Autor autor)
        {
            context.Add(autor);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Update(Autor autor, int id)
        {
            if(autor.ID != id)
            {
                return BadRequest("el id del actor no coincide con el id de la URL");
            };

            var exist = await context.Autores.AnyAsync(x => x.ID == id);

            if (!exist)
            {
                return NotFound();
            }

            context.Update(autor);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exist = await context.Autores.AnyAsync(x => x.ID == id);

            if (!exist)
            {
                return NotFound();
            }

            context.Remove(new Autor() { ID = id});
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
