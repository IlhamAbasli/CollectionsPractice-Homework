using Service.Services;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections_Homework_Practice.Controllers
{
    internal class ProductController
    {
        private readonly IProductService _productService;

        public ProductController()
        {
            _productService = new ProductService();
        }

        public void GetAll()
        {
            var response = _productService.GetAll();    

            foreach (var item in response)
            {
                var res = $"{item.Name} - {item.Count} - {item.Price}";
                Console.WriteLine(res);
            }
        }

        public void Search()
        {
            Console.WriteLine("Add search text");
            string searchText = Console.ReadLine();

            var response = _productService.Search(searchText);

            foreach (var item in response)
            {
                var res = $"{item.Name} - {item.Count} - {item.Price}";
                Console.WriteLine(res);
            }
        }
    }
}
