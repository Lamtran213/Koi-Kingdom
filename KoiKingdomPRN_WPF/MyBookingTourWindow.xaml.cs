using KoiKingdom_BusinessObject;
using KoiKingdom_Service;
using System;
using System.Collections.Generic;
using System.IO; // Added for file path handling
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace KoiKingdomPRN_WPF
{
    /// <summary>
    /// Interaction logic for MyBookingTourWindow.xaml
    /// </summary>
    public partial class MyBookingTourWindow : Window
    {
        private readonly IBookingService bookingService;
        private Customer customer;
        private ITourService tourService;
        private decimal totalPrice;
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        public MyBookingTourWindow(ITourService tourService, IBookingService bookingService, Customer customer)
        {
            InitializeComponent();
            this.tourService = tourService;
            this.bookingService = bookingService;
            this.customer = customer;
            LoadBookingItems(customer.CustomerId);
        }

        private void LoadBookingItems(int customerId)
        {
            var booking = bookingService.GetBooking(customerId).ToList();

            // Get current directory of the application
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;

            // Convert booking information into a binding list
            var bookingItems = booking.Select(booking =>
            {
                var tour = tourService.GetTourById(booking.TourId);
                return new
                {
                    TourID = tour.TourId,
                    TourImage = GetTourImage(tour.Image, currentDirectory), // Use the GetTourImage method
                    TourName = tour.TourName ?? "Không có tên tour",
                    Quantity = booking.Quantity, // Quantity booked
                    TotalPrice = booking.Quantity * tour.TourPrice, // Total price for booking
                    TourPrice = tour.TourPrice, // Display tour price
                };
            }).ToList();

            // Set the list to ListView (TourItemsListView)
            BookingItemsListView.ItemsSource = bookingItems;
        }



        private BitmapImage GetTourImage(string imagePath, string currentDirectory)
        {
            try
            {
                // Construct absolute path from the current directory
                string fullPath = Path.Combine(currentDirectory, imagePath);

                // Ensure the path exists before trying to load the image
                if (File.Exists(fullPath))
                {
                    return new BitmapImage(new Uri(fullPath, UriKind.Absolute));
                }
                else
                {
                    // Return a placeholder image if the file doesn't exist
                    return new BitmapImage(new Uri(Path.Combine(currentDirectory, "img/placeholder.png"), UriKind.Absolute));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading image: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }
    }
}
