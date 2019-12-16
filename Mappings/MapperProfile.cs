using AutoMapper;
using WebApplication3GraphQL.Models;
using WebApplication3GraphQL.Requests;

namespace WebApplication3GraphQL.Mappings
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<UserRequest, Users>().ReverseMap();
        }
    }
}