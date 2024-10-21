using KoiKingdom_BusinessObject;
using System.Collections.Generic;

namespace KoiKingdom_Repository
{
    public interface ITourKoitypeRepo
    {
        // Lấy tour koitype theo ID
        TourKoitype GetTourKoitypeById(int tourId, int koiTypeId);

        // Lấy danh sách tất cả tour koitypes
        List<TourKoitype> GetTourKoitypes();

        // Thêm hồ sơ tour koitype
        TourKoitype AddTourKoitype(int tourId, int koiTypeId);

        // Xóa hồ sơ tour koitype theo ID
        bool DeleteTourKoitype(int tourId, int koiTypeId);

        // Cập nhật hồ sơ tour koitype
        bool UpdateTourKoitype(TourKoitype tourKoitype);
    }
}
