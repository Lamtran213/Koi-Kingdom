﻿using KoiKingdom_BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiKingdom_Service
{
    public interface IEmployeeService
    {
        public Employee GetEmployeeById(int id);

        public Employee GetEmployeeByEmail(string email);

        public List<Employee> GetEmployees();

        public bool UpdateEmployeeProfile(Employee EmployeeProfile);
    }
}
