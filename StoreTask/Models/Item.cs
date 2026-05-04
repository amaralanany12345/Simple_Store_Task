using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreTask.Models
{
    public class Item
    {
        public string itemName { get; set; }
        public int price { get; set; }
        public int stockQuantity { get; set; }
        public Category category { get; set; }
    }
}
