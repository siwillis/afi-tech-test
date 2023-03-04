using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Willis.Afi.Registration.Api.Services.MappingProfiles
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize()
        {
            return new MapperConfiguration(mc => mc.AddMaps(typeof(AutoMapperConfig).Assembly)).CreateMapper();
        }
    }
}
