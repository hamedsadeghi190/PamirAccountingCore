using AutoMapper;
using PamirAccounting.Domains;
using PamirAccounting.Models;
using PamirAccounting.Models.ViewModels;

namespace PamirAccounting.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<CurrenciesViewModel, Currency>().ReverseMap();
            CreateMap<CustomerGroupModel, CustomerGroup>().ReverseMap();
        }

    }
}
