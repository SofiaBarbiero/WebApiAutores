using System.ComponentModel.DataAnnotations;
using WebAppAutores.Validations;

namespace WebAppAutores.Entities
{
    public class Autor
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")] //validaciones predefinidas
        [FirstLetterUpperCase] //validacion personalizada
        public string Name { get; set; }

        public List<Libro> Libros { get; set; }
    }
}
