using KoiKingdom_BusinessObject;
using KoiKingdom_Service;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace KoiKingdomPRN_WPF
{
    /// <summary>
    /// Interaction logic for AddTourManagerWindow.xaml
    /// </summary>
    public partial class AddTourManagerWindow : Window
    {
        private readonly ITourService tourService;
        private readonly IFarmService farmService;
        private readonly IKoitypeService koitypeService;
        private ITourFarmService tourFarmService;
        private ITourKoitypeService tourKoitypeService;


        public AddTourManagerWindow(ITourService tourService, IFarmService farmService, IKoitypeService koitypeService, ITourFarmService tourFarmService, ITourKoitypeService tourKoitypeService)
        {
            InitializeComponent();
            this.tourService = tourService;
            this.farmService = farmService;
            this.koitypeService = koitypeService;
            this.tourFarmService = tourFarmService;
            this.tourKoitypeService = tourKoitypeService;

            LoadFarms();
            LoadKoiTypes();
        }

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            // Load danh sách nông trại
            LoadFarms();

            // Load danh sách loại koi
            LoadKoiTypes();

            // Thiết lập thông tin ban đầu cho tour mới
            Tour newTour = new Tour
            {
                TourName = TourName.Text,
                Duration = Duration.Text,
                Description = Description.Text,
                Image = ImagePath, // Set image path
                DepartureLocation = (DepartureLocation.SelectedItem as ComboBoxItem)?.Content.ToString()
            };

        }

        private void LoadFarms()
        {
            try
            {
                var farms = farmService.GetFarms();
                foreach (var farm in farms)
                {
                    CheckBox checkBox = new CheckBox
                    {
                        Content = farm.FarmName, // Tên của nông trại
                        Tag = farm.FarmId, // Lưu ID vào thuộc tính Tag
                        Margin = new Thickness(0, 0, 10, 0)
                    };
                    FarmsItemsControl.Items.Add(checkBox);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading farms: " + ex.Message);
            }
        }


        private void LoadKoiTypes()
        {
            try
            {
                var koiTypes = koitypeService.GetKoitypes();
                foreach (var koiType in koiTypes)
                {
                    CheckBox checkBox = new CheckBox
                    {
                        Content = koiType.TypeName,
                        Tag = koiType.KoiTypeId, // Thiết lập Tag với KoiTypeId
                        Margin = new Thickness(0, 0, 10, 0)
                    };
                    KoiTypesItemsControl.Items.Add(checkBox);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading koi types: " + ex.Message);
            }
        }

        private void CreateTour_Click(object sender, RoutedEventArgs e)
        {
            Tour newTour = new Tour
            {
                TourName = TourName.Text,
                Duration = Duration.Text,
                Description = Description.Text,
                Image = ImagePath, // Set image path
                DepartureLocation = (DepartureLocation.SelectedItem as ComboBoxItem)?.Content.ToString()
            };

            // Convert TourPrice
            if (!decimal.TryParse(TourPrice.Text, out decimal parsedPrice))
            {
                MessageBox.Show("Invalid price format. Please enter a valid number.");
                return; // Exit if parsing fails
            }
            newTour.TourPrice = parsedPrice;

            // Check start and end dates
            if (!StartDate.SelectedDate.HasValue || !EndDate.SelectedDate.HasValue)
            {
                MessageBox.Show("Please select both start and end dates.");
                return; // Exit if dates are not selected
            }

            newTour.StartDate = StartDate.SelectedDate.Value;
            newTour.EndDate = EndDate.SelectedDate.Value;

            // Validate that the end date is after the start date
            if (newTour.EndDate < newTour.StartDate)
            {
                MessageBox.Show("End date must be after the start date.");
                return; // Exit if validation fails
            }

            // Add the tour to the database and get the created tour
            Tour addedTour = tourService.AddTour(
                newTour.TourName,
                newTour.Duration,
                newTour.StartDate,
                newTour.EndDate,
                newTour.Image, // Set image
                newTour.TourPrice,
                newTour.Description,
                true, // Assuming status is true by default
                newTour.DepartureLocation
            );

            // Check if the tour was added successfully
            if (addedTour != null && addedTour.TourId > 0)
            {
                // Save selected farms
                foreach (CheckBox checkBox in FarmsItemsControl.Items)
                {
                    if (checkBox.IsChecked == true)
                    {
                        int selectedFarmId = (int)checkBox.Tag;
                        if (selectedFarmId != null)
                        {
                            TourFarm addedTourFarm = tourFarmService.AddTourFarm(addedTour.TourId, selectedFarmId); // Add relation between tour and farm
                        }
                    }
                }

                // Save selected koi types
                foreach (CheckBox checkBox in KoiTypesItemsControl.Items)
                {
                    if (checkBox.IsChecked == true)
                    {
                        int selectedKoiTypeId = (int)checkBox.Tag; // Get koi type by name

                        if (selectedKoiTypeId != null)
                        {
                            TourKoitype addedTourFarm = tourKoitypeService.AddTourKoitype(addedTour.TourId, selectedKoiTypeId); // Add relation between tour and koi type
                        }
                    }
                }

                MessageBox.Show("Tour added successfully.");
            }
            else
            {
                // Handle the case where addedTour is null or TourId is invalid
                MessageBox.Show("Failed to add tour or tour ID is invalid. Please try again.");
            }
        }


        // Giả sử bạn có một phương thức chọn file
        private string ImagePath; // Store relative image path
        private string fullImagePath; // Store full image path

        private void ChooseFile_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            // Allow any file type selection
            dlg.Filter = "All files (*.*)|*.*"; // Choose all types of files

            bool? result = dlg.ShowDialog();
            if (result == true)
            {
                // Get the file name from the selected path
                string fileName = System.IO.Path.GetFileName(dlg.FileName);

                // Combine with the desired folder path
                ImagePath = System.IO.Path.Combine("img", "TourImage", fileName);
                ImagePath = ImagePath.Replace("\\", "/");

                // Get the full path for uploading
                fullImagePath = GetFullImagePath(fileName);

                // Display the selected image path to the user
                MessageBox.Show($"Image path set to: {ImagePath}\nFull path for upload: {fullImagePath}");

                // Optionally, you can copy the file to the destination if required
                SaveFileToDestination(dlg.FileName, fullImagePath);
            }
        }

        // Method to construct the full image path for upload
        private string GetFullImagePath(string fileName)
        {
            return System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ImagePath);
        }

        // Method to save the file to the destination folder
        private void SaveFileToDestination(string sourceFilePath, string destinationFilePath)
        {
            try
            {
                // Ensure the directory exists
                string directoryPath = System.IO.Path.GetDirectoryName(destinationFilePath);
                if (!System.IO.Directory.Exists(directoryPath))
                {
                    System.IO.Directory.CreateDirectory(directoryPath);
                }

                // Copy the file to the destination path
                System.IO.File.Copy(sourceFilePath, destinationFilePath, true);
                MessageBox.Show("Image uploaded successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error uploading image: " + ex.Message);
            }
        }



        private void TourPrice_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Add validation for the tour price input if necessary.
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
