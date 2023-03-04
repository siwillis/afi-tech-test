using Willis.Afi.Registration.Api.Models;
using Willis.Afi.Registration.Api.Services.Interfaces;

namespace Willis.Afi.Registration.Api.Services
{
    public class CustomerService : ICustomerService
    {
        public RegisterResponse Register(RegisterRequest request)
        {
            return new RegisterResponse();
        }
    }
}
