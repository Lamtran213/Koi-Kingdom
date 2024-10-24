﻿using KoiKingdom_BusinessObject;
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
    }
}