using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System;
using Willis.Afi.Registration.Api.Models;
using Willis.Afi.Registration.Api.Services.Interfaces;
using FluentValidation.Results;

namespace Willis.Afi.Registration.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        private readonly IValidator<RegisterRequest> _validator;
        private readonly ICustomerService _customerService;

        public CustomerController(IValidator<RegisterRequest> validator, ICustomerService customerService)
        {
            this._validator = validator;
            this._customerService = customerService;
        }

        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<RegisterResponse>> Register(RegisterRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.ToDictionary());
            }

            var response = _customerService.Register(request);

            return Ok(response);
        }

    }
}
