namespace BiblioMundo.Models
{
    public class TipoPersonaModel 
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public List<PersonaModel> Personas { get; set; }
    }
}
