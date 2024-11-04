using KoiKingdom_BusinessObject;
using KoiKingdom_DAOs;
using KoiKingdom_Service;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Media.Imaging;

namespace KoiKingdomPRN_WPF
{
    /// <summary>
    /// Interaction logic for CheckoutWindow.xaml
    /// </summary>
    public partial class CheckoutWindow : Window
    {
        private readonly ICartItemServices cartItemServices;
        private readonly ICustomerService customerService;
        private readonly IBookingService bookingService;
        private Tour currentTour;
        private readonly int quantity;
        public Customer Customer { get; set; }

        public CheckoutWindow(Customer customer, Tour currentTour, int quantity)
        {
            InitializeComponent();
            cartItemServices = new CartItemServices();
            Customer = customer;
            this.quantity = quantity;
            this.currentTour = currentTour;
            bookingService = new BookingService();
            customerService = new CustomerService();
            LoadCartItems();
            LoadCustomerProfile(customer.CustomerId); // Gọi hàm mà không cần truyền ID
        }

        private void LoadCustomerProfile(int customerID)
        {
            try
            {
                // Retrieve the list of customers
                var customers = customerService.GetCustomers();

                // Check if the customers list is null or empty
                if (customers == null || !customers.Any())
                {
                    throw new InvalidOperationException("No customers found.");
                }

                // Find the customer profile based on CustomerId
                Customer customerProfile = customers.FirstOrDefault(t => t.CustomerId == customerID);

                if (customerProfile == null)
                {
                    throw new InvalidOperationException("No customer profile found for the given CustomerId.");
                }

                // Update the TextBoxes with customer information
                txtEmail.Text = customerProfile.Email ?? string.Empty;
                txtFullName.Text = customerProfile.FirstName + " " + customerProfile.LastName;
                txtAddress.Text = customerProfile.Address ?? "Your address will appear here"; // Default address message
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading customer profile: {ex.Message}");
            }
        }

        private void LoadCartItems()
        {
            if (cartItemServices == null)
            {
                MessageBox.Show("CartItemServices is not initialized.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Load và bind các mục trong giỏ hàng vào ListView
            var cartItems = cartItemServices.GetList();

            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;

            CartItemsListView.ItemsSource = cartItems.Select(item => new
            {
                TourImage = new BitmapImage(new Uri(System.IO.Path.Combine(currentDirectory, item.tour.Image), UriKind.Absolute)),
                TourName = item.tour.TourName,
                Quantity = item.quantity,
                TourPrice = string.Format("{0:C}", item.tour.TourPrice),
                TotalPrice = string.Format("{0:C}", item.tour.TourPrice * item.quantity)
            }).ToList();
        }

        private void btnPurchase_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnPurchase_Click_1(object sender, RoutedEventArgs e)
        {
            if (currentTour != null)
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(Customer.Address))
                    {
                        MessageBox.Show("Error: You must enter an address!", "Input Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return; // Exit the method if there's no address
                    }

                    // Create a new Booking
                    Booking newBooking = new Booking
                    {
                        TourId = currentTour.TourId,
                        CustomerId = Customer.CustomerId,
                        Name = $"{Customer.LastName} {Customer.FirstName}",
                        Email = Customer.Email,
                        BookingDate = DateTime.Now,
                        ShippingAddress = Customer.Address,
                        Quantity = quantity,
                        Status = "Paid",
                        TourType = "Available"
                    };

                    // Call service to add booking
                    bookingService.AddBookingItem(
                        newBooking.CustomerId,
                        newBooking.TourId,
                        newBooking.Name,
                        newBooking.Email,
                        newBooking.BookingDate,
                        newBooking.ShippingAddress,
                        newBooking.Quantity,
                        newBooking.Status,
                        newBooking.TourType
                    );

                    // Show success message and close window only after successful booking
                    MessageBox.Show("Booking successful!", "Confirmation", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Close();
                }
                catch (FormatException)
                {
                    MessageBox.Show("Invalid input. Please check your entries.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Error: Current tour is not set. Please select a tour.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

    }

}
