using KoiKingdom_BusinessObject;
using KoiKingdom_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiKingdom_Service
{
    public class TourbookingdetailService : ITourbookingdetailService
    {

        private ITourbookingdetailRepo iTourbookingdetailRepo;

        public TourbookingdetailService()
        {
            iTourbookingdetailRepo = new TourbookingdetailRepo();
        }

        public bool AddTourBookingDetail(int CustomerId, int TourId, int Quantity, decimal UnitPrice, decimal? TotalPrice, string? Status, string? TourType)
        {
            return iTourbookingdetailRepo.AddTourBookingDetail(CustomerId, TourId, Quantity, UnitPrice, TotalPrice, Status, TourType);
        }

        public Tourbookingdetail GetTourBookingDetailById(int id)
        {
            return iTourbookingdetailRepo.GetTourBookingDetailById(id);
        }

        public List<Tourbookingdetail> GetTourBookingDetails()
        {
            return iTourbookingdetailRepo.GetTourBookingDetails();
        }
    }
}
