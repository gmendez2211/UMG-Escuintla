using System.ComponentModel.DataAnnotations;

namespace ASIST_UMG_api.Models.DTOs.sedesCentros
{
    public class cRegistroSedeCentroDto
    {
        [Required(ErrorMessage = "ID del centro es necesario")]
        public int IdSedeCentro { get; set; }
        [Required(ErrorMessage = "El correo es necesario")]
        public string? CorreoElectronico { get; set; }
        [Required(ErrorMessage = "El teléfono es necesario")]
        public string? Telefono { get; set; }
        [Required(ErrorMessage = "La dirección es necesario")]
        public string? Direccion { get; set; }
        [Required(ErrorMessage = "El nombre de sede o centro es necesario")]
        public string? NombreSede { get; set; }
    }
}
