using KoiKingdom_BusinessObject;
using KoiKingdom_DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiKingdom_Repository
{
    public class KoiRepo : IKoiRepo
    {
        // Thêm Koi
        public bool AddKoi(Koi koi) => KoiDAO.Instance.AddKoi(koi);

        // Xóa Koi theo ID
        public bool DeleteKoi(int koiId) => KoiDAO.Instance.DeleteKoi(koiId);

        // Lấy Koi theo ID
        public Koi GetKoiById(int id) => KoiDAO.Instance.GetKoiById(id);

        // Lấy danh sách tất cả các Koi
        public List<Koi> GetKois() => KoiDAO.Instance.GetKois();

        // Cập nhật hồ sơ Koi
        public bool UpdateKoi(Koi koi) => KoiDAO.Instance.UpdateKoi(koi);
    }
}
