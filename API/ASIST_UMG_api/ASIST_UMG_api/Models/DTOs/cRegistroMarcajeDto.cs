using Microsoft.OpenApi.MicrosoftExtensions;
using System.ComponentModel.DataAnnotations;

namespace ASIST_UMG_api.Models.DTOs
{
    public class cRegistroMarcajeDto
    {
        //[Required(ErrorMessage = "ID de marcaje es necesario")]
        //public int IdMarcaje { get; set; }
        [Required(ErrorMessage = "ID de persona es necesario")]
        public int IdPersona { get; set; }
        [Required(ErrorMessage = "ID de curso es necesario")]
        public int IdCurso { get; set; }
        [Required(ErrorMessage = "El Estado es necesario")]
        public string? Estado { get; set; }
        [Required(ErrorMessage = "El tipo de marcaje es necesario")]
        public string? TipoMarcaje { get; set; }
        [Required(ErrorMessage = "La longitud del marcaje es necesario")]
        public decimal? Longitud { get; set; }
        [Required(ErrorMessage = "La latitud del marcaje es necesario")]
        public decimal? Latitud { get; set; }
        [Required(ErrorMessage = "Hora final de curso es necesario")]
        public TimeOnly? HoraFinal { get; set; }
        [Required(ErrorMessage = "Hora inicio es necesario")]
        public TimeOnly? HoraInicio { get; set; }
        [Required(ErrorMessage = "La fecha de marcaje es necesaria")]
        public DateOnly? Fecha { get; set; }


    }
}
