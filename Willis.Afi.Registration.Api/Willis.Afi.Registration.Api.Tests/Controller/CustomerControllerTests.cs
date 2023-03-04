using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Willis.Afi.Registration.Api.Controllers;
using Willis.Afi.Registration.Api.Models;
using NSubstitute;
using Willis.Afi.Registration.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Castle.Core.Resource;
using System.Security.Cryptography.X509Certificates;

namespace Willis.Afi.Registration.Api.Tests.Controller
{
    [TestClass]
    public class CustomerControllerTests
    {

        private InlineValidator<RegisterRequest>? _validator;
        private ICustomerService? _customerService;
        private CustomerController? _sut;


        [TestInitialize] 
        public void Init() 
        {
            _customerService = Substitute.For<ICustomerService>();
            _validator = new InlineValidator<RegisterRequest>();
            _sut = new CustomerController(_validator, _customerService);
        }

        private RegisterRequest GetValidRequest()
        {
            return new RegisterRequest();
        }

        [TestMethod] 
        public async Task PostRegister_Valid_OkResult() 
        { 
            //Arrange
            var request = GetValidRequest();
            //Act
            var result = _sut != null ? await _sut.Register(request) : null;
            //Assert
            var createdResult = result?.Result as OkObjectResult;
            Assert.IsNotNull(createdResult);
        }

        [TestMethod]
        public async Task PostRegister_Invalid_BadRequest()
        {
            //Arrange
            var request = GetValidRequest();
            _validator?.RuleFor(x => x.FirstName).Must(x => false);
            //Act
            var result = _sut != null ? await _sut.Register(request) : null;
            //Assert
            var badRequestResult = result?.Result as BadRequestObjectResult;
            Assert.IsNotNull(badRequestResult);
        }

        [TestMethod]
        public async Task PostRegister_Valid_ServiceResponseProvided()
        {
            //Arrange
            var request = GetValidRequest();
            var response = new RegisterResponse();
            _customerService?.Register(request).Returns(response);
            //Act
            var result = _sut != null ? await _sut.Register(request) : null;
            //Assert
            var createdResult = result?.Result as OkObjectResult;
            var registerResponse = createdResult?.Value as RegisterResponse;
            Assert.AreEqual(registerResponse, response);
        }

    }
}
