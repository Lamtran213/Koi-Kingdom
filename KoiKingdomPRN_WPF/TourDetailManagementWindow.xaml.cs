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
    /// Interaction logic for TourDetailManagementWindow.xaml
    /// </summary>
    public partial class TourDetailManagementWindow : Window
    {
        private ITourbookingdetailService tourbookingdetailService;
        private ICustomerService customerService;
        public TourDetailManagementWindow(KoiKingdom_Service.ITourbookingdetailService tourbookingdetailService, ICustomerService customerService)
        {
            InitializeComponent();
            this.tourbookingdetailService = tourbookingdetailService;
            this.customerService = customerService;
            LoadList();
        }

        private void LoadList()
        {
            // Retrieve the list of tour details
            List<Tourbookingdetail> tourDetails = tourbookingdetailService.GetTourBookingDetails();

            // Load customer information and combine with tour details using LINQ
            this.TourDetailDataGrid.ItemsSource = tourDetails.Select(tourDetail => new
            {
                TourBookingDetail1 = tourDetail.TourBookingDetail1, // Add the correct property here
                CustomerId = tourDetail.CustomerId,
                CustomerName = customerService.GetCustomerById(tourDetail.CustomerId)?.FirstName + " " +
                               customerService.GetCustomerById(tourDetail.CustomerId)?.LastName,
                TourId = tourDetail.TourId,
                Quantity = tourDetail.Quantity,
                UnitPrice = tourDetail.UnitPrice,
                TotalPrice = tourDetail.TotalPrice,
                Status = tourDetail.Status,
                TourType = tourDetail.TourType
            }).ToList();
        }

    }
}
