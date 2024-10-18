using System;
using System.Collections.Generic;

namespace KoiKingdom_BusinessObject
{
    public partial class TourFeedback
    {
        public int TourFeedbackId { get; set; }
        public int TourId { get; set; }
        public int FeedbackId { get; set; }

        public virtual Feedback Feedback { get; set; } = null!;
        public virtual Tour Tour { get; set; } = null!;
    }
}
