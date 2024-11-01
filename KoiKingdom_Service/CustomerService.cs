using KoiKingdom_BusinessObject;
using KoiKingdom_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiKingdom_Service
{
    public class CustomerService : ICustomerService
    {
        private ICustomerRepo customerRepo;

        public CustomerService()
        {
            customerRepo = new CustomerRepo();
        }

        public bool AddCustomerProfile(Customer customerProfile)
        {
            return customerRepo.AddCustomerProfile(customerProfile);
        }

        public bool DeleteCustomerProfile(int customerID)
        {
            return customerRepo.DeleteCustomerProfile(customerID);
        }

        public Customer GetCustomerById(int id)
        {
            return customerRepo.GetCustomerById(id);
        }

        public Customer GetCustomerByEmail(string email)
        {
            return customerRepo.GetCustomerByEmail(email);
        }

        public List<Customer> GetCustomers()
        {
            return customerRepo.GetCustomers();
        }

        public bool UpdateCustomerProfile(Customer customerProfile)
        {
            return customerRepo.UpdateCustomerProfile(customerProfile); 
        }


        public bool UpdateProfile(int CustomerId, string Email, string Password, string LastName, string FirstName, string? Address, string? AccountType, bool? Status)
        {
            return customerRepo.UpdateProfile(CustomerId, Email, Password, LastName, FirstName, Address, AccountType, Status);
        }

    }
}
