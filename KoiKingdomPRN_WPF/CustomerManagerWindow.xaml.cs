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
using System.Xml.Linq;

namespace KoiKingdomPRN_WPF
{
    /// <summary>
    /// Interaction logic for CustomerManagerWindow.xaml
    /// </summary>
    public partial class CustomerManagerWindow : Window
    {
        private ICustomerService customerService;

        public CustomerManagerWindow()
        {
            InitializeComponent();
            customerService = new CustomerService();
        }

        private void ReloadCustomerData()
        {
            this.dtgCustomer.ItemsSource = customerService.GetCustomers().Select(a => new
            {
                a.CustomerId,
                FullName = a.FirstName + " " + a.LastName,
                a.Address,
                a.Email,
                a.AccountType,
                Status = (bool)a.Status ? "Active" : "Blocked"
            }).ToList();
        }



        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            // Đảm bảo rằng dtgCustomer được khởi tạo đúng
            this.dtgCustomer.ItemsSource = customerService.GetCustomers().Select(a => new
            {
                a.CustomerId,
                FullName = a.FirstName + " " + a.LastName,
                a.Address,
                a.Email,
                a.AccountType,
                Status = (bool)a.Status ? "Active" : "Blocked"
            }).ToList();
            ReloadCustomerData();
        }



        private void dtgCustomer_SelectionChanged(object sender, SelectionChangedEventArgs e)
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

                            Customer customerProfile = customerService.GetCustomerById(id);
                            if (customerProfile != null)
                            {
                                txtCustomerID.Text = customerProfile.CustomerId.ToString();
                                txtFullName.Text = $"{customerProfile.FirstName} {customerProfile.LastName}";
                                txtAddress.Text = customerProfile.Address;
                                txtEmail.Text = customerProfile.Email;
                                txtAccountType.Text = customerProfile.AccountType;

                                cmbStatus.SelectedItem = (bool)customerProfile.Status ?
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
            if (string.IsNullOrWhiteSpace(txtCustomerID.Text))
            {
                MessageBox.Show("Please select a customer to update.");
                return;
            }

            // Lấy ID của khách hàng
            int customerId;
            if (!int.TryParse(txtCustomerID.Text, out customerId))
            {
                MessageBox.Show("Invalid Customer ID.");
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
                Customer customer = customerService.GetCustomerById(customerId);
                if (customer != null)
                {
                    // Kiểm tra nếu trạng thái mới khác với trạng thái hiện tại
                    if (customer.Status == isActive)
                    {
                        // Không thay đổi trạng thái, không thực hiện cập nhật
                        return;
                    }

                    // Nếu trạng thái mới khác, tiếp tục cập nhật
                    customer.Status = isActive;

                    // Cập nhật thông tin khách hàng và kiểm tra kết quả
                    bool updateSuccessful = customerService.UpdateCustomerProfile(customer);
                    if (updateSuccessful)
                    {
                        MessageBox.Show("Customer status updated successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Customer status update failed. Please try again.");
                    }
                }
                else
                {
                    MessageBox.Show("Customer not found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                ReloadCustomerData();
            }
        }


    }
}
