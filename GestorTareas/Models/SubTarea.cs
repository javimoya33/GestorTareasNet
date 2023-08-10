namespace GestorTareas.Models
{
    public class SubTarea
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public Estado Estado { get; set; }
        public DateTime Fecha_prevista { get; set; }
        public Tarea Tarea { get; set; }
    }
}
