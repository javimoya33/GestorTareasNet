using System.ComponentModel.DataAnnotations;

namespace GestorTareas.DTOs
{
    public class ProyectoCreacionDTO
    {
        [Required]
        [StringLength(300)]
        public string Nombre { get; set; }
        public int CategoriaId { get; set; }
    }
}
