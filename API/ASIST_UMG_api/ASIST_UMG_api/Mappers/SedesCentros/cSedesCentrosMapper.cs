using ASIST_UMG_api.Models;
using ASIST_UMG_api.Models.DTOs.sedesCentros;
using AutoMapper;

namespace ASIST_UMG_api.Mappers.SedesCentros
{
    public class cSedesCentrosMapper:Profile
    {
        public cSedesCentrosMapper()
        {
            CreateMap<SedeCentro, cRegistroSedeCentroDto>().ReverseMap();
            CreateMap<SedeCentro, cDetalleSedesCentrosDto>().ReverseMap();
        }
       
    }
}
