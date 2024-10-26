using KoiKingdom_BusinessObject;
using KoiKingdom_Service;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KoiKingdomPRN_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Register : Window
    {
        private ICustomerService customerService;
        public Register()
        {
            InitializeComponent();
            customerService = new CustomerService();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSignup_Click(object sender, RoutedEventArgs e)
        {
            // Define an email pattern to validate
            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            if (!System.Text.RegularExpressions.Regex.IsMatch(txtEmail.Text, emailPattern))
            {
                MessageBox.Show("Invalid email format. Please enter a valid email.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return; 
            }
            string email = txtEmail.Text;

            // Kiểm tra nếu email đã tồn tại
            if (customerService.GetCustomerByEmail(email)!=null)
            {
                MessageBox.Show("Email already exists. Please use another email.");
                return; 
            }

            // Tiếp tục nếu email chưa tồn tại
            if (txtPassword.Password.Equals(txtConfirmPassword.Password))
            {
                Customer customer = new Customer();
                customer.FirstName = txtFirstName.Text;
                customer.LastName = txtLastName.Text;
                customer.Email = email;
                customer.Password = txtPassword.Password;

                // Thêm khách hàng vào hệ thống
                bool isSignUp = customerService.AddCustomerProfile(customer);
                if (isSignUp)
                {
                    MessageBox.Show("Sign up successfully! Please return to login.");
                }
                else
                {
                    MessageBox.Show("Failed to sign up for some reason!");
                }
            }
            else
            {
                MessageBox.Show("Password do not match. Please sign up again.");
            }
        }



        private void btnSignIn_Click(object sender, RoutedEventArgs e)
        {
          
            LoginWindow loginWindow = new LoginWindow(); 
            loginWindow.Show();  

            this.Close();

        }
    }
}