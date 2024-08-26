using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Application.Features.Order.GetAll
{
    public class GetAllOrderRequest : IRequest<IList<GetAllOrderReponse>>
    {

    }
}
