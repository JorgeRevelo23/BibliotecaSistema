namespace BiblioMundo.Models
{
    public class PersonaModel 
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public string Clave { get; set; }
        public string Codigo { get; set; }
        public TipoPersonaModel TipoPersona { get; set; }
        public int TipoPersonaId { get; set; }
        public bool Estado { get; set; }

    }

    
}
