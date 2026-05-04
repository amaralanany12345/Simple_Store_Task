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
            //UploadDataService.Orders.Add(newOrder);
            newOrder.ordName = newOrderName;
            newOrder.customer= customer;
            Console.WriteLine("add item name");
            var itemName = Console.ReadLine();
            var item = UploadDataService.Items.Where(a => a.itemName == itemName).FirstOrDefault();
            while (item == null || item.stockQuantity == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("item is not found, please another one");
                Console.ForegroundColor=ConsoleColor.White;
                itemName = Console.ReadLine();
                item = UploadDataService.Items.Where(a => a.itemName == itemName).FirstOrDefault();
            };
            newOrder.orderItem = item;
            Console.WriteLine("enter your needed stock");
            var stock = int.Parse(Console.ReadLine());

            while (newOrder.orderItem.stockQuantity < stock)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("there is not enough stock, please add suitable stock");
                Console.ForegroundColor=ConsoleColor.White;
                stock = int.Parse(Console.ReadLine());
            };
            newOrder.orderQuantity = stock;
            newOrder.orderPrice = item.price * stock;
            if (newOrder.customer.balance < newOrder.orderPrice)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("your balance is not enough");
                Console.ForegroundColor=ConsoleColor.White;
            }
            else
            {
                newOrder.customer.balance -= newOrder.orderPrice;
                newOrder.orderItem.stockQuantity -= stock;
                UploadDataService.Orders.Add(newOrder);
                Console.ForegroundColor=ConsoleColor.Green;
                Console.WriteLine($"new order is added with {newOrder.orderItem.itemName}," +
                $" order name {newOrder.ordName}, quantity is {newOrder.orderQuantity}, price is {newOrder.orderPrice}");
                Console.ForegroundColor=ConsoleColor.White;
                File.WriteAllText($"D:\\store orders\\{newOrder.ordName}.txt", JsonSerializer.Serialize<Order>(newOrder));
            }

        }
   }
}
