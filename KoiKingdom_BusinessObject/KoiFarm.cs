using System;
using System.Collections.Generic;

namespace KoiKingdom_BusinessObject
{
    public partial class KoiFarm
    {
        public int KoiFarmId { get; set; }
        public int KoiId { get; set; }
        public int FarmId { get; set; }

        public virtual Farm Farm { get; set; } = null!;
        public virtual Koi Koi { get; set; } = null!;
    }
}
