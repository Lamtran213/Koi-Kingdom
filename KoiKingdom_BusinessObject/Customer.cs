using System;
using System.Collections.Generic;

namespace KoiKingdom_BusinessObject
{
    public partial class Customer
    {
        public Customer()
        {
            Bookings = new HashSet<Booking>();
            Favoritetours = new HashSet<Favoritetour>();
            Feedbacks = new HashSet<Feedback>();
            Koiorders = new HashSet<Koiorder>();
        }

        public int CustomerId { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string? Address { get; set; }
        public string? AccountType { get; set; }
        public bool? Status { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<Favoritetour> Favoritetours { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
        public virtual ICollection<Koiorder> Koiorders { get; set; }
    }
}
