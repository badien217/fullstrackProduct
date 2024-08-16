using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductSolution.Application.Features.Products.Add
{
    public class CreateProductRequest :IRequest<Unit>
    {
        public string name { get; set; }
        public string images { get; set; }
        public string description { get; set; }
        public float sellingPrice { get; set; }
        public float mrp { get; set; }
        public int categoryId { get; set; }
    }
}
