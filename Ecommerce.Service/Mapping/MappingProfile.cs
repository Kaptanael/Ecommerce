using AutoMapper;
using Ecommerce.Dto.User;
using Ecommerce.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Service.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserForListResponse>();
            //CreateMap<UserTask, TaskForListDto>().ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.FirstName + " " + src.User.LastName));
        }
    }
}
