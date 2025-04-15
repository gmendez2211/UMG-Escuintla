using ASIST_UMG_api.Models.DTOs.facultades;
using ASIST_UMG_api.Models.DTOs.login;
using AutoMapper;

namespace ASIST_UMG_api.Mappers.Facultad
{
    public class cFacultadMapper:Profile
    {
        public cFacultadMapper()
        {
            CreateMap<ASIST_UMG_api.Models.Facultad, cRegistroFacultadesDto>().ReverseMap();
            CreateMap<ASIST_UMG_api.Models.Facultad, cDetalleFacultadesDto>().ReverseMap();
        }
    }
}
