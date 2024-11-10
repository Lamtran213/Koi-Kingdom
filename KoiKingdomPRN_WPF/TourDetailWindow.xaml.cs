using KoiKingdom_BusinessObject;
using KoiKingdom_Service;
using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace KoiKingdomPRN_WPF
{
    public partial class TourDetailWindow : Window
    {
        private readonly ITourService tourService;
        private readonly IFarmService farmService;
        private readonly IBookingService bookingService;
        private readonly CartItemServices cartService;
        private Tour currentTour;
        public Customer Customer { get; set; }

        public TourDetailWindow(ITourService tourService, IBookingService bookingService, IFarmService farmService, int selectedTourId, Customer customer)
        {
            InitializeComponent();
            this.tourService = tourService;
            this.farmService = farmService;
            this.bookingService = bookingService;
            this.Customer = customer;
            this.cartService = new CartItemServices(); // Initialize CartService

            LoadTourInformation(selectedTourId);
        }

        public TourDetailWindow(Customer customer)
        {
            Customer = customer;
            InitializeComponent(); // Đảm bảo gọi InitializeComponent()
        }


        private void LoadTourInformation(int selectedTourId)
        {
            currentTour = tourService.GetTours().FirstOrDefault(t => t.TourId == selectedTourId);
            var farms = farmService.GetFarms().Select(f => f.FarmName).ToList();

            if (currentTour != null)
            {
                string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;

                TourImage.Source = new BitmapImage(new Uri(Path.Combine(currentDirectory, currentTour.Image), UriKind.Absolute));
                TourName.Text = currentTour.TourName ?? "Không có tên tour";
                Rating.Text = "4.0"; // Update rating value as needed
                Duration.Text = $"Duration: {currentTour.Duration ?? "N/A"}";
                StartDate.Text = currentTour.StartDate.ToString("dd-MM-yyyy");
                EndDate.Text = currentTour.EndDate.ToString("dd-MM-yyyy");
                FarmNames.Text = $"Farm: {string.Join(", ", farms)}";
                KoiTypes.Text = $"Koi Type: {(currentTour.TourKoitypes != null && currentTour.TourKoitypes.Any() ? string.Join(", ", currentTour.TourKoitypes.Select(k => k.KoiType)) : "N/A")}";
                DepartureLocation.Text = $"Departure Location: {currentTour.DepartureLocation ?? "N/A"}";
                TourPrice.Text = string.Format("{0:C}", currentTour.TourPrice);
            }
            else
            {
                MessageBox.Show("Không tìm thấy tour nào với id này.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void AddToCart_Click(object sender, RoutedEventArgs e)
        {
            if (currentTour != null)
            {
                try
                {
                    // Get the quantity entered by the user
                    int quantity = Convert.ToInt32(QuantityDisplay.Text);

                    if (quantity > 0)
                    {
                        // Add the tour to the cart using CartService
                        cartService.AddTourToCart(currentTour, quantity);
                        MessageBox.Show("Đã thêm vào giỏ hàng thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                        HomeWindow homeWindow = new HomeWindow(cartService, currentTour, quantity);
                    }
                    else
                    {
                        MessageBox.Show("Số lượng phải lớn hơn 0.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("Vui lòng nhập số lượng hợp lệ.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("Không có tour nào để thêm vào giỏ hàng.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void IncreaseQuantity_Click(object sender, RoutedEventArgs e)
        {
            int currentQuantity = int.Parse(QuantityDisplay.Text);
            QuantityDisplay.Text = (currentQuantity + 1).ToString();
        }

        private void DecreaseQuantity_Click(object sender, RoutedEventArgs e)
        {
            int currentQuantity = int.Parse(QuantityDisplay.Text);
            if (currentQuantity > 0)
            {
                QuantityDisplay.Text = (currentQuantity - 1).ToString();
            }
        }

        private void BackToTourList_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); // Close this window to go back
        }

        private void BookNow_Click(object sender, RoutedEventArgs e)
        {
            if (currentTour != null)
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(Customer.Address))
                    {
                        MessageBox.Show("Error: You must enter an address!");
                        return;
                    }
                    // Create a new Booking object and populate it with necessary information
                    Booking newBooking = new Booking
                    {
                        TourId = currentTour.TourId, // Assuming you have TourId in the currentTour object
                        CustomerId = Customer.CustomerId,
                        Name = Customer.LastName + Customer.FirstName,
                        Email = Customer.Email,
                        BookingDate = DateTime.Now, // or use a date selected by the user
                        ShippingAddress = Customer.Address,
                        Quantity = Convert.ToInt32(QuantityDisplay.Text), // Assuming you have a QuantityDisplay TextBox
                        Status = "Paid", // Set the initial status, adjust as needed
                        TourType = "Available" // Assuming TourType is a property of currentTour
                    };

                    // Call the booking service to add the booking
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

                    MessageBox.Show("Booking successful!", "Confirmation", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Close(); // Close the window after booking
                }
                catch (FormatException)
                {
                    MessageBox.Show("Invalid input. Please check your entries.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    // Optionally log the error for debugging purposes
                }
            }
            else
            {
                MessageBox.Show("No tour selected for booking.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
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

