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

        public Employee CurrentEmployee { get; set; }
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

        public Employee GetEmployeeById(int id)
        {
            return dbContext.Employees.SingleOrDefault(e => e.EmployeeId == id);
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

        public List<Customer> GetCustomerByList()
        {
            return dbContext.Customers.ToList();
        }

       public Customer GetCustomer(int customerId)
        {
            return dbContext.Customers.SingleOrDefault(e => e.CustomerId == customerId);
        }

        public bool UpdateEmployeeProfile(Employee EmployeeProfile)
        {
            bool isSuccess = false;
            try
            {
                Employee existingEmployee = this.GetEmployeeById(EmployeeProfile.EmployeeId);
                if (existingEmployee != null)
                {
                    dbContext.Entry(existingEmployee).CurrentValues.SetValues(EmployeeProfile);
                    dbContext.SaveChanges();
                    isSuccess = true;
                }
                else
                {
                    throw new Exception("Employee not found.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating the Employee: " + ex.Message);
            }
            return isSuccess;
        }

        public Employee AddEmployeeProfile(string email, string password, string address, string role, string lastName, string firstName, bool status = true)
        {
            try
            {
                Employee existingEmployee = this.GetEmployeeByEmail(email);
                if (existingEmployee == null) 
                {
                    // Create a new employee object
                    Employee newEmployee = new Employee
                    {
                        Email = email,
                        Password = password,
                        Address = address,
                        Role = role,
                        LastName = lastName,
                        FirstName = firstName,
                        Status = status
                    };

                    // Add the new employee to the database
                    dbContext.Employees.Add(newEmployee);
                    dbContext.SaveChanges();
                    return newEmployee;
                }
                else
                {
                    throw new Exception("Employee already exists.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while adding the Employee: " + ex.Message);
            }
        }

        public bool UpdateProfile(int EmployeeId, string Email, string Password, string Role, string LastName, string FirstName, string? Address, bool? Status)
        {
            bool isSuccess = false;
            try
            {
                // Create a new Employee object with the updated values
                Employee updatedEmployee = new Employee
                {
                    EmployeeId = EmployeeId,
                    Email = Email,
                    Password = Password,
                    Role = Role,
                    LastName = LastName,
                    FirstName = FirstName,
                    Address = Address,
                    Status = Status,
                };

                // Retrieve the existing employee from the database
                Employee existingEmployee = this.GetEmployeeById(updatedEmployee.EmployeeId);
                if (existingEmployee != null)
                {
                    // Update the existing employee's properties with the new values
                    dbContext.Entry(existingEmployee).CurrentValues.SetValues(updatedEmployee);
                    dbContext.SaveChanges();
                    isSuccess = true;
                }
                else
                {
                    throw new Exception("Employee not found.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating the employee: " + ex.Message);
            }
            return isSuccess;
        }


    }
}