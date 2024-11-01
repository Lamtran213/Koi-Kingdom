using KoiKingdom_BusinessObject;
using KoiKingdom_Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Xml.Linq;

namespace KoiKingdomPRN_WPF
{
    public partial class MyProfileModalWindow : Window
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private readonly ICustomerService customerService;

        public MyProfileModalWindow(Customer customer, ICustomerService customerService)
        {
            InitializeComponent();
            this.customerService = customerService; // Assign the service to the class variable
            Customer = customer; // Set the Customer property
            LoadList(customer.CustomerId); // Call the method to load data
            LoadProvincesAsync();
        }


        public Customer Customer { get; set; }

  

        // Load province list
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
                        ProvinceComboBox.Items.Clear(); // Xóa tất cả các mục trước khi thiết lập ItemsSource
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


        private void LoadList(int customerId)
        {
            try
            {
                

                // Retrieve the list of customers
                var customers = customerService.GetCustomers();

                // Check if the customers list is null or empty
                if (customers == null || !customers.Any())
                {
                    throw new InvalidOperationException("No customers found.");
                }

                // Find the customer profile based on CustomerId
                Customer customerProfile = customers.FirstOrDefault(t => t.CustomerId == customerId);

                if (customerProfile == null)
                {
                    throw new InvalidOperationException("No customer profile found for the given CustomerId.");
                }

                // Update the TextBoxes with customer information
                EmailTextBox.Text = customerProfile.Email ?? string.Empty;
                FirstNameTextBox.Text = customerProfile.FirstName ?? string.Empty;
                LastNameTextBox.Text = customerProfile.LastName ?? string.Empty;
                AddressTextBox.Text = customerProfile.Address ?? "Your address will appear here"; // Default address message
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading customer profile: {ex.Message}");
            }
        }


        private void SetFullAddressForProfile(Customer existingProfile)
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

        // Example usage when updating the profile
        private void Button_Update(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(EmailTextBox.Text))
                {
                    ICustomerService customerProfileService = new CustomerService();

                    Customer existingProfile = customerProfileService.GetCustomerByEmail(EmailTextBox.Text);

                    if (existingProfile != null)
                    {
                        existingProfile.Email = EmailTextBox.Text;
                        existingProfile.FirstName = FirstNameTextBox.Text;
                        existingProfile.LastName = LastNameTextBox.Text;

                        // Set the formatted address to include user input and selected location names
                        SetFullAddressForProfile(existingProfile);

                        bool isUpdated = customerProfileService.UpdateCustomerProfile(existingProfile);
                        if (isUpdated)
                        {
                            MessageBox.Show("Customer profile updated successfully.");
                        }
                        else
                        {
                            MessageBox.Show("Failed to update customer profile.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Customer not found.");
                    }
                }
                else
                {
                    MessageBox.Show("You must select a customer!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
            finally
            {
                LoadList(Customer.CustomerId);
            }
        }


    }

    // Model classes for API responses
    public class Province
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public List<District> Districts { get; set; }
    }

    public class District
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public List<Ward> Wards { get; set; }
    }

    public class Ward
    {
        public int Code { get; set; }
        public string Name { get; set; }
    }
}
