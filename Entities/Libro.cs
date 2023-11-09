namespace WebAppAutores.Entities
{
    public class Libro
    {
        public int ID { get; set; }
        public string Titulo { get; set; }
        public int AutorId { get; set; }
        public Autor Autor { get; set; }

    }
}
