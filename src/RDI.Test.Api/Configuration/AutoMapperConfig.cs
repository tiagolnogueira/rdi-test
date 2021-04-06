using AutoMapper;
using RDI.Test.Api.ViewModels;
using RDI.Test.Domain.Entities;

namespace RDI.Test.Api.Configuration
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Customer, CustomerViewModel>().ReverseMap();
            CreateMap<Card, CardViewModel>().ReverseMap();
        }
    }
}