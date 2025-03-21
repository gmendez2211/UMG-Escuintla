using Microsoft.OpenApi.MicrosoftExtensions;
using System.ComponentModel.DataAnnotations;

namespace ASIST_UMG_api.Models.DTOs
{
    public class cDetalleMarcajeDto
    {
       
        public int IdMarcaje { get; set; }
        
        public int IdPersona { get; set; }
        public int IdCurso { get; set; }
        public string? Curso { get; set; }
       
        public string? Estado { get; set; }
       
        public string? TipoMarcaje { get; set; }
       
        public decimal? Longitud { get; set; }
        
        public decimal? Latitud { get; set; }
        
        public TimeOnly? HoraFinal { get; set; }
       
        public TimeOnly? HoraInicio { get; set; }
        public DateOnly? Fecha { get; set; }


    }
}
