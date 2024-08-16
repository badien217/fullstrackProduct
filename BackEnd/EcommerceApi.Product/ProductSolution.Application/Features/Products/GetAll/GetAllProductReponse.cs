using ProductSolution.Application.DTOs.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductSolution.Application.Features.Products.GetAll
{
    public class GetAllProductReponse
    {
        public string name { get; set; }
        public string images { get; set; }
        public string description { get; set; }
        public float sellingPrice { get; set; }
        public float mrp { get; set; }
        public CategoryDto category { get; set; }
    }
}
