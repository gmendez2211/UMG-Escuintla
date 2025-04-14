using System.ComponentModel.DataAnnotations;

namespace ASIST_UMG_api.Models.DTOs.login
{
    public class cInicioSesionDto
    {
        [Required(ErrorMessage = "El correo eletrónico es Obligatorio.")]
        public string CorreoElectronico { get; set; } = null!;
        [Required(ErrorMessage = "La constreña es Obligatoria.")]
        public string? Contrasena { get; set; }
    }
}
