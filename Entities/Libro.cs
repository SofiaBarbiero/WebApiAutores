using System.ComponentModel.DataAnnotations;
using WebAppAutores.Validations;

namespace WebAppAutores.Entities
{
    public class Libro
    {
        public int ID { get; set; }

        [Required]
        [FirstLetterUpperCase]
        public string Titulo { get; set; }

        [Required]
        
        public int AutorId { get; set; }
        public Autor Autor { get; set; }

    }
}
