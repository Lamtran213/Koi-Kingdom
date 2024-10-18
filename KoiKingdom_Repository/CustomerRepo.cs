using KoiKingdom_BusinessObject;
using KoiKingdom_DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiKingdom_Repository
{
    public class CustomerRepo : ICustomerRepo
    {
        public bool AddCustomerProfile(Customer customerProfile)=>CustomerDAO.Instance.AddCustomerProfile(customerProfile); 

        public bool DeleteCustomerProfile(int customerID) => CustomerDAO.Instance.DeleteCustomerProfile(customerID);
        
        public Customer GetCustomerById(int id) => CustomerDAO.Instance.GetCustomerById(id);

        public Customer GetCustomerByEmail(string email)=> CustomerDAO.Instance.GetCustomerByEmail(email);

        public List<Customer> GetCustomers() =>CustomerDAO.Instance.GetCustomers();
   
        public bool UpdateCustomerProfile(Customer customerProfile) => CustomerDAO.Instance.UpdateCustomerProfile(customerProfile);
    }
}
