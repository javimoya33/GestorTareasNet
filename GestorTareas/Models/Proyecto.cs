namespace GestorTareas.Models
{
    public class Proyecto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public Categoria Categoria { get; set; }
        public List<Tarea> Tareas { get; set; }
    }
}
