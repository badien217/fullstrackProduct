using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductSolution.Application.Features.Categories.GetBy
{
    public class GetByIdCategoryRequest : IRequest<GetByIdCategoryReponse>
    {
        public int Id {  get; set; }
    }
}
