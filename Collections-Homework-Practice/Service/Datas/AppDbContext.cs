using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Service.Datas
{
    public static class AppDbContext
    {
        public static List<Author> Authors()
        {
            return new List<Author>
            {
                new Author() { Id = 1, Name = "test1", Surname = "test1", Age = 27 },
                new Author() { Id = 2, Name = "test2", Surname = "test2", Age = 25 },
                new Author() { Id = 2, Name = "test3", Surname = "test3", Age = 22 },
                new Author() { Id = 3, Name = "test4", Surname = "test4", Age = 23 }
            };
        }


        public static List<Employee> Employees()
        {
            return new List<Employee>
            {
                new Employee() { Id = 1, Name = "test1", Surname = "test1", Salary = 2000, Birthday = new(2000,01,01)},
                new Employee() { Id = 2, Name = "test2", Surname = "test2", Salary = 1500, Birthday = new(1999,01,01)},
                new Employee() { Id = 3, Name = "test3", Surname = "test3", Salary = 2500, Birthday = new(1995,01,01)},
                new Employee() { Id = 4, Name = "test4", Surname = "test4", Salary = 3000, Birthday = new(1990,01,01)},
            };
        }

        public static List<User> Users()
        {
            return new List<User>
            {
                new User() { Id = 1, Email = "123@gmail.com", Password = "123"},
            };
        }

        public static List<Product> Products()
        {
            return new List<Product>
            {
                new Product() { Id = 1, Name = "Iphone", Count = 10, Price = 2000},
                new Product() { Id = 2, Name = "Xiaomi", Count = 15, Price = 1000},
                new Product() { Id = 3, Name = "Samsung", Count = 20, Price = 1500},
            };
        }
    }
}
