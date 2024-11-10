using KoiKingdom_BusinessObject;
using KoiKingdom_Service;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for AddEmployeeWindow.xaml
    /// </summary>
    public partial class AddEmployeeWindow : Window
    {
        private readonly IEmployeeService _employeeService;
        public AddEmployeeWindow(IEmployeeService employeeService)
        {
            InitializeComponent();
            this._employeeService = employeeService;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }
        private void AddEmployee_Click(object sender, RoutedEventArgs e)
        {
            // Define an email pattern to validate
            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            // Check if the entered email matches the pattern
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtEmailEmployee.Text, emailPattern))
            {
                MessageBox.Show("Invalid email format. Please enter a valid email.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return; // Exit the method if email format is invalid
            }
            Employee employee = new Employee
            {
                Email = txtEmailEmployee.Text,
                Password = pswEmployee.Password,
                Role = (cbxRole.SelectedItem as ComboBoxItem)?.Content.ToString(),
                LastName = txtLastNameEmployee.Text,
                FirstName = txtFirstNameEmployee.Text,
                Address = txtAddressEmployee.Text,
            };

            Employee addEmployee = _employeeService.AddEmployeeProfile(
                employee.Email,
                employee.Password,
                employee.Address,
                employee.Role,
                employee.FirstName,
                employee.LastName,
                true
                );
            if (addEmployee != null)
            {
                MessageBox.Show("Employee added successfully!");
            }
            else
            {
                MessageBox.Show("Cannot add employee for some reason!");
            }
        }
    }
}
