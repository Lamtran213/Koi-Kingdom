using KoiKingdom_BusinessObject;
using KoiKingdom_DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiKingdom_Repository
{
    public class TourbookingdetailRepo : ITourbookingdetailRepo
    {
        public bool AddTourBookingDetail(int CustomerId, int TourId, int Quantity, decimal UnitPrice, decimal? TotalPrice, string? Status, string? TourType)=> TourbookingdetailDAO.Instance.AddTourBookingDetail(CustomerId, TourId, Quantity, UnitPrice, TotalPrice, Status, TourType);   

        public Tourbookingdetail GetTourBookingDetailById(int id) => TourbookingdetailDAO.Instance.GetTourBookingDetailById(id);

        public List<Tourbookingdetail> GetTourBookingDetails() => TourbookingdetailDAO.Instance.GetTourBookingDetails();
    }
}
