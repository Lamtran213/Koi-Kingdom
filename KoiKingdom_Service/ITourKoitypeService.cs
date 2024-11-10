using KoiKingdom_BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiKingdom_Service
{
    public interface ITourKoitypeService
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


        public List<string> GetKoiTypeNamesByTourId(Tour tour);
    }
}
