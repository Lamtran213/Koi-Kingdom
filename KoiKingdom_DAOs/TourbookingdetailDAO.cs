using KoiKingdom_BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiKingdom_DAOs
{
    public class TourbookingdetailDAO
    {
        private KOI_PRNContext dbContext;
        private static TourbookingdetailDAO instance;

        public TourbookingdetailDAO()
        {
            dbContext = new KOI_PRNContext();
        }

        // Singleton Pattern
        public static TourbookingdetailDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TourbookingdetailDAO();
                }
                return instance;
            }
        }

        // Get TourBookingDetail by ID
        public Tourbookingdetail GetTourBookingDetailById(int id)
        {
            return dbContext.Tourbookingdetails.SingleOrDefault(e => e.TourBookingDetail1 == id);
        }

        // Get all TourBookingDetails
        public List<Tourbookingdetail> GetTourBookingDetails()
        {
            return dbContext.Tourbookingdetails.ToList();
        }

        // Add a TourBookingDetail record
        public bool AddTourBookingDetail(int CustomerId, int TourId, int Quantity, decimal UnitPrice, decimal? TotalPrice, string? Status, string? TourType)
        {
            bool isSuccess = false;
            try
            {
                // Create a new TourBookingDetail instance
                Tourbookingdetail tourBookingDetail = new Tourbookingdetail
                {
                    CustomerId = CustomerId,
                    TourId = TourId,
                    Quantity = Quantity,
                    UnitPrice = UnitPrice,
                    TotalPrice = TotalPrice,
                    Status = Status,
                    TourType = TourType
                };

                // Check if a booking detail with the same ID already exists
                Tourbookingdetail existingBookingDetail = this.GetTourBookingDetailById(tourBookingDetail.TourBookingDetail1);
                if (existingBookingDetail == null) // Only add if it doesn't exist
                {
                    dbContext.Tourbookingdetails.Add(tourBookingDetail);
                    dbContext.SaveChanges();
                    isSuccess = true;
                }
                else
                {
                    throw new Exception("Tour Booking Detail already exists.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while adding the tour booking detail: " + ex.Message);
            }
            return isSuccess;
        }
    }
}
