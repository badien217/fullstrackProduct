using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceAuth.Application.Feature.Profiles.Delete
{
    public class DeleteProfileRequest :IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
