using KoiKingdom_BusinessObject;
using KoiKingdom_DAOs;
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
    /// Interaction logic for HomeWindow.xaml
    /// </summary>
    public partial class HomeWindow : Window
    {
        private Customer customer;
        private Tour tour;
        private int quantity;

        public HomeWindow(Customer customer)
        {
            InitializeComponent();
            this.customer = customer;
            CustomerDAO.Instance.CurrentCustomer = customer;
            // Lấy HeaderWindow và truyền Customer
            HeaderWindow headerWindow = (HeaderWindow)this.FindName("headerWindowControl");
            if (headerWindow != null)
            {
                headerWindow.SetCustomer(customer);
            }
        }

        public HomeWindow(CartItemServices cartService, Tour currentTour, int quantity) 
        {
            InitializeComponent();
            this.tour = currentTour;
            this.quantity = quantity;
            TourDAO.Instance.CurrentTour = tour;
            TourDAO.Instance.Quantity = quantity;
            // Lấy HeaderWindow và truyền Customer
            HeaderWindow headerWindow = (HeaderWindow)this.FindName("headerWindowControl");
            if (headerWindow != null)
            {
                headerWindow.SetTour(currentTour, quantity);
            }
        }

        public HomeWindow()
        {
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
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }
    }
}
