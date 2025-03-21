using ASIST_UMG_api.Models;
using ASIST_UMG_api.Models.DTOs.personas;
using AutoMapper;

namespace ASIST_UMG_api.Mappers.Personas
{
    public class cPersonaMapper:Profile
    {
        public cPersonaMapper()
        {
            CreateMap<Persona, cRegistroPersonaDto>().ReverseMap();
            //CreateMap<Persona, cDetalleMarcajeDto>().ReverseMap(); 
        }
    }
}
