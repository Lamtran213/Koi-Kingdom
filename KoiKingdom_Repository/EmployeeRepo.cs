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
        public Employee GetEmployeeById(int id) => EmployeeDAO.Instance.GetEmployeeById(id);

        public Employee GetEmployeeByEmail(string email)=>EmployeeDAO.Instance.GetEmployeeByEmail(email);

        public List<Employee> GetEmployees()=> EmployeeDAO.Instance.GetEmployees();

        public bool UpdateEmployeeProfile(Employee EmployeeProfile) => EmployeeDAO.Instance.UpdateEmployeeProfile(EmployeeProfile);
        public Employee AddEmployeeProfile(string email, string password, string address, string role, string lastName, string firstName, bool status = true) => EmployeeDAO.Instance.AddEmployeeProfile(email, password, address, role, lastName, firstName, status);

        public bool UpdateProfile(int EmployeeId, string Email, string Password, string Role, string LastName, string FirstName, string? Address, bool? Status) => EmployeeDAO.Instance.UpdateProfile( EmployeeId,  Email,  Password,  Role,  LastName,  FirstName,   Address,   Status);

    }
}
