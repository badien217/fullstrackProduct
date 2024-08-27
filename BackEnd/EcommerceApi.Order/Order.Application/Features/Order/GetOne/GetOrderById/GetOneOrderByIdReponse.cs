using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Application.Features.Order.GetOne.GetOrderById
{
    public class GetOneOrderByIdReponse
    {
        public int ProfileId { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string phoneNumber { get; set; }
        public decimal amount { get; set; }
        public IList<int> ProductId { get; set; }
        public bool status { get; set; }
        public decimal price { get; set; }
    }
}
