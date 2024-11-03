using KoiKingdom_BusinessObject;
using KoiKingdom_Repository;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KoiKingdomPRN_WPF
{
    /// <summary>
    /// Interaction logic for HeaderManagerWindow.xaml
    /// </summary>
    public partial class HeaderManagerWindow : UserControl
    {
        private ITourService tourService;
        private IFarmService farmService;
        private IKoitypeService koitypeService;
        private ITourFarmService tourFarmService;
        private ITourKoitypeService tourKoitypeService;
        private IEmployeeService employeeService;
        private IKoiOrderService koiOrderService;
        private ICustomerService customerService;

        public HeaderManagerWindow()
        {
            InitializeComponent();
            tourService = new TourService();
            koiOrderService = new KoiOrderService();
            farmService = new FarmService();
            koitypeService = new KoitypeService();
            tourFarmService = new TourFarmService();
            tourKoitypeService = new TourKoitypeService();
            employeeService = new EmployeeService();
        }

        public Employee employee { get; set; }

        public void SetEmployee(Employee employee)
        {
           this.employee = employee;
            // Cập nhật giao diện dựa trên thông tin Customer
        }

        private void Customer_Click(object sender, RoutedEventArgs e)
        {
            CustomerManagerWindow customerManagerWindow = new CustomerManagerWindow();
            customerManagerWindow.Show();
        }

        private void Employee_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this)?.Hide();
            EmployeeManagerWindow employeeManagerWindow = new EmployeeManagerWindow();
            employeeManagerWindow.Show();
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this)?.Hide();
            ManagerWindow managerWindow = new ManagerWindow();
            managerWindow.Show();
        }

        private void Tour_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this)?.Hide();
            TourManagerWindow tourManagerWindow = new TourManagerWindow();
            tourManagerWindow.Show();
        }

        private void Addtour_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this)?.Hide();
            AddTourManagerWindow addTourManagerWindow = new AddTourManagerWindow(tourService, farmService, koitypeService, tourFarmService, tourKoitypeService);
            addTourManagerWindow.Show();
        }

        private void AddEmployee_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this)?.Hide();
            AddEmployeeWindow addEmployeeWindow = new AddEmployeeWindow(employeeService);
            addEmployeeWindow.Show();
        }

        private void ProfileEmployee_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this)?.Hide();
            ManagerProfileWindow managerProfileWindow = new ManagerProfileWindow(employee, employeeService);
            managerProfileWindow.Show();
        }

        private void KoiOrder_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this)?.Hide();
            KoiOrderWindow koiOrderWindow = new KoiOrderWindow(koiOrderService, employeeService);
            koiOrderWindow.Show();
        }
    }
}
