using KoiKingdom_BusinessObject;
using KoiKingdom_DAOs;
using KoiKingdom_Service;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace KoiKingdomPRN_WPF
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private IEmployeeService employeeService;
        private ICustomerService customerService;
        public LoginWindow()
        {
            InitializeComponent();
            employeeService = new EmployeeService();
            customerService = new CustomerService();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

        private void btnSignIn_Click(object sender, RoutedEventArgs e)
        {
            Employee employee = employeeService.GetEmployeeByEmail(txtEmail.Text);
            Customer customer = customerService.GetCustomerByEmail(txtEmail.Text);
            if (employee != null && txtPassword.Password.Equals(employee.Password) && employee.Role.Equals("Manager"))
            {
                CustomerManagerWindow customerManagerWindow = new CustomerManagerWindow();
                customerManagerWindow.Show();
            }
            else if (customer != null && txtPassword.Password.Equals(customer.Password))
            {
                HomeWindow homeWindow = new HomeWindow();
                homeWindow.Show();
            } else
            {
                MessageBox.Show("Bye bye");
            }
                
        }

        private void txtEmail_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
