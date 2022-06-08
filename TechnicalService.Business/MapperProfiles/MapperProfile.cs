using AutoMapper;
using TechnicalService.Core.Entities;
using TechnicalService.Core.ViewModels;

namespace TechnicalService.Business.MapperProfiles
{
    public class MapperProfile : Profile
    {

        public MapperProfile()
        {
            CreateMap<ServiceDemand, ServiceViewModel>().ReverseMap();
        }
    }
}
