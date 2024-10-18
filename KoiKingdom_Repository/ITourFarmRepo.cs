using KoiKingdom_BusinessObject;
using System;
using System.Collections.Generic;

namespace KoiKingdom_Repository
{
    public interface ITourFarmRepo
    {
        // Lấy tour farm theo ID
        TourFarm GetTourFarmById(int id);

        // Lấy danh sách tất cả tour farms
        List<TourFarm> GetTourFarms();

        // Thêm hồ sơ tour farm
        bool AddTourFarm(TourFarm tourFarm);

        // Xóa hồ sơ tour farm theo ID
        bool DeleteTourFarm(int tourId);

        // Cập nhật hồ sơ tour farm
        bool UpdateTourFarm(TourFarm tourFarm);
    }
}
