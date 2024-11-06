using KoiKingdom_BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiKingdom_Repository
{
    public interface IKoiRepo
    {
        // Get Koi by ID
        public Koi GetKoiById(int id);

        public List<Koi> GetKois();

        // Add Koi profile
        public bool AddKoi(Koi koiProfile);

        // Delete Koi profile by ID
        public bool DeleteKoi(int koiID);

        public List<string> GetKoisName();

        // Update Koi profile
        public bool UpdateKoi(Koi koiProfile); // Added missing semicolon
    }
}
