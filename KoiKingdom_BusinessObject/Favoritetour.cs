using System;
using System.Collections.Generic;

namespace KoiKingdom_BusinessObject
{
    public partial class Favoritetour
    {
        public int FavoriteTourId { get; set; }
        public int CustomerId { get; set; }
        public int TourId { get; set; }

        public virtual Customer Customer { get; set; } = null!;
        public virtual Tour Tour { get; set; } = null!;
    }
}
