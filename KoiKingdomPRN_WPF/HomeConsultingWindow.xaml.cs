using KoiKingdom_BusinessObject;
using KoiKingdom_DAOs;
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
    /// Interaction logic for HomeConsultingWindow.xaml
    /// </summary>
    public partial class HomeConsultingWindow : Window
    {
        private Employee employee;
        public HomeConsultingWindow(KoiKingdom_BusinessObject.Employee employee)
        {
            InitializeComponent();
            EmployeeDAO.Instance.CurrentEmployee = employee;
            HeaderConsultingWindow headerConsultingWindow = (HeaderConsultingWindow)this.FindName("headerConsultingWindowControl");
            this.employee = employee;
            if (headerConsultingWindow != null)
            {
                headerConsultingWindow.SetEmployee(employee);
            }
        }

        private void HeaderConsultingWindow_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
