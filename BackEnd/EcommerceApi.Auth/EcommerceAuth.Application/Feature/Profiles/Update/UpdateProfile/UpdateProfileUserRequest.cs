using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceAuth.Application.Feature.Profiles.Update.UpdateProfile
{
    public class UpdateProfileUserRequest : IRequest<Unit>
    {

        public Guid UserId { get; set; }
        public string Phone { get; set; }
        public string age { get; set; }
        public string Email { get; set; }
        public string Address { get; set; } 
        public IFormFile avatar { get; set; }
    }
}
