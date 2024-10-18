using System;
using System.Collections.Generic;

namespace KoiKingdom_BusinessObject
{
    public partial class Farm
    {
        public Farm()
        {
            KoiFarms = new HashSet<KoiFarm>();
            Koiorderdetails = new HashSet<Koiorderdetail>();
            TourFarms = new HashSet<TourFarm>();
        }

        public int FarmId { get; set; }
        public string FarmName { get; set; } = null!;
        public string? Location { get; set; }
        public string? Description { get; set; }
        public string Image { get; set; } = null!;
        public bool? Status { get; set; }

        public virtual ICollection<KoiFarm> KoiFarms { get; set; }
        public virtual ICollection<Koiorderdetail> Koiorderdetails { get; set; }
        public virtual ICollection<TourFarm> TourFarms { get; set; }
    }
}
