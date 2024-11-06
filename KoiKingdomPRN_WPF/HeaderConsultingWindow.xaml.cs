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
    /// Interaction logic for HeaderConsultingWindow.xaml
    /// </summary>
    public partial class HeaderConsultingWindow : UserControl
    {
        private Employee employee;
        private IFarmService farmService;
        private IKoitypeService koitypeService;
        private IKoiService koiService; 
        private IKoiOrderService orderService;
        private IKoiorderdetailService orderdetailService;

        public HeaderConsultingWindow()
        {
            InitializeComponent();
            this.farmService = new FarmService();
            this.koiService = new KoiService();
            this.orderdetailService = new KoiorderdetailService();
            this.orderService = new KoiOrderService();
            this.koitypeService = new KoitypeService();
        }
        public void SetEmployee(Employee employee)
        {
            this.employee = employee;
            // Cập nhật giao diện dựa trên thông tin Customer
        }
        private void Create_Koi_Order_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this)?.Hide();
            CreateKoiOrderManagerWindow createKoiOrderManagerWindow = new CreateKoiOrderManagerWindow(farmService, koitypeService, koiService, orderService, orderdetailService);
            createKoiOrderManagerWindow.Show();
          
        }


        private void Home_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
