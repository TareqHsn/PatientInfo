using AutoMapper;
using PatientInfo_API.Models;
using PatientInfo_API.Models.DTOs;

namespace PatientInfo_API.Halper
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
           CreateMap<Allergy, AllergiesDTO>().ReverseMap();
           CreateMap<NDC, NDCDTO>().ReverseMap();
           CreateMap<DiseaseInfo, DiseaseInfoDTO>().ReverseMap();
        }
       
    }
}
