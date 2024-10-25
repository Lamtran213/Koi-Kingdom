using KoiKingdom_BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KoiKingdom_DAOs
{
    public class CustomerDAO
    {
        private KOI_PRNContext dbContext;
        private static CustomerDAO instance;

        public CustomerDAO()
        {
            dbContext = new KOI_PRNContext();
        }

        // Singleton Pattern
        public static CustomerDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CustomerDAO();
                }
                return instance;
            }
        }

        public Customer CurrentCustomer { get; set; }


        // Lấy khách hàng theo ID
        public Customer GetCustomerById(int id)
        {
            return dbContext.Customers.SingleOrDefault(e => e.CustomerId == id);
        }

        // Lấy khách hàng theo Email
        public Customer GetCustomerByEmail(string email)
        {
            return dbContext.Customers.SingleOrDefault(e => e.Email.Equals(email));
        }


        // Lấy danh sách tất cả khách hàng
        public List<Customer> GetCustomers()
        {
            return dbContext.Customers.ToList();
        }

        // Thêm hồ sơ khách hàng
        public bool AddCustomerProfile(Customer customerProfile)
        {
            bool isSuccess = false;
            try
            {
                if (customerProfile != null)
                {
                    Customer existingCustomer = this.GetCustomerById(customerProfile.CustomerId);
                    if (existingCustomer == null) // Chỉ thêm nếu chưa tồn tại
                    {
                        dbContext.Customers.Add(customerProfile);
                        dbContext.SaveChanges();
                        isSuccess = true;
                    }
                    else
                    {
                        throw new Exception("Customer already exists.");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while adding the customer: " + ex.Message);
            }
            return isSuccess;
        }

        // Xóa hồ sơ khách hàng theo ID
        public bool DeleteCustomerProfile(int customerID)
        {
            bool isSuccess = false;
            try
            {
                Customer customerProfile = this.GetCustomerById(customerID);
                if (customerProfile != null)
                {
                    dbContext.Customers.Remove(customerProfile);
                    dbContext.SaveChanges();
                    isSuccess = true;
                }
                else
                {
                    throw new Exception("Customer not found.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while deleting the customer: " + ex.Message);
            }
            return isSuccess;
        }

        // Cập nhật hồ sơ khách hàng
        public bool UpdateCustomerProfile(Customer customerProfile)
        {
            bool isSuccess = false;
            try
            {
                Customer existingCustomer = this.GetCustomerById(customerProfile.CustomerId);
                if (existingCustomer != null)
                {
                    dbContext.Entry(existingCustomer).CurrentValues.SetValues(customerProfile);
                    dbContext.SaveChanges();
                    isSuccess = true;
                }
                else
                {
                    throw new Exception("Customer not found.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating the customer: " + ex.Message);
            }
            return isSuccess;
        }
    }
}
