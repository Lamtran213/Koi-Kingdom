using KoiKingdom_BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiKingdom_Service
{
    public interface ICustomerService
    {
        public Customer GetCustomerById(int id);

        public Customer GetCustomerByEmail(string email);

        public List<Customer> GetCustomers();

        public bool AddCustomerProfile(Customer customerProfile);

        public bool DeleteCustomerProfile(int customerID);

        public bool UpdateCustomerProfile(Customer customerProfile);

        public bool UpdateProfile(int CustomerId, string Email, string Password, string LastName, string FirstName, string? Address, string? AccountType, bool? Status);

    }
}
