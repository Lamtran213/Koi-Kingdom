using KoiKingdom_BusinessObject;
using KoiKingdom_Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace KoiKingdomPRN_WPF
{
    /// <summary>
    /// Interaction logic for TourManagerWindow.xaml
    /// </summary>
    public partial class TourManagerWindow : Window
    {

        private ITourService tourService;
        public TourManagerWindow()
        {
            InitializeComponent();
            tourService = new TourService();
        }

        private void ReloadTourData()
        {
            this.dtgTour.ItemsSource = tourService.GetTours().Select(t => new
            {
                t.TourId,
                t.TourName,
                t.Duration,
                t.Description,
                TourPrice = t.TourPrice.HasValue ? t.TourPrice.Value.ToString("C") : "N/A", // Format giá hoặc hiển thị "N/A" nếu không có giá
                StartDate = t.StartDate.ToString("dd/MM/yyyy"), // Hiển thị ngày bắt đầu
                EndDate = t.EndDate.ToString("dd/MM/yyyy"),    // Hiển thị ngày kết thúc
                t.DepartureLocation,
                Status = (bool)t.Status ? "Active" : "Blocked"
                // Hiển thị trạng thái "Active" hoặc "Blocked"
            }).ToList();
        }

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            // Đảm bảo rằng dtgCustomer được khởi tạo đúng
            this.dtgTour.ItemsSource = tourService.GetTours().Select(a => new
            {
                a.TourId,
                a.TourName,
                a.Duration,
                a.Description,
                TourPrice = a.TourPrice.HasValue ? a.TourPrice.Value.ToString("C") : "N/A", // Format giá hoặc hiển thị "N/A" nếu không có giá
                StartDate = a.StartDate.ToString("dd/MM/yyyy"), // Hiển thị ngày bắt đầu
                EndDate = a.EndDate.ToString("dd/MM/yyyy"),    // Hiển thị ngày kết thúc
                a.DepartureLocation,
                Status = (bool)a.Status ? "Active" : "Blocked"
                // Hiển thị trạng thái "Active" hoặc "Blocked"
            }).ToList();
            ReloadTourData();
        }

        private void dtgTour_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dataGrid = sender as DataGrid;

            if (dataGrid.SelectedItem != null)
            {
                DataGridRow row = (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromItem(dataGrid.SelectedItem);

                if (row != null)
                {
                    DataGridCell RowColumn = dataGrid.Columns[0].GetCellContent(row).Parent as DataGridCell;

                    if (RowColumn != null)
                    {
                        int id;
                        try
                        {
                            id = int.Parse(((TextBlock)RowColumn.Content).Text);

                            Tour tour = tourService.GetTourById(id);
                            if (tour != null)
                            {
                                txtTourID.Text = tour.TourId.ToString();
                                txtTourName.Text = tour.TourName;
                                txtDuration.Text = tour.Duration.ToString();
                                txtDescription.Text = tour.Description;
                                txtTourPrice.Text = tour.TourPrice.HasValue ? tour.TourPrice.Value.ToString("C") : "N/A";
                                dpStartDate.Text = tour.StartDate.ToString();
                                dpEndDate.Text = tour.EndDate.ToString();
                                txtDepartureLocation.Text = tour.DepartureLocation;

                                // Set the selected status in ComboBox

                                cmbStatus.SelectedItem = (bool)tour.Status ?
                                                          cmbStatus.Items.OfType<ComboBoxItem>().FirstOrDefault(item => item.Content.ToString() == "Active") :
                                                          cmbStatus.Items.OfType<ComboBoxItem>().FirstOrDefault(item => item.Content.ToString() == "Blocked");
                            }
                        }
                        catch (FormatException)
                        {
                            MessageBox.Show("Invalid Customer ID format.");
                        }
                        catch (OverflowException)
                        {
                            MessageBox.Show("Customer ID is out of range.");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("An error occurred: " + ex.Message);
                        }
                    }
                }
            }
        }

        private void cmbStatus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Kiểm tra nếu không có khách hàng nào được chọn
            if (string.IsNullOrWhiteSpace(txtTourID.Text))
            {
                MessageBox.Show("Please select a Employee to update.");
                return;
            }

            // Lấy ID của khách hàng
            int tourId;
            if (!int.TryParse(txtTourID.Text, out tourId))
            {
                MessageBox.Show("Invalid Employee ID.");
                return;
            }

            // Lấy trạng thái mới từ ComboBox
            ComboBoxItem selectedStatus = cmbStatus.SelectedItem as ComboBoxItem;
            if (selectedStatus == null)
            {
                MessageBox.Show("Please select a status.");
                return;
            }

            bool isActive = selectedStatus.Content.ToString() == "Active";

            try
            {
                Tour tour = tourService.GetTourById(tourId);
                if (tour != null)
                {
                    // Kiểm tra nếu trạng thái mới khác với trạng thái hiện tại
                    if (tour.Status == isActive)
                    {
                        // Không thay đổi trạng thái, không thực hiện cập nhật
                        return;
                    }

                    // Nếu trạng thái mới khác, tiếp tục cập nhật
                    tour.Status = isActive;

                    // Cập nhật thông tin khách hàng và kiểm tra kết quả
                    bool updateSuccessful = tourService.UpdateTour(tour);
                    if (updateSuccessful)
                    {
                        MessageBox.Show("Tour status updated successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Tour status update failed. Please try again.");
                    }
                }
                else
                {
                    MessageBox.Show("Tour not found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                ReloadTourData();
            }
        }

    }

}

