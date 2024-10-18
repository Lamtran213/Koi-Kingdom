using System;
using System.Collections.Generic;

namespace KoiKingdom_BusinessObject
{
    public partial class Koi
    {
        public Koi()
        {
            KoiFarms = new HashSet<KoiFarm>();
            Koiorderdetails = new HashSet<Koiorderdetail>();
        }

        public int KoiId { get; set; }
        public string KoiName { get; set; } = null!;
        public int KoiTypeId { get; set; }
        public int Age { get; set; }
        public decimal Length { get; set; }
        public decimal Weight { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; } = null!;

        public virtual Koitype KoiType { get; set; } = null!;
        public virtual ICollection<KoiFarm> KoiFarms { get; set; }
        public virtual ICollection<Koiorderdetail> Koiorderdetails { get; set; }
    }
}
