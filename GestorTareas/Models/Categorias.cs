namespace GestorTareas.Models
{
    public class Categorias
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public List<Proyectos> Proyectos { get; set; }
    }
}
