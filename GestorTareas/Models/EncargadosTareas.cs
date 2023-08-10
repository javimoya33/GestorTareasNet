namespace GestorTareas.Models
{
    public class EncargadosTareas
    {
        public int EncargadoId { get; set; }
        public int TareaId { get; set; }
        public Encargados Encargados { get; set; }
        public Tareas Tareas { get; set; }
    }
}
