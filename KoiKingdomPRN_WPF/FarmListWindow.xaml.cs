using KoiKingdom_Service;
using System;
using System.IO; // Thêm dòng này để sử dụng Path.Combine
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace KoiKingdomPRN_WPF
{
    public partial class FarmListWindow : Window
    {
        private readonly IFarmService farmService;

        public FarmListWindow(IFarmService farmService)
        {
            InitializeComponent();
            this.farmService = farmService;
            LoadFarmInformation();
        }

        private void LoadFarmInformation()
        {
            try
            {
                var farms = farmService.GetFarms();
                if (farms.Any())
                {
                    string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
                    var farmsList = farms.Select(farmList => new
                    {
                        FarmID = farmList.FarmId,
                        FarmName = farmList.FarmName,
                        Location = farmList.Location,
                        Description = farmList.Description,
                        // Sử dụng UriKind.RelativeOrAbsolute và kiểm tra đường dẫn ảnh
                        Image = new BitmapImage(new Uri(Path.Combine(currentDirectory, farmList.Image), UriKind.RelativeOrAbsolute)),
                    }).ToList();
                    FarmListBox.ItemsSource = farmsList;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot load information for some reason!!");
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
