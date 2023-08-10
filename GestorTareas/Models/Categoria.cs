namespace GestorTareas.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public List<Proyecto> Proyectos { get; set; }
    }
}
