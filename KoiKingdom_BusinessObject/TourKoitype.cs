using System;
using System.Collections.Generic;

namespace KoiKingdom_BusinessObject
{
    public partial class TourKoitype
    {
        public int TourKoiTypeId { get; set; }
        public int TourId { get; set; }
        public int KoiTypeId { get; set; }

        public virtual Koitype KoiType { get; set; } = null!;
        public virtual Tour Tour { get; set; } = null!;
    }
}
