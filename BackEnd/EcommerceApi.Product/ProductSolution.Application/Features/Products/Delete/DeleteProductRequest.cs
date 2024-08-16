using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductSolution.Application.Features.Products.Delete
{
    public class DeleteProductRequest :IRequest<Unit>
    {
        public int Id {  get; set; }
    }
}
