
using EcommerceAPI.SharedLibrary.Base;
using EcommerceAPI.SharedLibrary.Interfaces.EntityBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain.Entities
{
    public class OrderDetail :EntityBase, IEntityBase
    {
        public int orderId { get; set; }
        public Orders order { get; set; }
        public int productId { get; set; }
        
        public bool status { get; set; }
        public OrderDetail() { }
        public OrderDetail(int orderId, int productId)
        {
            this.orderId = orderId;
            this.productId = productId;
         
        }
    }
}
