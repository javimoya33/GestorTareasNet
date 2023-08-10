namespace GestorTareas.Models
{
    public class SubTareas
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public Estados Estado { get; set; }
        public DateTime Fecha_prevista { get; set; }
        public Tareas Tarea { get; set; }
    }
}
