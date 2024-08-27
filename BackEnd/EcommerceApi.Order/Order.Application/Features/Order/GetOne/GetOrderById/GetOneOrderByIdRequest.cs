using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Application.Features.Order.GetOne.GetOrderById
{
    public class GetOneOrderByIdRequest : IRequest<GetOneOrderByIdReponse>
    {
        public int Id { get; set; }
    }
}
