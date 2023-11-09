using Microsoft.EntityFrameworkCore;
using WebAppAutores.Entities;

namespace WebAppAutores
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Autor> Autores { get; set; } //para crear tablas en la bd a partir de una clase
        public DbSet<Libro> Libros { get; set; }
    }
}
