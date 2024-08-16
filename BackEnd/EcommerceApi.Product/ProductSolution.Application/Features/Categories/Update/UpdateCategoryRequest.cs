using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductSolution.Application.Features.Categories.Update
{
    public class UpdateCategoryRequest : IRequest<Unit>
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string images { get; set; }
        public string description { get; set; }
    }
}
