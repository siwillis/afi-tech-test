using Willis.Afi.Registration.Api.Models;

namespace Willis.Afi.Registration.Api.Services.Interfaces
{
    public interface ICustomerService
    {
        RegisterResponse Register(RegisterRequest request);
    }
}