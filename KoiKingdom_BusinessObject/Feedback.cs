using System;
using System.Collections.Generic;

namespace KoiKingdom_BusinessObject
{
    public partial class Feedback
    {
        public Feedback()
        {
            TourFeedbacks = new HashSet<TourFeedback>();
        }

        public int FeedbackId { get; set; }
        public int CustomerId { get; set; }
        public int? TourId { get; set; }
        public int Rating { get; set; }
        public string? FeedbackText { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual Customer Customer { get; set; } = null!;
        public virtual ICollection<TourFeedback> TourFeedbacks { get; set; }
    }
}
