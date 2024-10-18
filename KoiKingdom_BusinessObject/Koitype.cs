using System;
using System.Collections.Generic;

namespace KoiKingdom_BusinessObject
{
    public partial class Koitype
    {
        public Koitype()
        {
            KoiPrns = new HashSet<Koi>();
            TourKoitypes = new HashSet<TourKoitype>();
        }

        public int KoiTypeId { get; set; }
        public string TypeName { get; set; } = null!;
        public string? Description { get; set; }
        public string Image { get; set; } = null!;
        public bool? KoiTypeStatus { get; set; }

        public virtual ICollection<Koi> KoiPrns { get; set; }
        public virtual ICollection<TourKoitype> TourKoitypes { get; set; }
    }
}
