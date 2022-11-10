using System.ComponentModel.DataAnnotations;

namespace TryPactia.Models
{
    public class Persona
    {
        [Required]
        public string? Cedula { get; set; }
        [Required]
        public string? Nombre { get; set; }
        [Required]
        public string? Apellido { get; set; }

    }
}
