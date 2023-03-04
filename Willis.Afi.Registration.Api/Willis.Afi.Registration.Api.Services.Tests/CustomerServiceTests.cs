using AutoMapper;
using NSubstitute;
using Willis.Afi.Registration.Api.DataAccess.Entities;
using Willis.Afi.Registration.Api.Models;
using Willis.Afi.Registration.Api.Services.Interfaces;

namespace Willis.Afi.Registration.Api.Services.Tests
{
    [TestClass]
    public class CustomerServiceTests
    {

        private IMapper? _mapper = null;
        private ICustomerService? _sut = null;

        [TestInitialize]
        public void Initialize()
        {
            _mapper = Substitute.For<IMapper>();
            _sut = new CustomerService(_mapper);
        }

        [TestMethod]
        public void RegisterCustomer_Data_MapperCalled()
        {
            //Arrange
            var request = new RegisterRequest();
            //Act
            _sut?.Register(request);
            //Assert
            _mapper?.Received().Map<Customer>(request);
        }
    }
}