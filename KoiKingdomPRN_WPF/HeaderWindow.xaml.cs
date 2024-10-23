using KoiKingdom_BusinessObject;
using KoiKingdom_Service;
using System.Windows;
using System.Windows.Controls;

namespace KoiKingdomPRN_WPF
{
    public partial class HeaderWindow : UserControl
    {
        private ITourService tourService;
        private IFarmService farmService;
        private ICartItemServices cartItemServices;
        private CartItemServices cartService;
        private Tour currentTour;
        private int quantity;

        public HeaderWindow()
        {
            InitializeComponent();
            tourService = new TourService();
            farmService = new FarmService();
            cartItemServices = new CartItemServices();
        }

        public HeaderWindow(CartItemServices cartService, Tour currentTour, int quantity)
        {
            this.cartService = cartService;
            this.currentTour = currentTour;
            this.quantity = quantity;
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            // Implement logic for Home menu item click
        }

        private void Services_Click(object sender, RoutedEventArgs e)
        {
            // Implement logic for Services menu item click
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            // Implement logic for Information menu item click
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            // Implement logic for another Information menu item click
        }

        private void Contact_Click(object sender, RoutedEventArgs e)
        {
            // Implement logic for Contact menu item click
        }

        private void Farm_Click(object sender, RoutedEventArgs e)
        {
            // Implement logic for Contact menu item click
        }

        private void KoiType_Click(object sender, RoutedEventArgs e)
        {
            // Implement logic for Contact menu item click
        }

        private void Booking_Click(object sender, RoutedEventArgs e)
        {
            // Implement logic for Booking menu item click
        }

        private void TourBooking_Click(object sender, RoutedEventArgs e)
        {
            TourWindow tourWindow = new TourWindow(tourService, farmService);
            tourWindow.Show();
        }

        private void CustomTour_Click(object sender, RoutedEventArgs e)
        {
            // Implement logic for Custom Tour menu item click
        }

        // Event handlers for button clicks
        private void AddToCart_Click(object sender, RoutedEventArgs e)
        {
            MyCartWindow myCartWindow = new MyCartWindow(cartItemServices, cartService, currentTour, quantity);
            myCartWindow.Show();
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            // Logic for Button2
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            // Logic for Button3
        }
    }
}
