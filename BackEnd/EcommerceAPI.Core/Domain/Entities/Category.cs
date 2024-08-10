using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Category :EntityBase,IEntityBase
    {
        public string name {  get; set; }
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
