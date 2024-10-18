using System;
using System.Collections.Generic;

namespace KoiKingdom_BusinessObject
{
    public partial class Customtourrequest
    {
        public int RequestId { get; set; }
        public int CustomerId { get; set; }
        public string FullName { get; set; } = null!;
        public string? Duration { get; set; }
        public decimal? QuotationPrice { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Status { get; set; }
        public string? ManagerApprovalStatus { get; set; }
        public string DepartureLocation { get; set; } = null!;
        public string FarmName { get; set; } = null!;
        public string KoiTypeName { get; set; } = null!;
        public int Quantity { get; set; }
        public string Image { get; set; } = null!;
        public string? DetailRejected { get; set; }
        public bool? Checked { get; set; }

        public virtual Customer Customer { get; set; } = null!;
    }
}
