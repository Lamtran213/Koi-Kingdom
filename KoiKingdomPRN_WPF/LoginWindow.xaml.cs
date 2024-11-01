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

            // Xử lý khi Employee đăng nhập
            if (employee != null && txtPassword.Password.Equals(employee.Password) && employee.Role.Equals("Manager"))
            {
                ManagerWindow managerWindow = new ManagerWindow(employee);
                managerWindow.Show();
                this.Close();  // Đóng cửa sổ đăng nhập sau khi đăng nhập thành công
            }
            // Xử lý khi Customer đăng nhập
            else if (customer != null && txtPassword.Password.Equals(customer.Password))
            {
                if (customer.Status == true)
                {
                    // Chỉ cần khởi tạo HomeWindow một lần với đối tượng Customer
                    HomeWindow homeWindow = new HomeWindow(customer);
                    homeWindow.Show();
                    this.Close();  // Đóng cửa sổ đăng nhập sau khi đăng nhập thành công
                }
                else
                {
                    MessageBox.Show("Your account is blocked!");
                }
            }
            // Nếu không đúng Email/Password
            else
            {
                MessageBox.Show("Your email or password is incorrect.");
            }
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            Register registerindow = new Register();
            registerindow.Show();
            this.Close();
        }
    }
}
