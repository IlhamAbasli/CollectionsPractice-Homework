using Domain.Models;
using Service.Datas;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class AuthorService : IAuthorService
    {
        public List<Author> GetAllByAge(int age)
        {
            return AppDbContext.Authors().Where( x => x.Age > age ).ToList();
        }
    }
}
