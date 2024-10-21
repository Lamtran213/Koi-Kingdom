using KoiKingdom_BusinessObject;
using KoiKingdom_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiKingdom_Service
{
    public class KoitypeService : IKoitypeService // Changed to class and corrected interface name
    {
        private IKoitypeRepo iKoitypeRepo; // Changed to IKoitypeRepo

        // Constructor
        public KoitypeService() // Changed to KoitypeService
        {
            iKoitypeRepo = new KoitypeRepository(); // Changed to KoitypeRepo
        }

        // Lấy Koitype theo ID
        public Koitype GetKoitypeById(int id)
        {
            return iKoitypeRepo.GetKoitypeById(id); // Changed method call
        }

        // Lấy danh sách tất cả Koitype
        public List<Koitype> GetKoitypes()
        {
            return iKoitypeRepo.GetKoitypes(); // Changed method call
        }

        public bool AddKoitypeProfile(Koitype koitypeProfile)
        {
            return iKoitypeRepo.AddKoitypeProfile(koitypeProfile);
        }

        public bool DeleteKoitypeProfile(int koitypeID)
        {
            return iKoitypeRepo.DeleteKoitypeProfile(koitypeID);
        }

        public bool UpdateKoitypeProfile(Koitype koitypeProfile)
        {
            return iKoitypeRepo.UpdateKoitypeProfile(koitypeProfile);
        }

        public Koitype GetKoitypeByName(string name)
        {
            return iKoitypeRepo.GetKoitypeByName(name);
        }
    }

}
