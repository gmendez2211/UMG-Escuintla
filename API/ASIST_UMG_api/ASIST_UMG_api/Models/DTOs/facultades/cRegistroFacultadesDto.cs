using System.ComponentModel.DataAnnotations;

namespace ASIST_UMG_api.Models.DTOs.facultades
{
    public class cRegistroFacultadesDto
    {
        [Required(ErrorMessage = "El Id de centro es Obligatorio.")]
        public int IdSedeCentro { get; set; }
        [Required(ErrorMessage = "La descripción es Obligatoria.")]
        public string? Descripcion { get; set; }
        [Required(ErrorMessage = "El nombre de la facultadad es Obligatoria.")]
        public string? NombreFacultad { get; set; }
    }
}
