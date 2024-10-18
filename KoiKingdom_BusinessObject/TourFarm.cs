using System;
using System.Collections.Generic;

namespace KoiKingdom_BusinessObject
{
    public partial class TourFarm
    {
        public int TourFarmId { get; set; }
        public int TourId { get; set; }
        public int FarmId { get; set; }

        public virtual Farm Farm { get; set; } = null!;
        public virtual Tour Tour { get; set; } = null!;
    }
}
