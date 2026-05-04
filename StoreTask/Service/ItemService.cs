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
            if (newItemCategory == null)
            {
                Console.WriteLine("category is not found");
            }
            else
            {
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
            }
        }
        public void showItems()
        {
            foreach (var item in uploadDataService.Items)
            {
                Console.WriteLine($"item name is {item.itemName}, price {item.price}," +
                    $" stock {item.stockQuantity} , category is {item.category.categoryName} ");
            }
        }

        public void showItemByCategory()
        {
            Console.WriteLine("enter your the name of category");
            var categoryName=Console.ReadLine();
            var items=uploadDataService.Items.Where(a=>a.category.categoryName == categoryName).ToList();
            foreach(var item in items)
            {
                Console.WriteLine($"item name is {item.itemName}, price {item.price}," +
                    $" stock {item.stockQuantity} , category is {item.category.categoryName} ");
            }
        }
    }
}
