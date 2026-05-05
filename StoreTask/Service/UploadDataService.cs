using StoreTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreTask.Service
{
    public class UploadDataService
    {
        public List<Item> Items { get; set; }
        public List<Order> Orders { get; set; }
        public List<User> Users { get; set; }
        public List<Category> Categories { get; set; }
        public UploadDataService()
        {
            Users = new List<User>
            {
                new Admin { userName = "ammar mostafa", email = "ammar@gmail.com" },
                new Customer { userName = "saad mohamed", email = "saad", balance=2000 },
                new Admin { userName = "ali abdo", email = "ali@gmail.com" },
                new Customer { userName = "mohamed ahmed", email = ",mohamed@gmail.com", balance =1000 },
            };

            var bookCategory = new Category { categoryName = "books" };
            var electronicCategory = new Category { categoryName = "electronics" };

            Categories = new List<Category>
            {
                bookCategory,
                electronicCategory
            };

            Items = new List<Item>
            {
                new Item{itemName="prd1",price=100,stockQuantity=50,category=bookCategory},
                new Item{itemName="prd2",price=250,stockQuantity=20,category=electronicCategory},
                new Item{itemName="prd3",price=370,stockQuantity=40,category=bookCategory},
                new Item{itemName="prd4",price=900,stockQuantity=100,category=electronicCategory},
            };
            Orders = new List<Order>();
        }
        public void AddDataToItems(Item item)
        {
            Items.Add(item);
        }
    }
}
