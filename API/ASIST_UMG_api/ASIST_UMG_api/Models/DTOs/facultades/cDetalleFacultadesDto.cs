using System.ComponentModel.DataAnnotations;

namespace ASIST_UMG_api.Models.DTOs.facultades
{
    public class cDetalleFacultadesDto
    {
        public int IdSedeCentro { get; set; }
               public string? Descripcion { get; set; }
        
        public string? NombreFacultad { get; set; }
    }
}
