using AutoMapper;
using CarnivalBuddyApi.Dtos;
using CarnivalBuddyApi.Models;

namespace CarnivalBuddyApi.Mappings
{
    public class CarnivalMapping : Profile
    {
        public CarnivalMapping()
        {
            CreateMap<Carnival, CarnivalDto>();
            CreateMap<Link, LinkDto>();

            CreateMap<CarnivalDto, Carnival>();
            CreateMap<LinkDto, Link>();
        }
    }
}