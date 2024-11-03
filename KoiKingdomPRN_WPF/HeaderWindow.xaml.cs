using KoiKingdom_BusinessObject;
using KoiKingdom_DAOs;
using KoiKingdom_Service;
using System.Windows;
using System.Windows.Controls;

namespace KoiKingdomPRN_WPF
{
    public partial class HeaderWindow : UserControl
    {
        private ITourService tourService;
        private IFarmService farmService;
        private IBookingService bookingService;
        private ICartItemServices cartItemServices;
        private IKoitypeService koitypeService;
        private IFarmService farmSerivce;
        private ICustomerService customerService;
        private CartItemServices cartService;
        private Tour currentTour;
        private int quantity;

        public Customer Customer { get; set; }

        public HeaderWindow()
        {
            InitializeComponent();
            farmSerivce = new FarmService();
            koitypeService = new KoitypeService();
            tourService = new TourService();
            customerService = new CustomerService();
            farmService = new FarmService();
            bookingService = new BookingService();
            cartItemServices = new CartItemServices();
            RefreshCustomer();

        }
        public void RefreshCustomer()
        {
            Customer = CustomerDAO.Instance.CurrentCustomer;
            if (Customer != null)
            {
                // Cập nhật giao diện dựa trên thông tin Customer
            }
        }

        private void HeaderWindow_Loaded(object sender, RoutedEventArgs e)
        {
            HomeWindow homeWindow = new HomeWindow();

        }

        public void SetCustomer(Customer customer)
        {
            Customer = customer;
            // Cập nhật giao diện dựa trên thông tin Customer
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
            Window.GetWindow(this)?.Hide();
            FarmListWindow farmListWindow = new FarmListWindow(farmService);
            farmListWindow.Show();
        }

        private void KoiType_Click(object sender, RoutedEventArgs e)
        {
            // Implement logic for Contact menu item click
            Window.GetWindow(this)?.Hide();
            KoiTypeListWindow koiTypeWindow = new KoiTypeListWindow(koitypeService);
            koiTypeWindow.Show();
        }

        private void Booking_Click(object sender, RoutedEventArgs e)
        {
            // Implement logic for Booking menu item click
        }

        private void TourBooking_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this)?.Hide();
            TourWindow tourWindow = new TourWindow(tourService,  farmService, bookingService, Customer);
            tourWindow.Show();
        }

        private void CustomTour_Click(object sender, RoutedEventArgs e)
        {
            // Implement logic for Custom Tour menu item click
        }

        // Event handlers for button clicks
        private void AddToCart_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this)?.Hide();
            MyCartWindow myCartWindow = new MyCartWindow(cartItemServices, cartService, currentTour, quantity, Customer);
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
        private void MyBookingTour_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this)?.Hide();
            MyBookingTourWindow myBookingtWindow = new MyBookingTourWindow(tourService, bookingService, Customer);
            myBookingtWindow.Show();
        }

        private void MyProfile_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this)?.Hide();
            MyProfileModalWindow myBookingtWindow = new MyProfileModalWindow(Customer, customerService);
            myBookingtWindow.Show();
        }

    }
}
