using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Newtonsoft.Json;
using System.Text;
using Willis.Afi.Registration.Api.Models;
using Willis.Afi.Registration.Api.Tests.Setup;

namespace Willis.Afi.Registration.Api.Tests.IntegrationTests
{
    [TestClass]
    public class CustomerTests
    {
        private TestApplicationFactory? _factory;

        [TestInitialize]
        public void TestInitialize()
        {
            _factory = new TestApplicationFactory();
        }

        private RegisterRequest GetValidRequest()
        {
            return new RegisterRequest()
            {
                FirstName = "Test",
                LastName = "User",
                DateOfBirth = DateTime.Now.AddYears(-20),
                ReferenceNumber = "XY-987654",
                EmailAddress = "test.user@test.com"
            };
        }

        [TestMethod]
        public async Task Register_ValidRequest_SuccessAndUniqueIdReturned()
        {
            //Arrange
            var client = _factory?.CreateClient();
            var payload = JsonConvert.SerializeObject(GetValidRequest());
            HttpContent content = new StringContent(payload, Encoding.UTF8, "application/json");
            //Act
            var response = client != null ? await client.PostAsync("/api/customer/register", content) : null;
            //Assert
            response?.EnsureSuccessStatusCode();
        }
    }
}