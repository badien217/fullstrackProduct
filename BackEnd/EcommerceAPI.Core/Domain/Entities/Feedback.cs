using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Feedback : EntityBase, IEntityBase
    {
        public string name {  get; set; }
        public string email { get; set; }
        public Feedback() { }
        public Feedback(string name, string email) { 
            this.name = name;
            this.email = email;
        }
    }
}
