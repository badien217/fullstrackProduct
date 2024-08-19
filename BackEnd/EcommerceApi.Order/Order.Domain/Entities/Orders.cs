
using EcommerceAPI.SharedLibrary.Base;
using EcommerceAPI.SharedLibrary.Interfaces.EntityBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain.Entities
{
    public class Orders :EntityBase,IEntityBase
    {
        public int ProfileId { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string phoneNumber { get; set; }
        public decimal amount { get; set; }
        public decimal price { get; set; }
        public Orders() { }
        public Orders(int ProfileId, string name,string address, string phoneNumber, decimal amount, decimal price)
        {
            this.ProfileId = ProfileId;
            this.name = name;
            this.amount = amount;
            this.address = address;
            this.phoneNumber = phoneNumber;
            this.price = price;
        }
    }
}
