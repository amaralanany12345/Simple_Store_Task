using StoreTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreTask.Service
{
    public class UserService
    {
        public UploadDataService UploadDataService;
        public UserService(UploadDataService UploadDataService)
        {
            this.UploadDataService = UploadDataService;
        }

        public User login()
        {
            Console.WriteLine("enter your email");
            var userEmail = Console.ReadLine();
            var user= UploadDataService.Users.Where(a=>a.email == userEmail).FirstOrDefault();
            while(user == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("user is not found, please add another email");
                Console.ForegroundColor=ConsoleColor.White;
                userEmail = Console.ReadLine();
                user= UploadDataService.Users.Where(a=>a.email == userEmail).FirstOrDefault();
            }
            return user;
        }
    }
}
