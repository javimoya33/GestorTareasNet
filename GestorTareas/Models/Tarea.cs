using System.ComponentModel.DataAnnotations;

namespace GestorTareas.Models
{
    public class Tarea
    {
        public int Id { get; set; }
        [Required]
        [StringLength(120)]
        public string Nombre { get; set; }
        public Nivel Nivel { get; set; }
        public Proyecto Proyecto { get; set; }
        public List<SubTarea> SubTarea { get; set; }
        public List<EncargadoTarea> EncargadosTareas { get; set; }
    }
}
