using ASIST_UMG_api.Models;
using ASIST_UMG_api.Models.DTOs;
using AutoMapper;

namespace ASIST_UMG_api.Mappers.Marcajes
{
    public class cMarcajeMapper:Profile
    {
        public cMarcajeMapper()
        {
            CreateMap<Marcaje, cRegistroMarcajeDto>().ReverseMap();
            CreateMap<Marcaje, cDetalleMarcajeDto>().ReverseMap(); 
        }
    }
}
