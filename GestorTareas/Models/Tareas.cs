using System.ComponentModel.DataAnnotations;

namespace GestorTareas.Models
{
    public class Tareas
    {
        public int Id { get; set; }
        [Required]
        [StringLength(120)]
        public string Nombre { get; set; }
        public Niveles Nivel { get; set; }
        public Proyectos Proyecto { get; set; }
        public List<SubTareas> SubTarea { get; set; }
        public List<EncargadosTareas> EncargadosTareas { get; set; }
    }
}
