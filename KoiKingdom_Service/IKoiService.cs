using KoiKingdom_BusinessObject;
using KoiKingdom_DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiKingdom_Service
{
    public interface IKoiService
    {
        public bool AddKoi(Koi koi) => KoiDAO.Instance.AddKoi(koi);

        public bool DeleteKoi(int koiId) => KoiDAO.Instance.DeleteKoi(koiId);

        public Koi GetKoiById(int id) => KoiDAO.Instance.GetKoiById(id);

        public List<Koi> GetKois() => KoiDAO.Instance.GetKois();

        public bool UpdateKoi(Koi koi) => KoiDAO.Instance.UpdateKoi(koi);
    }
}
