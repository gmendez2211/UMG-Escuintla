using System.ComponentModel.DataAnnotations;

namespace ASIST_UMG_api.Models.DTOs.cursos
{
    public class cActualizaCursoDto
    {
        [Required(ErrorMessage = "El ID del curso es Obligatorio.")]
        public int IdCurso { get; set; }
        [Required(ErrorMessage = "La descripción es Obligatoria.")]
        public string? Descripcion { get; set; }
        [Required(ErrorMessage = "El nombre del curso es Obligatorio.")]
        public string? NombreCurso { get; set; }
    }
}
