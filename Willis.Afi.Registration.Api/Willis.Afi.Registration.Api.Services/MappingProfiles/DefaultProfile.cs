using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Willis.Afi.Registration.Api.DataAccess.Entities;
using Willis.Afi.Registration.Api.Models;

namespace Willis.Afi.Registration.Api.Services.MappingProfiles
{
    public class DefaultProfile : Profile
    {
        public DefaultProfile()
        {
            CreateMap<RegisterRequest, Customer>().ForMember(dest => dest.Id, act => act.Ignore());
        }
    }
}
