using System;
using System.Collections.Generic;

namespace KoiKingdom_BusinessObject
{
    public partial class Koiorder
    {
        public Koiorder()
        {
            Koiorderdetails = new HashSet<Koiorderdetail>();
        }

        public int KoiOrderId { get; set; }
        public int CustomerId { get; set; }
        public DateTime DeliveryDate { get; set; }
        public bool Status { get; set; }
        public DateTime? EstimatedDelivery { get; set; }

        public virtual Customer Customer { get; set; } = null!;
        public virtual ICollection<Koiorderdetail> Koiorderdetails { get; set; }
    }
}
