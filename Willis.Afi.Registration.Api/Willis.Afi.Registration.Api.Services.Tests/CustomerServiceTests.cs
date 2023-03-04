using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NSubstitute;
using Willis.Afi.Registration.Api.DataAccess;
using Willis.Afi.Registration.Api.DataAccess.Entities;
using Willis.Afi.Registration.Api.Models;
using Willis.Afi.Registration.Api.Services.Interfaces;

namespace Willis.Afi.Registration.Api.Services.Tests
{
    [TestClass]
    public class CustomerServiceTests
    {

        private DataContext? _testDataContext = null;
        private IMapper? _mapper = null;
        private ICustomerService? _sut = null;

        [TestInitialize]
        public void Initialize()
        {
            var options = new DbContextOptionsBuilder<DataContext>().UseInMemoryDatabase("TestDb").Options;
            _testDataContext = Substitute.For<DataContext>(options);
            _mapper = Substitute.For<IMapper>();
            _sut = new CustomerService(_mapper, _testDataContext);
        }

        [TestMethod]
        public void RegisterCustomer_Data_MapperCalled()
        {
            //Arrange
            var request = new RegisterRequest();
            var dao = new Customer();
            _mapper?.Map<Customer>(request).Returns(dao);
            //Act
            _sut?.Register(request);
            //Assert
            _mapper?.Received().Map<Customer>(request);
        }

        [TestMethod]
        public void RegisterCustomer_InsertPerformed_IdReturned()
        {
            //Arrange
            var id = 123;
            var request = new RegisterRequest();
            var dao = new Customer();
            _mapper?.Map<Customer>(request).Returns(dao);
            _testDataContext?.Add(Arg.Do<Customer>(x => x.Id = id));
            //Act
            var result = _sut?.Register(request);
            //Assert
            Assert.AreEqual(result?.CustomerId, id);
            _testDataContext?.Received().SaveChanges();
        }
    }
}