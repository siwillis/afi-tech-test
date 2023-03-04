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
                FirstName = "Simon",
                LastName = "Willis",
                DateOfBirth = DateTime.Now.AddYears(-21),
                ReferenceNumber = "AB-123456",
                EmailAddress = "simon.willis@test.com"
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
        public void Validate_NoEmailAndNoDob_Error()
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

        [TestMethod]
        public void Validate_FirstNameLessThans3Chars_Error()
        {
            //Arrange
            var model = GetFullValidRequest();
            model.FirstName = "AA";
            //Act
            var result = _sut.TestValidate(model);
            //Assert
            result.ShouldHaveValidationErrorFor(x => x.FirstName);
        }

        [TestMethod]
        public void Validate_FirstNameMoreThans50Chars_Error()
        {
            //Arrange
            var model = GetFullValidRequest();
            model.FirstName = new string('Z', 51);
            //Act
            var result = _sut.TestValidate(model);
            //Assert
            result.ShouldHaveValidationErrorFor(x => x.FirstName);
        }

        [TestMethod]
        public void Validate_LastNameIsNull_Error()
        {
            //Arrange
            var model = GetFullValidRequest();
            model.LastName = null;
            //Act
            var result = _sut.TestValidate(model);
            //Assert
            result.ShouldHaveValidationErrorFor(x => x.LastName);
        }

        [TestMethod]
        public void Validate_LastNameLessThans3Chars_Error()
        {
            //Arrange
            var model = GetFullValidRequest();
            model.LastName = "AA";
            //Act
            var result = _sut.TestValidate(model);
            //Assert
            result.ShouldHaveValidationErrorFor(x => x.LastName);
        }

        [TestMethod]
        public void Validate_LastNameMoreThans50Chars_Error()
        {
            //Arrange
            var model = GetFullValidRequest();
            model.LastName = new string('Z', 51);
            //Act
            var result = _sut.TestValidate(model);
            //Assert
            result.ShouldHaveValidationErrorFor(x => x.LastName);
        }

        [TestMethod]
        public void Validate_ReferenceNumberIsNull_Error()
        {
            //Arrange
            var model = GetFullValidRequest();
            model.ReferenceNumber = null;
            //Act
            var result = _sut.TestValidate(model);
            //Assert
            result.ShouldHaveValidationErrorFor(x => x.ReferenceNumber);
        }

        [DataTestMethod]
        [DataRow("aB-999999")] //Char 1 lower
        [DataRow("Ab-999999")] //Char 2 lower
        [DataRow("1B-999999")] //Char 1 numeric
        [DataRow("A2-999999")] //Char 2 numeric
        [DataRow("ABA999999")] //Char 3 not hyphen
        [DataRow("AB-X99999")] //Char 4 alpha
        [DataRow("AB-9X9999")] //Char 5 alpha
        [DataRow("AB-99X999")] //Char 6 alpha
        [DataRow("AB-999X99")] //Char 7 alpha
        [DataRow("AB-9999X9")] //Char 8 alpha
        [DataRow("AB-99999X")] //Char 9 alpha
        [DataRow("AB-9999999")] //Extra char
        public void Validate_ReferenceNumberInvalidFormat_Error(string referenceNumber)
        {
            //Arrange
            var model = GetFullValidRequest();
            model.ReferenceNumber = referenceNumber;
            //Act
            var result = _sut.TestValidate(model);
            //Assert
            result.ShouldHaveValidationErrorFor(x => x.ReferenceNumber);
        }

        [TestMethod]
        public void Validate_NoDob_NoErrors()
        {
            //Arrange
            var model = GetFullValidRequest();
            model.DateOfBirth = null;
            //Act
            var result = _sut.TestValidate(model);
            //Assert
            result.ShouldNotHaveAnyValidationErrors();
        }

        [TestMethod]
        public void Validate_NotYet18_Error()
        {
            //Arrange
            var model = GetFullValidRequest();
            model.DateOfBirth = DateTime.Today.AddYears(-18).AddDays(1);
            //Act
            var result = _sut.TestValidate(model);
            //Assert
            result.ShouldHaveValidationErrorFor(x => x.DateOfBirth);
        }

        [TestMethod]
        public void Validate_NoEmailNull_NoErrors()
        {
            //Arrange
            var model = GetFullValidRequest();
            model.EmailAddress = null;
            //Act
            var result = _sut.TestValidate(model);
            //Assert
            result.ShouldNotHaveAnyValidationErrors();
        }

        [TestMethod]
        public void Validate_NoEmailEmptyString_NoErrors()
        {
            //Arrange
            var model = GetFullValidRequest();
            model.EmailAddress = string.Empty;
            //Act
            var result = _sut.TestValidate(model);
            //Assert
            result.ShouldNotHaveAnyValidationErrors();
        }

        [TestMethod]
        public void Validate_EmailCoUk_NoErrors()
        {
            //Arrange
            var model = GetFullValidRequest();
            model.EmailAddress = "simon.willis@test.co.uk";
            //Act
            var result = _sut.TestValidate(model);
            //Assert
            result.ShouldNotHaveAnyValidationErrors();
        }

        [DataTestMethod]
        [DataRow("%AAA@ZZ.com")] //Non alpha before @
        [DataRow("AAAA@Z%.com")] //Non alpha after @
        [DataRow("AAAAZZZ.com")] //Missing @
        [DataRow("AAA@ZZ.com")] //3 char before @
        [DataRow("AAAA@Z.com")] //1 char after @
        [DataRow("AAAA@Z.con")] //Not .com or .co.uk
        public void Validate_EmailInvalidFormat_Error(string emailAddress)
        {
            //Arrange
            var model = GetFullValidRequest();
            model.EmailAddress = emailAddress;
            //Act
            var result = _sut.TestValidate(model);
            //Assert
            result.ShouldHaveValidationErrorFor(x => x.EmailAddress);
        }
    }
}
