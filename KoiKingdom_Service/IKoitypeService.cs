using KoiKingdom_BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiKingdom_Service
{
    public interface IKoitypeService
    {
        Koitype GetKoitypeByName(string name);

        // Lấy koitype theo ID
        Koitype GetKoitypeById(int id);

        // Lấy danh sách tất cả koitype
        List<Koitype> GetKoitypes();

        // Thêm hồ sơ koitype
        bool AddKoitypeProfile(Koitype koitypeProfile);

        // Xóa hồ sơ koitype theo ID
        bool DeleteKoitypeProfile(int koitypeID);

        // Cập nhật hồ sơ koitype
        bool UpdateKoitypeProfile(Koitype koitypeProfile);
    }
}
