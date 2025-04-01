using System.ComponentModel.DataAnnotations;

namespace ASIST_UMG_api.Models.DTOs.cursos
{
    public class cRegistroCursoDto
    {
        [Required(ErrorMessage = "El ID de curso es Obligatorio.")]
        public int IdCurso { get; set; }
        [Required(ErrorMessage = "El ID del centro es Obligatorio.")]
        public int IdSedeCentro { get; set; }
        [Required(ErrorMessage = "La fecha fin es Obligatoria.")]
        public DateOnly? FechaFin { get; set; }
        [Required(ErrorMessage = "La fecha inicio es Obligatoria.")]
        public DateOnly? FechaInicio { get; set; }
        [Required(ErrorMessage = "La descripción es Obligatoria.")]
        public string? Descripcion { get; set; }
        [Required(ErrorMessage = "El nombre del curso es Obligatorio.")]
        public string? NombreCurso { get; set; }
    }
}
