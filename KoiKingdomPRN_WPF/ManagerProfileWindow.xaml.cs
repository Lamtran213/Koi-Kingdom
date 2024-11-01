using KoiKingdom_BusinessObject;
using KoiKingdom_Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
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
    /// Interaction logic for ManagerProfileWindow.xaml
    /// </summary>
    public partial class ManagerProfileWindow : Window
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private readonly IEmployeeService employeeService;

        public ManagerProfileWindow(KoiKingdom_BusinessObject.Employee employee, IEmployeeService employeeService)
        {
            InitializeComponent();
            this.employeeService = employeeService; // Assign the service to the class variable
            Employee = employee;
            LoadProvincesAsync();
            LoadList(employee.EmployeeId);
        }

        public Employee Employee { get; set; }

        private async Task LoadProvincesAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("https://provinces.open-api.vn/api/p");

                if (response.IsSuccessStatusCode)
                {
                    var provinces = await response.Content.ReadFromJsonAsync<List<Province>>();
                    if (provinces != null)
                    {
                        ProvinceComboBox.Items.Clear(); // Clear all items before setting ItemsSource
                        ProvinceComboBox.ItemsSource = provinces;
                        ProvinceComboBox.DisplayMemberPath = "Name";
                        ProvinceComboBox.SelectedValuePath = "Code";
                    }
                    else
                    {
                        MessageBox.Show("Không nhận được dữ liệu cho các tỉnh.");
                    }
                }
                else
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Không thể tải các tỉnh. Mã trạng thái: {response.StatusCode}. Lỗi: {errorContent}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải các tỉnh: {ex.Message}");
            }
        }

        // Load district list based on selected province
        private async void ProvinceComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ProvinceComboBox.SelectedValue is int provinceId)
            {
                try
                {
                    var districts = await LoadDistrictsAsync(provinceId);
                    DistrictComboBox.ItemsSource = null;
                    DistrictComboBox.Items.Clear();
                    DistrictComboBox.ItemsSource = districts;
                    DistrictComboBox.DisplayMemberPath = "Name";
                    DistrictComboBox.SelectedValuePath = "Code";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading districts: {ex.Message}");
                }
            }
        }

        private async Task<List<District>> LoadDistrictsAsync(int provinceId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"https://provinces.open-api.vn/api/p/{provinceId}?depth=2");
                if (response.IsSuccessStatusCode)
                {
                    var province = await response.Content.ReadFromJsonAsync<Province>();
                    return province?.Districts ?? new List<District>();
                }
                else
                {
                    MessageBox.Show("Failed to load districts.");
                    return new List<District>();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading districts: {ex.Message}");
                return new List<District>();
            }
        }

        // Load ward list based on selected district
        private async void DistrictComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DistrictComboBox.SelectedValue is int districtId)
            {
                try
                {
                    // Load wards for the selected district
                    var wards = await LoadWardsAsync(districtId);

                    // Set WardComboBox with the retrieved wards
                    WardComboBox.ItemsSource = null;   // Clear old items
                    WardComboBox.Items.Clear();        // Clear all items
                    WardComboBox.ItemsSource = wards;
                    WardComboBox.DisplayMemberPath = "Name";
                    WardComboBox.SelectedValuePath = "Code";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading wards: {ex.Message}");
                }
            }
        }

        private async Task<List<Ward>> LoadWardsAsync(int districtId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"https://provinces.open-api.vn/api/d/{districtId}?depth=2");

                if (response.IsSuccessStatusCode)
                {
                    var district = await response.Content.ReadFromJsonAsync<District>();
                    return district?.Wards ?? new List<Ward>();
                }
                else
                {
                    MessageBox.Show("Failed to load wards.");
                    return new List<Ward>();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading wards: {ex.Message}");
                return new List<Ward>();
            }
        }

        private void LoadList(int EmployeeId)
        {
            try
            {
                // Retrieve the list of employees
                var employees = employeeService.GetEmployees();

                // Check if the employees list is null or empty
                if (employees == null || !employees.Any())
                {
                    throw new InvalidOperationException("No employees found.");
                }

                // Find the employee profile based on EmployeeId
                Employee employeeProfile = employees.FirstOrDefault(t => t.EmployeeId == EmployeeId);

                if (employeeProfile == null)
                {
                    throw new InvalidOperationException("No employee profile found for the given EmployeeId.");
                }

                // Update the TextBoxes with employee information
                EmailTextBox.Text = employeeProfile.Email ?? string.Empty;
                FirstNameTextBox.Text = employeeProfile.FirstName ?? string.Empty;
                LastNameTextBox.Text = employeeProfile.LastName ?? string.Empty;
                AddressTextBox.Text = employeeProfile.Address ?? "Your address will appear here"; // Default address message
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading employee profile: {ex.Message}");
            }
        }

        private void SetFullAddressForProfile(Employee existingProfile)
        {
            // Retrieve the user-entered part of the address
            string userAddress = AddressTextBox.Text.Trim();

            // Get selected values from the ComboBoxes
            string wardName = WardComboBox.SelectedItem is Ward ward ? ward.Name : "";
            string districtName = DistrictComboBox.SelectedItem is District district ? district.Name : "";
            string provinceName = ProvinceComboBox.SelectedItem is Province province ? province.Name : "";

            // Format the address as: "123, WardName, DistrictName, ProvinceName"
            existingProfile.Address = $"{userAddress}, {wardName}, {districtName}, {provinceName}".Trim(new char[] { ',', ' ' });
        }
        private void Button_Update(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(EmailTextBox.Text))
                {
                    IEmployeeService employeeProfileService = new EmployeeService();

                    Employee existingProfile = employeeProfileService.GetEmployeeByEmail(EmailTextBox.Text);

                    if (existingProfile != null)
                    {
                        existingProfile.Email = EmailTextBox.Text;
                        existingProfile.FirstName = FirstNameTextBox.Text;
                        existingProfile.LastName = LastNameTextBox.Text;

                        // Set the formatted address to include user input and selected location names
                        SetFullAddressForProfile(existingProfile);

                        bool isUpdated = employeeProfileService.UpdateEmployeeProfile(existingProfile);
                        if (isUpdated)
                        {
                            MessageBox.Show("Employee profile updated successfully.");
                        }
                        else
                        {
                            MessageBox.Show("Failed to update employee profile.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Employee not found.");
                    }
                }
                else
                {
                    MessageBox.Show("You must select an employee!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
            finally
            {
                LoadList(Employee.EmployeeId); // Load the employee profile again after the update
            }
        }
    }
}
