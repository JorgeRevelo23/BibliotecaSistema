namespace BiblioMundo.Models
{
    public class LibroModel 
    {
        public int Id { get; set; }
        public string Titulo { get; set;}
        public AutorModel Autor { get; set; }
        public int AutorId { get; set; }
        public CategoriaModel Categoria { get; set; }
        public int CategoriaId { get; set; }
        public EditorialModel Editorial { get; set; }
        public int EditorialId { get; set; }
        public string Ubicacion { get; set;}
        public int Ejemplares { get; set;}
        public bool Estado { get; set;}
        
    }
}
