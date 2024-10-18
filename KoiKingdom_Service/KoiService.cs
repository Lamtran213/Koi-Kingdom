using KoiKingdom_BusinessObject;
using KoiKingdom_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiKingdom_Service
{
    public class KoiService : IKoiService
    {
        private IKoiRepo iKoiRepo;

        // Sửa tên constructor thành KoiService
        public KoiService()
        {
            iKoiRepo = new KoiRepo();
        }

        // Lấy Koi theo ID
        public Koi GetKoiById(int id)
        {
            return iKoiRepo.GetKoiById(id);
        }

        // Lấy danh sách tất cả Koi
        public List<Koi> GetKois()
        {
            return iKoiRepo.GetKois();
        }

        // Thêm Koi
        public bool AddKoi(Koi koi)
        {
            return iKoiRepo.AddKoi(koi);
        }

        // Cập nhật hồ sơ Koi
        public bool UpdateKoi(Koi koi)
        {
            return iKoiRepo.UpdateKoi(koi);
        }

        // Xóa Koi theo ID
        public bool DeleteKoi(int koiId)
        {
            return iKoiRepo.DeleteKoi(koiId);
        }
    }
}
