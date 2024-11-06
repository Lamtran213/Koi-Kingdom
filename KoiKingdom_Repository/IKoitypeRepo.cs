using KoiKingdom_BusinessObject;
using System;
using System.Collections.Generic;

namespace KoiKingdom_Repository
{
    public interface IKoitypeRepo
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

       List<string> GetKoitypesName();

    }
}
