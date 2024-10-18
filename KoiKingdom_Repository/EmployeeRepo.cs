using KoiKingdom_BusinessObject;
using KoiKingdom_DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiKingdom_Repository
{
    public class EmployeeRepo : IEmployeeRepo
    {
        public Employee GetEmployeeByEmail(string email)=>EmployeeDAO.Instance.GetEmployeeByEmail(email);

        public List<Employee> GetEmployees()=> EmployeeDAO.Instance.GetEmployees();
    }
}
