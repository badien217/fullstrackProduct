using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Order : EntityBase, IEntityBase
    {
        public int ProfileId { get; set; }
        public UserProfiles Profile { get; set; }
        public string address { get; set; }
        public string phoneNumber { get; set; }
        public decimal amount { get; set; }
        public Order() { }
        public Order(int ProfiledId,string address,string phoneNumber,decimal amount)
        {
            this.ProfileId = ProfiledId;
            this.amount = amount;
            this.address = address;
            this.phoneNumber = phoneNumber;
            
        }
    }
}
