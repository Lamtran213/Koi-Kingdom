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
        private int quantity;

        public Customer Customer { get; set; }

        public Tour Tour { get; set; }

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
            RefreshTour();

        }
        public void RefreshCustomer()
        {
            Customer = CustomerDAO.Instance.CurrentCustomer;
            if (Customer != null)
            {
                // Cập nhật giao diện dựa trên thông tin Customer
            }
        }

        public void RefreshTour()
        {
            Tour  = TourDAO.Instance.CurrentTour;
            quantity = TourDAO.Instance.Quantity;
            if (Tour != null)
            {
                this.Tour= TourDAO.Instance.CurrentTour;
                this.quantity = TourDAO.Instance.Quantity;
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

        public void SetTour(Tour tour, int quantity)
        {
            Tour = tour;
            this.quantity = quantity;
            // Cập nhật giao diện dựa trên thông tin Customer
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
            RefreshTour();
            MyCartWindow myCartWindow = new MyCartWindow(cartItemServices, cartService, Tour, quantity, Customer);
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
