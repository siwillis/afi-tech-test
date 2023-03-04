using AutoMapper;
using Willis.Afi.Registration.Api.DataAccess;
using Willis.Afi.Registration.Api.DataAccess.Entities;
using Willis.Afi.Registration.Api.Models;
using Willis.Afi.Registration.Api.Services.Interfaces;

namespace Willis.Afi.Registration.Api.Services
{
    public class CustomerService : ICustomerService
    {

        private readonly IMapper _mapper;
        private readonly DataContext _dataContext;

        public CustomerService(IMapper mapper, DataContext dataContext) 
        {
            _mapper = mapper;
            _dataContext = dataContext;
        }

        public RegisterResponse Register(RegisterRequest request)
        {
            var customer = _mapper.Map<Customer>(request);

            _dataContext.Add(customer);
            _dataContext.SaveChanges();

            return new RegisterResponse() { CustomerId = customer.Id };
        }
    }
}
