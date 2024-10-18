using KoiKingdom_BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiKingdom_Repository
{
    public interface IEmployeeRepo
    {

        public Employee GetEmployeeByEmail(string email);

        public List<Employee> GetEmployees();
    }
}
