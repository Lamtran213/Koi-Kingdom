using KoiKingdom_BusinessObject;
using KoiKingdom_Service;
using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Media.Imaging;

namespace KoiKingdomPRN_WPF
{
    public partial class TourDetailWindow : Window
    {
        private readonly ITourService tourService;
        private readonly IFarmService farmService;
        private readonly CartService cartService; // Thêm biến cho CartService
        private const string ImageBasePath = @"D:\LAB_PRN\KoiKingdomPRN_WPF\"; // Image base path

        public TourDetailWindow(ITourService tourService, IFarmService farmService, int selectedTourId)
        {
            InitializeComponent();
            this.tourService = tourService;
            this.farmService = farmService;
            this.cartService = new CartService(); // Khởi tạo CartService

            LoadTourInformation(selectedTourId);
        }

        private void LoadTourInformation(int selectedTourId)
        {
            var tour = tourService.GetTours().FirstOrDefault(t => t.TourId == selectedTourId);
            var farms = farmService.GetFarms().Select(f => f.FarmName).ToList();

            if (tour != null)
            {
                // Use BitmapImage with error handling
                BitmapImage bitmapImage;
                try
                {
                    bitmapImage = new BitmapImage(new Uri(Path.Combine(ImageBasePath, tour.Image), UriKind.Absolute));
                }
                catch
                {
                    // Handle image loading error (e.g., set a default image or log the error)
                    bitmapImage = new BitmapImage(); // Placeholder or default image
                }

                TourImage.Source = bitmapImage;
                TourName.Text = tour.TourName ?? "Không có tên tour";
                Rating.Text = "4.0"; // Update rating value as needed
                Duration.Text = $"Duration: {tour.Duration ?? "N/A"}";
                StartDate.Text = tour.StartDate.ToString("dd-MM-yyyy");
                EndDate.Text = tour.EndDate.ToString("dd-MM-yyyy");
                FarmNames.Text = $"Farm: {string.Join(", ", farms)}";
                KoiTypes.Text = $"Koi Type: {(tour.TourKoitypes != null && tour.TourKoitypes.Any() ? string.Join(", ", tour.TourKoitypes.Select(k => k.KoiType)) : "N/A")}";
                DepartureLocation.Text = $"Departure Location: {tour.DepartureLocation ?? "N/A"}";
                TourPrice.Text = string.Format("{0:C}", tour.TourPrice);
            }
            else
            {
                MessageBox.Show("Không tìm thấy tour nào với id này.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void BookNow_Click(object sender, RoutedEventArgs e)
        {
            // Handle book now action
        }

        private void AddToCart_Click(object sender, RoutedEventArgs e)
        {
            // Lấy tour hiện tại từ DataContext
            var currentTour = (Tour)this.DataContext;
            var tourId = currentTour.TourId; // Lấy ID của tour

            // Gọi dịch vụ giỏ hàng để thêm tour vào giỏ hàng
            int quantity = Convert.ToInt32(QuantityDisplay.Text);
            cartService.AddTourToCart(currentTour, quantity); // Sử dụng CartService
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
    }
}
