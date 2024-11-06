using KoiKingdom_BusinessObject;
using KoiKingdom_DAOs;
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

        public Employee GetEmployeeById(int id);

        public List<Customer> GetCustomerByList();

        public Employee GetEmployeeByEmail(string email);

        public List<Employee> GetEmployees();

        public bool UpdateEmployeeProfile(Employee EmployeeProfile);
        public Employee AddEmployeeProfile(string email, string password, string address, string role, string lastName, string firstName, bool status = true);

        public bool UpdateProfile(int EmployeeId, string Email, string Password, string Role, string LastName, string FirstName, string? Address, bool? Status);

    }
}
