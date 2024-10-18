using KoiKingdom_BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiKingdom_DAOs
{
    public class EmployeeDAO
    {
        private KOI_PRNContext dbContext;

        // Singleton instance
        private static EmployeeDAO instance = null;

        // Singleton property
        public static EmployeeDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new EmployeeDAO();
                }
                return instance;
            }
        }

        // Constructor
        public EmployeeDAO()
        {
            dbContext = new KOI_PRNContext();
        }

        // Method to get employee by email
        public Employee GetEmployeeByEmail(string email)
        {
            return dbContext.Employees.SingleOrDefault(e => e.Email.Equals(email));
        }

        public List<Employee> GetEmployees()
        {
            return dbContext.Employees.ToList();
        }
    }
}