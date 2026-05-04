using StoreTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreTask.Service
{
    public class ItemService
    {
        public UploadDataService uploadDataService;
        public ItemService(UploadDataService UploadDataService)
        {
            this.uploadDataService = UploadDataService;
        }
        public void addNewItem()
        {
            Console.WriteLine("enter item category name");
            var newItemCategoryName = Console.ReadLine();
            var newItemCategory = uploadDataService.Categories.Where(a => a.categoryName == newItemCategoryName).FirstOrDefault();
            while(newItemCategory==null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Category is not found, please add another category name");
                Console.ForegroundColor = ConsoleColor.White;
                newItemCategoryName = Console.ReadLine();
                newItemCategory = uploadDataService.Categories.Where(a => a.categoryName == newItemCategoryName).FirstOrDefault();

            }
            Console.WriteLine("enter item name");
                var newItemName = Console.ReadLine();

                Console.WriteLine("enter item price");
                var newItemPrice = int.Parse(Console.ReadLine());

                Console.WriteLine("enter item stock quantity");
                var newItemStock = int.Parse(Console.ReadLine());

                var newItem = new Item
                {
                    itemName = newItemName,
                    price = newItemPrice,
                    stockQuantity = newItemStock,
                    category = newItemCategory,

                };
                uploadDataService.AddDataToItems(newItem);
            Console.ForegroundColor= ConsoleColor.Green;
                Console.WriteLine($"new item is added with name {newItem.itemName}, price" +
                    $" {newItem.price}, stock is {newItem.stockQuantity}");
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void showItems()
        {
            foreach (var item in uploadDataService.Items)
            {
                Console.ForegroundColor=ConsoleColor.Green;
                Console.WriteLine($"item name is {item.itemName}, price {item.price}," +
                    $" stock {item.stockQuantity} , category is {item.category.categoryName} ");
                Console.ForegroundColor=ConsoleColor.White;
            }
        }

        public void showItemByCategory()
        {
            Console.WriteLine("enter your the name of category");
            var categoryName=Console.ReadLine();
            while(!uploadDataService.Categories.Where(a=>a.categoryName == categoryName).Any())
            {
                Console.ForegroundColor=ConsoleColor.Red;
                Console.WriteLine("category is not found");
                Console.ForegroundColor = ConsoleColor.White;
                categoryName = Console.ReadLine();

            }
            var items=uploadDataService.Items.Where(a=>a.category.categoryName == categoryName).ToList();
            foreach(var item in items)
            {
                Console.ForegroundColor=ConsoleColor.Green;
                Console.WriteLine($"item name is {item.itemName}, price {item.price}," +
                    $" stock {item.stockQuantity} , category is {item.category.categoryName} ");
                Console.ForegroundColor=ConsoleColor.White;
            }
        }
    }
}
