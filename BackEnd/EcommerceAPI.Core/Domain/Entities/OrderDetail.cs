using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class OrderDetail : EntityBase, IEntityBase
    { 
        public int orderId { get; set; }
        public Order order { get; set; }
        public int productId { get; set; }
        public ICollection<Product> products;
        public int quantity { get; set; }
        public OrderDetail() { }
        public OrderDetail(int orderId,int productId,int quantity) {
            this.orderId = orderId;
            this.productId = productId;
            this.quantity = quantity;
        }
    }
}
