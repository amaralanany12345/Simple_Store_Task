using StoreTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace StoreTask.Service
{
    public class OrderService
    {
        public UploadDataService UploadDataService;
        public OrderService(UploadDataService UploadDataService)
        {
            this.UploadDataService = UploadDataService;
        }
        public void AddOrder(Customer customer)
        {
            Console.WriteLine("enter order name");
            var newOrderName = Console.ReadLine();
            var newOrder = new Order();
            UploadDataService.Orders.Add(newOrder);
            newOrder.ordName = newOrderName;
            newOrder.customer= customer;
            addItemToOrder(newOrder);
            File.WriteAllText($"D:\\store orders\\{newOrder.ordName}.txt", JsonSerializer.Serialize<Order>(newOrder));

        }
        public void addItemToOrder(Order newOrder)
        {
            Console.WriteLine("add item name");
            var itemName = Console.ReadLine();
            var item = UploadDataService.Items.Where(a => a.itemName == itemName).FirstOrDefault();
            if (item == null)
            {
                Console.WriteLine("item is not found");
            }
            else
            {

                newOrder.orderItem = item;
                Console.WriteLine("enter your needed stock");
                var stock = int.Parse(Console.ReadLine());

                if (newOrder.orderItem.stockQuantity < stock)
                {
                    Console.WriteLine("there is not enough stock");
                }
                else
                {
                    newOrder.orderQuantity = stock;
                    newOrder.orderPrice = item.price * stock;
                    if (newOrder.customer.balance < newOrder.orderPrice)
                    {
                        Console.WriteLine("your balance is not enough");
                    }
                    else
                    {
                        newOrder.customer.balance -= newOrder.orderPrice;
                        newOrder.orderItem.stockQuantity -= stock;
                    }
                }
            }
        }
   }
}
