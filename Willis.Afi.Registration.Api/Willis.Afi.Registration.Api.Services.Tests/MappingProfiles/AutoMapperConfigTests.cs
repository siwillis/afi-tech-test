using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Willis.Afi.Registration.Api.DataAccess.Entities;
using Willis.Afi.Registration.Api.Models;
using Willis.Afi.Registration.Api.Services.MappingProfiles;

namespace Willis.Afi.Registration.Api.Services.Tests.MappingProfiles
{
    [TestClass]
    public class AutoMapperConfigTests
    {

        private IMapper? _mapper = null;

        [TestInitialize]
        public void TestInitialize()
        {
            _mapper = AutoMapperConfig.Initialize();
        }

        [TestMethod]
        public void ToCustomer_MapConfigured_NoException()
        {
            //Act
            _mapper?.Map<Customer>(new RegisterRequest());
        }

        [TestMethod]
        public void Configuration_IsValid()
        {
            //Act
            _mapper?.ConfigurationProvider.AssertConfigurationIsValid();
        }

    }
}
