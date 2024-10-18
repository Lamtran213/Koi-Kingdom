using System;
using System.Collections.Generic;

namespace KoiKingdom_BusinessObject
{
    public partial class Tour
    {
        public Tour()
        {
            Bookings = new HashSet<Booking>();
            Favoritetours = new HashSet<Favoritetour>();
            TourFarms = new HashSet<TourFarm>();
            TourFeedbacks = new HashSet<TourFeedback>();
            TourKoitypes = new HashSet<TourKoitype>();
        }

        public int TourId { get; set; }
        public string TourName { get; set; } = null!;
        public string Duration { get; set; } = null!;
        public string? Description { get; set; }
        public decimal? TourPrice { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Image { get; set; } = null!;
        public string? Status { get; set; }
        public string? DepartureLocation { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<Favoritetour> Favoritetours { get; set; }
        public virtual ICollection<TourFarm> TourFarms { get; set; }
        public virtual ICollection<TourFeedback> TourFeedbacks { get; set; }
        public virtual ICollection<TourKoitype> TourKoitypes { get; set; }
    }
}
