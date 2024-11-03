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

        public Employee GetEmployeeById(int id)
        {
            return iEmployeeRepo.GetEmployeeById(id);
        }

        public List<Employee> GetEmployees()
        {
            return iEmployeeRepo.GetEmployees();
        }

        public bool UpdateEmployeeProfile(Employee EmployeeProfile)
        {
            return iEmployeeRepo.UpdateEmployeeProfile(EmployeeProfile);
        }
        public Employee AddEmployeeProfile(string email, string password, string address, string role, string lastName, string firstName, bool status = true)
        {
            return iEmployeeRepo.AddEmployeeProfile(email, password, address, role, lastName, firstName, status);
        }

        public bool UpdateProfile(int EmployeeId, string Email, string Password, string Role, string LastName, string FirstName, string? Address, bool? Status)
        {
            return iEmployeeRepo.UpdateProfile(EmployeeId, Email, Password, Role, LastName, FirstName, Address, Status);
        }

        public List<Customer> GetCustomer()
        {
            throw new NotImplementedException();
        }
    }
}
