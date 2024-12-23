﻿using KoiKingdom_BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiKingdom_Repository
{
    public interface IBookingRepo
    {
        public List<Booking> GetBooking(int CustomerId);
        public void AddBookingItem(int CustomerId, int TourId, string Name, string Email, DateTime BookingDate, string ShippingAddress, int Quantity, string Status, string? TourType);
    }
}
