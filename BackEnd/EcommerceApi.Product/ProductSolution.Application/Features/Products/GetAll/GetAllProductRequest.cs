using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductSolution.Application.Features.Products.GetAll
{
    public class GetAllProductRequest :IRequest<IList<GetAllProductReponse>>
    {
    }
}
