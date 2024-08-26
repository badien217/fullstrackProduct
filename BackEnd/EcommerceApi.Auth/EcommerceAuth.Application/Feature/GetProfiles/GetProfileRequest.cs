using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceAuth.Application.Feature.GetProfiles
{
    public class GetProfileRequest :IRequest<GetProfileReponse>
    {
        public int Id { get; set; }
    }
}
