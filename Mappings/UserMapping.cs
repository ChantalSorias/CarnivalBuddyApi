using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarnivalBuddyApi.Dtos;
using CarnivalBuddyApi.Models;

namespace CarnivalBuddyApi.Mappings
{
    public class UserMapping : Profile
    {
        public UserMapping()
        {
            CreateMap<User, UserDto>();
            CreateMap<Song, SongDto>();

            CreateMap<UserDto, User>();
            CreateMap<SongDto, Song>();
        }
    }
}