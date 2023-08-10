namespace GestorTareas.Models
{
    public class Encargados
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public List<EncargadosTareas> EncargadosTareas { get; set; }
    }
}
