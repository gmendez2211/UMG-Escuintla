using ASIST_UMG_api.Models;
using ASIST_UMG_api.Models.DTOs.cursos;
using AutoMapper;

namespace ASIST_UMG_api.Mappers.Curso
{
    public class cCursoMapper:Profile
    {
        public cCursoMapper()
        {
            CreateMap<ASIST_UMG_api.Models.Curso, cRegistroCursoDto>().ReverseMap();
            CreateMap<ASIST_UMG_api.Models.Curso, cDetalleCursosDto>().ReverseMap();
            CreateMap<ASIST_UMG_api.Models.Curso, cActualizaCursoDto>().ReverseMap();

        }
        
    }
}
