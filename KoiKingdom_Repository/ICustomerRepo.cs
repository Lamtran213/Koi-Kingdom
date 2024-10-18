using KoiKingdom_BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiKingdom_Repository
{
    public interface ICustomerRepo
    {
        public Customer GetCustomerById(int id);

        public Customer GetCustomerByEmail(string email);

        public List<Customer> GetCustomers();

        public bool AddCustomerProfile(Customer customerProfile);

        public bool DeleteCustomerProfile(int customerID);

        public bool UpdateCustomerProfile(Customer customerProfile);
    }
}
