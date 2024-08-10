using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Product : EntityBase, IEntityBase
    {
        public string name { get; set; }
        public string images { get; set; }
        public string description { get; set; }
        public float sellingPrice { get; set; }
        public float mrp {  get; set; }
        public int categoryId { get; set; }
        public Category category { get; set; }
        public Product() { }
        public Product(string name,string images,string description,float sellingPrice,float mrp,int categoryId)
        {
            this.name = name;
            this.images = images;
            this.description = description;
            this.sellingPrice = sellingPrice;
            this.mrp = mrp;
            this.categoryId = categoryId;
        }
    }
}
