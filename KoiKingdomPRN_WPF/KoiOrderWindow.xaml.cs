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
    /// Interaction logic for KoiOrderWindow.xaml
    /// </summary>
    public partial class KoiOrderWindow : Window
    {

        private readonly IKoiOrderService koiOrderService;
        private readonly IEmployeeService employeeService;


        public KoiOrderWindow()
        {
            InitializeComponent();
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }
        public KoiOrderWindow(KoiKingdom_Service.IKoiOrderService koiOrderService, IEmployeeService employeeService)
        {
            this.koiOrderService = koiOrderService;
            this.employeeService = employeeService;
            InitializeComponent();
            ReloadKoiOrderData();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ReloadKoiOrderData();
        }


        private void dtgKoiOrder_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Kiểm tra nếu có mục được chọn
            if (dtgKoiOrder.SelectedItem is Koiorder selectedOrder)
            {
                // Lấy thông tin khách hàng dựa trên ID khách hàng từ đơn hàng đã chọn
                List<Customer> customerProfile = employeeService.GetCustomerByList();

                // Tìm khách hàng dựa trên ID khách hàng của đơn hàng đã chọn
                var customer = customerProfile.FirstOrDefault(c => c.CustomerId == selectedOrder.CustomerId);

                // Kiểm tra nếu tìm thấy khách hàng
                if (customer != null)
                {
                    // Cập nhật ItemsSource cho dtgKoiOrder với thông tin khách hàng
                    this.dtgKoiOrder.ItemsSource = koiOrderService.GetKoiOrder().Select(a => new
                    {
                        a.CustomerId,
                        CustomerName = customer.FirstName + " " + customer.LastName,
                        a.DeliveryDate
                    }).ToList();
                }

                // Gọi hàm để làm mới dữ liệu nhân viên nếu cần
                ReloadKoiOrderData();
            }
        }


        private void ReloadKoiOrderData()
        {
            // Load KoiOrder data and display without requiring a selection.
            var orders = koiOrderService.GetKoiOrder();
            var customerProfile = employeeService.GetCustomerByList();

            this.dtgKoiOrder.ItemsSource = orders.Select(a => new
            {
                a.KoiOrderId,
                a.CustomerId,
                CustomerName = customerProfile.FirstOrDefault(c => c.CustomerId == a.CustomerId)?.FirstName + " " +
                               customerProfile.FirstOrDefault(c => c.CustomerId == a.CustomerId)?.LastName,
                a.DeliveryDate,
                a.Status
            }).ToList();
        }

    }
}