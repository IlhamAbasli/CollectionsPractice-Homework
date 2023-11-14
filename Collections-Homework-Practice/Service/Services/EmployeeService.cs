using Service.Datas;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class EmployeeService : IEmployeeService
    {
        public int GetCountByFilter(DateTime startDate, DateTime endDate, double salary)
        {
            return AppDbContext.Employees().Where(x => x.Birthday >= startDate && x.Birthday <= endDate && x.Salary >= salary).Count();
        }
    }
}
