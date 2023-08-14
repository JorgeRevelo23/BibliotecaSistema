namespace BiblioMundo.Models
{
    public class PrestamoModel 
    {
        public int Id { get; set; }
        public EstadoPrestamoModel EstadoPrestamo { get; set; }
        public int EstadoPrestamoId { get; set; }
        public PersonaModel Persona { get; set; }
        public int PersonaId { get; set; }
        public LibroModel Libro { get; set; }
        public int LibroId { get; set; }
        public DateTime FechaDevolucion { get; set; }
        public string TextoFechaDevolucion { get; set; }
        public DateTime FechaConfirmacionDevolucion { get; set; }
        public string TextoFechaConfirmacionDevolucion { get; set; }
        public string EstadoEntregado { get; set; }
        public string EstadoRecibido { get; set; }
        public bool Estado { get; set; }
        
    }
}
