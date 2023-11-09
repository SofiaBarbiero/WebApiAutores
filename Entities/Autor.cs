namespace WebAppAutores.Entities
{
    public class Autor
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public List<Libro> Libros { get; set; }
    }
}
