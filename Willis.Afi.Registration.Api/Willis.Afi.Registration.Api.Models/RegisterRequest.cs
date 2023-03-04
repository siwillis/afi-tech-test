using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Willis.Afi.Registration.Api.Models
{
    public class RegisterRequest
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? ReferenceNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? EmailAddress { get; set; }
    }
}
