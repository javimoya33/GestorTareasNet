namespace GestorTareas.Models
{
    public class Proyectos
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public Categorias Categoria { get; set; }
        public List<Tareas> Tareas { get; set; }
    }
}
