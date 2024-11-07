using KoiKingdom_BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiKingdom_Service
{
    public interface ITourbookingdetailService
    {
        public Tourbookingdetail GetTourBookingDetailById(int id);

        // Get all TourBookingDetails
        public List<Tourbookingdetail> GetTourBookingDetails();

        // Add a TourBookingDetail record
        public bool AddTourBookingDetail(int CustomerId, int TourId, int Quantity, decimal UnitPrice, decimal? TotalPrice, string? Status, string? TourType);
    }
}
