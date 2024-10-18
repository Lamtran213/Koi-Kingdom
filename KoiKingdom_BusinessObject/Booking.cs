using System;
using System.Collections.Generic;

namespace KoiKingdom_BusinessObject
{
    public partial class Booking
    {
        public int BookingId { get; set; }
        public int CustomerId { get; set; }
        public int TourId { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public DateTime BookingDate { get; set; }
        public string ShippingAddress { get; set; } = null!;
        public int Quantity { get; set; }
        public string Status { get; set; } = null!;
        public string? TourType { get; set; }

        public virtual Customer Customer { get; set; } = null!;
        public virtual Tour Tour { get; set; } = null!;
    }
}
