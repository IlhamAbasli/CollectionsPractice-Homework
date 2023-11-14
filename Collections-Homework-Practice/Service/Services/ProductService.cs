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
    public class ProductService : IProductService
    {
        public List<Product> GetAll()
        {
            return AppDbContext.Products();
        }

        public List<Product> Search(string searchText)
        {
            return AppDbContext.Products().Where(x => x.Name.Contains(searchText)).ToList();
        }
    }
}
