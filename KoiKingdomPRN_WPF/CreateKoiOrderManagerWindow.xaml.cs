using KoiKingdom_BusinessObject;
using KoiKingdom_Service;
using System;
using System.Windows;

namespace KoiKingdomPRN_WPF
{
    /// <summary>
    /// Interaction logic for CreateKoiOrderManagerWindow.xaml
    /// </summary>
    public partial class CreateKoiOrderManagerWindow : Window
    {
        private IKoiService koiService;
        private IKoitypeService koitypeService;
        private IFarmService farmService;
        private IKoiOrderService koiOrderService;
        private IKoiorderdetailService koiOrderdetailService;

        public CreateKoiOrderManagerWindow(IFarmService farmService, IKoitypeService koitypeService, IKoiService koiService, IKoiOrderService orderService, IKoiorderdetailService orderdetailService)
        {
            this.koitypeService = koitypeService;
            this.farmService = farmService;
            this.koiService = koiService;
            this.koiOrderService = orderService;
            this.koiOrderdetailService = orderdetailService;
            InitializeComponent();
            LoadList();
        }

        public void LoadList()
        {
            cmbKoiType.ItemsSource = koitypeService.GetKoitypes();
            cmbKoiType.DisplayMemberPath = "TypeName";
            cmbKoiType.SelectedValuePath = "KoiTypeId";

            cmbKoi.ItemsSource = koiService.GetKois();
            cmbKoi.DisplayMemberPath = "KoiName";
            cmbKoi.SelectedValuePath = "KoiId";

            cmbFarm.ItemsSource = farmService.GetFarms();
            cmbFarm.DisplayMemberPath = "FarmName";
            cmbFarm.SelectedValuePath = "FarmId";
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedFarmId = (int)cmbFarm.SelectedValue;
                var selectedKoiTypeId = (int)cmbKoiType.SelectedValue;
                var selectedKoiId = (int)cmbKoi.SelectedValue;
                var quantity = int.Parse(txtQuantity.Text);

                int customerId;
                if (!int.TryParse(txtCustomerID.Text, out customerId))
                {
                    MessageBox.Show("Please enter a valid customer ID.");
                    return;
                }

                var dateOrder = orderDate.SelectedDate;
                if (dateOrder == null)
                {
                    MessageBox.Show("Please select a valid order date.");
                    return;
                }

                var selectedKoi = cmbKoi.SelectedItem as Koi;
                if (selectedKoi == null)
                {
                    MessageBox.Show("Please select a valid Koi.");
                    return;
                }

                decimal unitPrice = selectedKoi.Price;
                decimal totalPrice = quantity * unitPrice;

                // Add KoiOrder and get the KoiOrderId
                int koiOrderId = koiOrderService.AddKoiReturnId(customerId, (DateTime)dateOrder, true, null);

                // Add KoiOrderDetail
                bool koiOrderDetailSuccess = koiOrderdetailService.AddKoiOrderDetail(koiOrderId, selectedKoiId, selectedFarmId, quantity, unitPrice, totalPrice);

                // Check if the order and order details were successfully added
                if (koiOrderDetailSuccess && koiOrderId != 0)
                {
                    MessageBox.Show("Koi Order added successfully.");

                    // Reset form controls after successful submission
                    ResetForm();
                }
                else
                {
                    MessageBox.Show("Failed to add the Koi Order details.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void ResetForm()
        {
            // Reset the form fields
            cmbFarm.SelectedIndex = -1;
            cmbKoiType.SelectedIndex = -1;
            cmbKoi.SelectedIndex = -1;
            txtCustomerID.Clear();
            txtQuantity.Clear();
            orderDate.SelectedDate = null;
        }


        private void Return_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
