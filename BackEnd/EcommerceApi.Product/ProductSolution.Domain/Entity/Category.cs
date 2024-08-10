using EcommerceAPI.SharedLibrary.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductSolution.Domain.Entity
{
    public class Category :EntityBase
    {
        public string name { get; set; }
        public string images { get; set; }
        public string description { get; set; }
    }
}
