using System;
using System.Collections.Generic;

namespace KoiKingdom_BusinessObject
{
    public partial class Tourbookingdetail
    {
        public int TourBookingDetail1 { get; set; }
        public int CustomerId { get; set; }
        public int TourId { get; set; }
        public int Quantity { get; set; }
        public decimal? UnitPrice { get; set; }
        public decimal? TotalPrice { get; set; }
        public string? Status { get; set; }
        public string? TourType { get; set; }
    }
}
