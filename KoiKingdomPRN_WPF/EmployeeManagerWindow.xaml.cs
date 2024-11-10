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
    /// Interaction logic for EmployeeManagerWindow.xaml
    /// </summary>
    public partial class EmployeeManagerWindow : Window
    {
        private IEmployeeService employeeService;

        public EmployeeManagerWindow()
        {
            InitializeComponent();
            employeeService = new EmployeeService();
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }
        private void ReloadEmployeeData()
        {
            this.dtgEmployee.ItemsSource = employeeService.GetEmployees().Select(a => new
            {
                a.EmployeeId,
                FullName = a.FirstName + " " + a.LastName,
                a.Address,
                a.Email,
                Status = (bool)a.Status ? "Active" : "Blocked"
            }).ToList();
        }

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            // Đảm bảo rằng dtgEmployee được khởi tạo đúng
            this.dtgEmployee.ItemsSource = employeeService.GetEmployees().Select(a => new
            {
                a.EmployeeId,
                FullName = a.FirstName + " " + a.LastName,
                a.Address,
                a.Email,
                Status = (bool)a.Status ? "Active" : "Blocked"
            }).ToList();
            ReloadEmployeeData();
        }

        private void dtgEmployee_SelectionChanged(object sender, SelectionChangedEventArgs e)
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

                            Employee EmployeeProfile = employeeService.GetEmployeeById(id);
                            if (EmployeeProfile != null)
                            {
                                txtEmployeeID.Text = EmployeeProfile.EmployeeId.ToString();
                                txtFullName.Text = $"{EmployeeProfile.FirstName} {EmployeeProfile.LastName}";
                                txtAddress.Text = EmployeeProfile.Address;
                                txtEmail.Text = EmployeeProfile.Email;

                                cmbStatus.SelectedItem = (bool)EmployeeProfile.Status ?
                                                          cmbStatus.Items.OfType<ComboBoxItem>().FirstOrDefault(item => item.Content.ToString() == "Active") :
                                                          cmbStatus.Items.OfType<ComboBoxItem>().FirstOrDefault(item => item.Content.ToString() == "Blocked");
                            }
                        }
                        catch (FormatException)
                        {
                            MessageBox.Show("Invalid Employee ID format.");
                        }
                        catch (OverflowException)
                        {
                            MessageBox.Show("Employee ID is out of range.");
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
            if (string.IsNullOrWhiteSpace(txtEmployeeID.Text))
            {
                MessageBox.Show("Please select a Employee to update.");
                return;
            }

            // Lấy ID của khách hàng
            int EmployeeId;
            if (!int.TryParse(txtEmployeeID.Text, out EmployeeId))
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
                Employee employee = employeeService.GetEmployeeById(EmployeeId);
                if (employee != null)
                {
                    // Kiểm tra nếu trạng thái mới khác với trạng thái hiện tại
                    if (employee.Status == isActive)
                    {
                        // Không thay đổi trạng thái, không thực hiện cập nhật
                        return;
                    }

                    // Nếu trạng thái mới khác, tiếp tục cập nhật
                    employee.Status = isActive;

                    // Cập nhật thông tin khách hàng và kiểm tra kết quả
                    bool updateSuccessful = employeeService.UpdateEmployeeProfile(employee);
                    if (updateSuccessful)
                    {
                        MessageBox.Show("Employee status updated successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Employee status update failed. Please try again.");
                    }
                }
                else
                {
                    MessageBox.Show("Employee not found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                ReloadEmployeeData();
            }
        }
    }
}
