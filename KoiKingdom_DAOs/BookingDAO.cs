using KoiKingdom_BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiKingdom_DAOs
{
    public  class BookingDAO
    {
        private KOI_PRNContext dbContext;
        private static BookingDAO instance;

        public BookingDAO()
        {
            dbContext = new KOI_PRNContext();
        }

        public static BookingDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BookingDAO();
                }
                return instance;
            }
        }

        public void AddBookingItem(int CustomerId, int TourId, string Name, string Email, DateTime BookingDate, string ShippingAddress, int Quantity, string Status, string? TourType)
        {
            // Directly add the new booking item to the database (without checking if the item already exists)
            Booking newItem = new Booking
            {
                CustomerId = CustomerId,
                TourId = TourId,
                Name = Name,
                Email = Email,
                BookingDate = BookingDate,
                ShippingAddress = ShippingAddress,
                Quantity = Quantity,
                Status = Status,
                TourType = TourType
            };

            // Add the new item to the database
            dbContext.Bookings.Add(newItem);

            // Save the changes to the database
            dbContext.SaveChanges();
        }
    }
}
