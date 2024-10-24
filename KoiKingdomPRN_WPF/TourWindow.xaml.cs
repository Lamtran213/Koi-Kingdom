using KoiKingdom_BusinessObject;
using KoiKingdom_Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace KoiKingdomPRN_WPF
{
    public partial class TourWindow : Window
    {
        private readonly ITourService tourService; // Giả định bạn có một interface cho tourService
        private readonly IFarmService farmService; // Giả định bạn có một interface cho farmService
        private readonly IBookingService bookingService; // Giả định bạn có một interface cho farmService
        public Customer Customer { get; set; }
        public TourWindow(ITourService tourService, IFarmService farmService, IBookingService bookingService, Customer customer)
        {
            InitializeComponent();
            this.tourService = tourService;
            this.bookingService = bookingService;
            this.farmService = farmService;
            this.Customer = customer;

            LoadTourInformation(); // Gọi phương thức này tại đây
        }

        public TourWindow()
        {
        }

        private void TourButton_Click(object sender, RoutedEventArgs e)
        {
            // Lấy tourId từ Tag của button
            var button = sender as Button;
            if (button != null)
            {
                // Kiểm tra và chuyển đổi Tag sang int
                if (int.TryParse(button.Tag.ToString(), out int selectedTourId))
                {
                  
                    TourDetailWindow tourDetailWindow = new TourDetailWindow(tourService, bookingService, farmService, selectedTourId, Customer);
                    tourDetailWindow.Show();
                }
                else
                {
                    MessageBox.Show("TourId không hợp lệ."); // Hiển thị thông báo nếu không thể chuyển đổi
                }
            }
        }

        private void LoadTourInformation()
        {
            var tours = tourService.GetTours().ToList(); // Lấy tất cả các tour
            var farms = farmService.GetFarms().Select(f => f.FarmName).ToList(); // Lấy tên farm

            if (tours.Any())
            {
                // Lấy đường dẫn thư mục hiện tại của ứng dụng (bỏ thư mục "Koi-Kingdom")
                string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;

                // Chuyển đổi thông tin tour thành danh sách đối tượng để binding
                var tourItems = tours.Select(tour => new
                {
                    TourID = tour.TourId,
                    ImageSource = new BitmapImage(new Uri(Path.Combine(currentDirectory, tour.Image), UriKind.Absolute)), // Không có thư mục "Koi-Kingdom"
                    TourName = tour.TourName ?? "Không có tên tour",
                    Rating = "4.0", // Thay đổi giá trị xếp hạng theo yêu cầu
                    Duration = $"Duration: {tour.Duration ?? "N/A"}",
                    StartDate = tour.StartDate,
                    EndDate = tour.EndDate,
                    Farms = $"Farm: {string.Join(", ", farms)}",
                    KoiTypes = $"Koi Type: {(tour.TourKoitypes != null && tour.TourKoitypes.Any() ? string.Join(", ", tour.TourKoitypes.Select(k => k.KoiType)) : "N/A")}",
                    DepartureLocation = $"Departure Location: {tour.DepartureLocation ?? "N/A"}",
                    TourPrice = tour.TourPrice
                }).ToList();

                // Gán danh sách tour vào ItemsControl
                TourItemsControl.ItemsSource = tourItems;
            }
            else
            {
                MessageBox.Show("Không có tour nào được tìm thấy.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
