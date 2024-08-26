using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceAuth.Application.Feature.Revoke
{
    public class RevokeRequest :IRequest<Unit>
    {
        public string Email { get; set; }
    }
}
