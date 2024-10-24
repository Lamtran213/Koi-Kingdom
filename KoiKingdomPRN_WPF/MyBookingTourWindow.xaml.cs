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

            // Lấy đường dẫn thư mục hiện tại của ứng dụng (bỏ thư mục "Koi-Kingdom")
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;

            // Chuyển đổi thông tin tour thành danh sách đối tượng để binding
            var bookingItems = booking.Select(booking =>
            {
                var tour = tourService.GetTourById(booking.TourId);
                return new
                {
                    TourID = tour.TourId,
                    TourImage = new BitmapImage(new Uri(Path.Combine(currentDirectory, tour.Image), UriKind.Absolute)),
                    TourName = tour.TourName ?? "Không có tên tour",
                    Quantity = booking.Quantity, // Số lượng tour mà khách đã đặt
                    TotalPrice = booking.Quantity * tour.TourPrice, // Tổng giá tiền cho booking
                    TourPrice = tour.TourPrice, // Hiển thị giá theo định dạng tiền tệ
                };
            }).ToList();

            // Gán danh sách tour vào ListView (TourItemsListView)
            TourItemsListView.ItemsSource = bookingItems;

            // Tính tổng giá cho tất cả các tour đã booking
            decimal totalPrice = (decimal)bookingItems.Sum(item => item.TotalPrice);

            // Hiển thị tổng giá
            TotalPriceTextBlock.Text = $"Total Price: {totalPrice.ToString("C")}";
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
