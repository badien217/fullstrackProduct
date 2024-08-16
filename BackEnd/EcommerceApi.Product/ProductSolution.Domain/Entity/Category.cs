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
        public Category() { }
        public Category(string name, string images, string description)
        {
            this.name = name;
            this.images = images;
            this.description = description;
        }
    }
}
