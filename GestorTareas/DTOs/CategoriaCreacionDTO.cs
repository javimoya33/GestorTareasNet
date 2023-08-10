using System.ComponentModel.DataAnnotations;

namespace GestorTareas.DTOs
{
    public class CategoriaCreacionDTO
    {
        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }
    }
}
