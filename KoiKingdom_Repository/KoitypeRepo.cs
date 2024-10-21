using KoiKingdom_BusinessObject;
using KoiKingdom_DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiKingdom_Repository
{
    public class KoitypeRepository : IKoitypeRepo
    {
        public Koitype GetKoitypeByName(string name) => KoitypeDAO.Instance.GetKoitypeByName(name);

        public bool AddKoitypeProfile(Koitype koitypeProfile)   => KoitypeDAO.Instance.AddKoitype(koitypeProfile);

        public bool DeleteKoitypeProfile(int koitypeID) => KoitypeDAO.Instance.DeleteKoitype(koitypeID); // Implemented

        public Koitype GetKoitypeById(int id) => KoitypeDAO.Instance.GetKoitypeById(id); // Implemented

        public List<Koitype> GetKoitypes()=> KoitypeDAO.Instance.GetKoitypes(); // Implemented

        public bool UpdateKoitypeProfile(Koitype koitypeProfile) => KoitypeDAO.Instance.UpdateKoitype(koitypeProfile); // Implemented
    }

}
