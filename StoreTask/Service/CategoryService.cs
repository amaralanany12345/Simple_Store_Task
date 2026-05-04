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
            if(UploadDataService.Categories.Where(a=>a.categoryName == newCategoryName).Any())
            {
                Console.WriteLine("this category is already exist ");
            }
            else
            {
                var newCategory = new Category
                {
                    categoryName = newCategoryName,
                };
                UploadDataService.Categories.Add(newCategory);
                Console.WriteLine($"new category is added with name {newCategory.categoryName}");
            }
        }
        public void showAllCategories()
        {
            foreach (var category in UploadDataService.Categories)
            {
                Console.WriteLine($"category name is {category.categoryName}");
            }
        }
    }
}
