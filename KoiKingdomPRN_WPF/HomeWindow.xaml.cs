using KoiKingdom_BusinessObject;
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
    /// Interaction logic for HomeWindow.xaml
    /// </summary>
    public partial class HomeWindow : Window
    {
        private Customer customer;

        public HomeWindow()
        {
        }
        public HomeWindow(Customer customer)
        {
            InitializeComponent();
            this.customer = customer;
            HeaderWindow headerWindow = (HeaderWindow)this.FindName("headerWindowControl");
            if (headerWindow != null)
            {
                headerWindow.SetCustomer(customer);
            }
        }
        private void HeaderWindow_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void PreviousImage_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
