namespace GestorTareas.Models
{
    public class EncargadoTarea
    {
        public int EncargadoId { get; set; }
        public int TareaId { get; set; }
        public Encargado Encargados { get; set; }
        public Tarea Tareas { get; set; }
    }
}
