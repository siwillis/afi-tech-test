using AutoMapper;
using Willis.Afi.Registration.Api.DataAccess.Entities;
using Willis.Afi.Registration.Api.Models;
using Willis.Afi.Registration.Api.Services.Interfaces;

namespace Willis.Afi.Registration.Api.Services
{
    public class CustomerService : ICustomerService
    {

        private readonly IMapper _mapper;

        public CustomerService(IMapper mapper) 
        {
            _mapper = mapper;
        }

        public RegisterResponse Register(RegisterRequest request)
        {
            var customer = _mapper.Map<Customer>(request);

            return new RegisterResponse();
        }
    }
}
