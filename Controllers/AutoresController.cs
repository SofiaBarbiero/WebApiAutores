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


        //config del ruteo: puedo tener varias rutas para acceder a un mismo endpoint
        [HttpGet] // api/actores
        [HttpGet("listado")] // /api/actores/listado
        [HttpGet("/listado")] // /listado
        public async Task<ActionResult<List<Autor>>> Get() //include: para traer datos de otra tabla con la cual tiene relacion
        {
            return await context.Autores.Include(x => x.Libros).ToListAsync();
        }

        [HttpGet("primero")]
        public async Task<ActionResult<Autor>> GetPrimerAutor()
        {
            return await context.Autores.Include(x => x.Libros).FirstOrDefaultAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Post(Autor autor)
        {
            //validacion en controlador contra la BD
            var existe = await context.Autores.AnyAsync(x => x.Name == autor.Name);
            if (existe)
            {
                return BadRequest($"ya existe un autor con el nombre {autor.Name}"); //$ + {} interpolación de datos!
            }

            context.Add(autor);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Update([FromBody] Autor autor, [FromRoute] int id) // [especifico de donde vienen los datos al momento de la peticion, es opcional]
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
