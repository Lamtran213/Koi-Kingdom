using KoiKingdom_BusinessObject;
using KoiKingdom_DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiKingdom_Repository
{
    public class BookingRepo : IBookingRepo
    {
        public List<Booking> GetBooking(int CustomerId) => BookingDAO.Instance.GetBooking(CustomerId);
        public void AddBookingItem(int CustomerId, int TourId, string Name, string Email, DateTime BookingDate, string ShippingAddress, int Quantity, string Status, string? TourType) => BookingDAO.Instance.AddBookingItem(CustomerId, TourId, Name, Email, BookingDate, ShippingAddress, Quantity, Status, TourType);
    }
}
