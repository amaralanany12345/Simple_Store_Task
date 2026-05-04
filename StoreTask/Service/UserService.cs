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
            if(user == null)
            {
                Console.WriteLine("user is not found");
            }
            return user;
        }

        public void showUsers()
        {
            foreach(var user in UploadDataService.Users)
            {
                Console.WriteLine(user.userName);
            }
        }
    }
}
