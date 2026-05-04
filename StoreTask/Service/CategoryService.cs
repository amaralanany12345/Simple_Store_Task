using StoreTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreTask.Service
{
    public class CategoryService
    {
        public UploadDataService UploadDataService;
        public CategoryService(UploadDataService UploadDataService)
        {
            this.UploadDataService = UploadDataService;
        }
        public void AddCategory()
        {
            Console.WriteLine("enter category Name");
            var newCategoryName = Console.ReadLine();
            while(UploadDataService.Categories.Where(a=>a.categoryName == newCategoryName).Any())
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("this category is already exist, please add another category name ");
                Console.ForegroundColor = ConsoleColor.White;
                newCategoryName = Console.ReadLine();
            };

            var newCategory = new Category
            {
                categoryName = newCategoryName,
            };
            UploadDataService.Categories.Add(newCategory);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"new category is added with name {newCategory.categoryName}");
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void showAllCategories()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            foreach (var category in UploadDataService.Categories)
            {
                Console.WriteLine($"category name is {category.categoryName}");
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
