namespace GestorTareas.Models
{
    public class Encargado
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public List<EncargadoTarea> EncargadosTareas { get; set; }
    }
}
