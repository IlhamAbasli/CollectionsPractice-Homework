using Service.Services;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections_Homework_Practice.Controllers
{
    internal class AccountController
    {
        private readonly IAccountService _accountService;

        public AccountController()
        {
            _accountService = new AccountService();
        }

        public bool Login()
        {
            Console.WriteLine("Enter email");
            Email: string email = Console.ReadLine();

            Console.WriteLine("Enter password");
            string password = Console.ReadLine();   


            bool response = _accountService.Login(email, password);
            
            if(!response)
            {
                Console.WriteLine("Email or password is wrong, please try again");
                goto Email;
            }
            return true;
        }
    }
}
