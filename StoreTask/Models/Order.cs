using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreTask.Models
{
    public class Order
    {
        public string ordName { get; set; }
        public Customer customer { get; set; }
        public Item orderItem { get; set; }
        public int orderQuantity { get;set; }
        public int orderPrice { get; set; }
    }
}
