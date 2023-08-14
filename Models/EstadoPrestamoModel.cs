namespace BiblioMundo.Models
{
    public class EstadoPrestamoModel 
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public List<PrestamoModel> Prestamos { get; set; }
    }
}
