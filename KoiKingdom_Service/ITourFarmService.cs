using KoiKingdom_BusinessObject;
using KoiKingdom_DAOs;
using System.Collections.Generic;

namespace KoiKingdom_Service
{
    public interface ITourFarmService
    {
        // Lấy tour farm theo ID
        TourFarm GetTourFarmById(int tourId, int farmId);

        // Lấy danh sách tất cả tour farms
        List<TourFarm> GetTourFarms();

        // Thêm hồ sơ tour farm
        public TourFarm AddTourFarm(int tourId, int farmId);

        // Xóa hồ sơ tour farm theo ID
        bool DeleteTourFarm(int tourId, int farmId);

        // Cập nhật hồ sơ tour farm
        bool UpdateTourFarm(TourFarm tourFarm);

        public List<string> GetFarmNamesByTourId(Tour tour);
    }
}
