using Service.Datas;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class AccountService : IAccountService
    {
        public bool Login(string username, string password)
        {
            var res = AppDbContext.Users().Exists(x => x.Email == username && x.Password == password);
            return res;
        }
    }
}
