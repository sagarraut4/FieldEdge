using AutoMapper;
using ModelDto;
using webapi.Models;

namespace webapi
{
    public class DtoModelMapper : Profile
    {
        public DtoModelMapper()
        {
            CreateMap<CustomerDto, Customer>().ForMember(des => des.id, opt => opt.MapFrom(src => src.id));
            CreateMap<Customer, CustomerDto>().ForMember(des => des.email, opt => opt.MapFrom(src => src.email));
        }
    }
}
