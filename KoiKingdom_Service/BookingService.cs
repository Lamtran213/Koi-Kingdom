﻿using KoiKingdom_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiKingdom_Service
{
    public class BookingService : IBookingService
    {
        private IBookingRepo iBookingRepo;

        public BookingService()
        {
            iBookingRepo = new BookingRepo();
        }

        public void AddBookingItem(int CustomerId, int TourId, string Name, string Email, DateTime BookingDate, string ShippingAddress, int Quantity, string Status, string? TourType)
        {
            iBookingRepo.AddBookingItem(CustomerId, TourId, Name, Email, BookingDate, ShippingAddress, Quantity, Status, TourType);
        }
    }
}
