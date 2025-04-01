using System.ComponentModel.DataAnnotations;

namespace ASIST_UMG_api.Models.DTOs.cursos
{
    public class cDetalleCursosDto
    {
       
        public int IdCurso { get; set; }
        
        public int IdSedeCentro { get; set; }
        public string? NombreCurso { get; set; }

        public string? Descripcion { get; set; }
      
       
    }
}
