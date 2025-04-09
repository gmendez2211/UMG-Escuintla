using ASIST_UMG_api.Models.DTOs.login;
using ASIST_UMG_api.Models;
using AutoMapper;

namespace ASIST_UMG_api.Mappers.Login
{
    public class cLoginMapper:Profile
    {
        public cLoginMapper()
        {
            CreateMap<ASIST_UMG_api.Models.Login, cRegistroLoginDto>().ReverseMap();
        }
        
    }
}
