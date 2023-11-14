using Service.Services;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections_Homework_Practice.Controllers
{
    internal class EmployeeController
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController()
        {
            _employeeService = new EmployeeService();
        }

        public void GetCountByFilter()
        {
            double salary = 1500;
            DateTime startDate = new(1995, 01, 01);
            DateTime endDate = new(1999, 01, 01);
            var res = _employeeService.GetCountByFilter(startDate, endDate, salary);

            Console.WriteLine(res);
        }
    }
}
