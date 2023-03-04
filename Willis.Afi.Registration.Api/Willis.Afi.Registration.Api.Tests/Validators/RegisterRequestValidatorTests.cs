using FluentValidation;
using FluentValidation.TestHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Willis.Afi.Registration.Api.Models;
using Willis.Afi.Registration.Api.Validators;

namespace Willis.Afi.Registration.Api.Tests.Validators
{
    [TestClass]
    public class RegisterRequestValidatorTests
    {
        private AbstractValidator<RegisterRequest>? _sut;

        [TestInitialize]
        public void Initialize()
        {
            _sut = new RegisterRequestValidator();
        }

        private RegisterRequest GetFullValidRequest()
        {
            return new RegisterRequest
            {
                FirstName = "Simon"
            };
        }

        [TestMethod]
        public void Validate_Full_NoErrors()
        {
            //Arrange
            var model = GetFullValidRequest();
            //Act
            var result = _sut.TestValidate(model);
            //Assert
            result.ShouldNotHaveAnyValidationErrors();
        }

        [TestMethod]
        public void Validate_FirstNameIsNull_Error()
        {
            //Arrange
            var model = GetFullValidRequest();
            model.FirstName = null;
            //Act
            var result = _sut.TestValidate(model);
            //Assert
            result.ShouldHaveValidationErrorFor(x => x.FirstName);
        }
    }
}
