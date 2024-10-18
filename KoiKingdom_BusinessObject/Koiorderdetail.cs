using System;
using System.Collections.Generic;

namespace KoiKingdom_BusinessObject
{
    public partial class Koiorderdetail
    {
        public int KoiOrderDetailId { get; set; }
        public int KoiOrderId { get; set; }
        public int KoiId { get; set; }
        public int FarmId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal? TotalPrice { get; set; }

        public virtual Farm Farm { get; set; } = null!;
        public virtual Koi Koi { get; set; } = null!;
        public virtual Koiorder KoiOrder { get; set; } = null!;
    }
}
