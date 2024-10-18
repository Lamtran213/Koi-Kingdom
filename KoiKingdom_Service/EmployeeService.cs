using KoiKingdom_BusinessObject;
using KoiKingdom_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiKingdom_Service
{
    public class EmployeeService : IEmployeeService
    {
        private IEmployeeRepo iEmployeeRepo;

       public EmployeeService()
        {
            iEmployeeRepo = new EmployeeRepo();
        }

        public Employee GetEmployeeByEmail(string email)
        {
           return iEmployeeRepo.GetEmployeeByEmail(email);  
        }

        public List<Employee> GetEmployees()
        {
            return iEmployeeRepo.GetEmployees();
        }
    }
}
