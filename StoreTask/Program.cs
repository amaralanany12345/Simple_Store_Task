
using StoreTask.Models;
using StoreTask.Service;
using System.Security.Cryptography.X509Certificates;

namespace StoreTask
{
    public class program
    {
        static void Main()
        {
            var uploadDataService=new UploadDataService();
            var categoryService = new CategoryService(uploadDataService);
            var itemService = new ItemService(uploadDataService);
            var userService = new UserService(uploadDataService);
            var orderService=new OrderService(uploadDataService);

            Console.WriteLine("1 login");
            Console.WriteLine("2 exit");
            var entry=Console.ReadLine();
            if (entry == "1")
            {
                var user=userService.login();
                while(true)
                {
                    if (user is Admin)
                    {
                        Console.WriteLine();
                        Console.WriteLine($"admin is {user.userName}");
                        Console.WriteLine("-------------");
                        Console.WriteLine();
                        Console.WriteLine("1 show categories");
                        Console.WriteLine("2 show items");
                        Console.WriteLine("3 add category");
                        Console.WriteLine("4 add item");
                        Console.WriteLine("5 log out");
                        Console.WriteLine("6 finish the program");
                        var adminChoice = Console.ReadLine();
                        switch (adminChoice)
                        {
                            case "1":
                                categoryService.showAllCategories();
                                break;
                            case "2":
                                itemService.showItems();
                                break;
                            case "3":
                                categoryService.AddCategory();
                                break;
                            case "4":
                                itemService.addNewItem();
                                break;
                            case "5":
                                Console.WriteLine("you are logged out");
                                user=userService.login();
                                break;
                            case "6":
                                return;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        var newCustomer = new Customer();
                        newCustomer = user as Customer;
                        Console.WriteLine();
                        Console.WriteLine($"customer is {newCustomer.userName}, balance is {newCustomer.balance} ");
                        Console.WriteLine("-------------");
                        Console.WriteLine();
                        Console.WriteLine("1 view all categories");
                        Console.WriteLine("2 show items");
                        Console.WriteLine("3 show items by category");
                        Console.WriteLine("4 add order");
                        Console.WriteLine("5 log out");
                        Console.WriteLine("6 finish the program");

                        var customerChoice = Console.ReadLine();
                        switch (customerChoice)
                        {
                            case "1":
                                categoryService.showAllCategories();
                                break;
                            case "2":
                                itemService.showItems();
                                break;
                            case "3":
                                itemService.showItemByCategory();
                                break;
                            case "4":
                                
                                orderService.AddOrder(newCustomer);
                                break;
                            case "5":
                                Console.WriteLine("you are logged out");
                                user=userService.login();
                                break;
                            case "6":
                                return;
                            default:
                                break;
                        }
                    }
                }
            }
        }

    }
}