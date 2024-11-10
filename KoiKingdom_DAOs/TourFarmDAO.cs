using KoiKingdom_BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiKingdom_DAOs
{
    public class TourFarmDAO
    {
        private KOI_PRNContext dbContext;
        private static TourFarmDAO instance;

        public TourFarmDAO()
        {
            dbContext = new KOI_PRNContext();
        }

        // Singleton Pattern
        public static TourFarmDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TourFarmDAO();
                }
                return instance;
            }
        }

        // Lấy tour farm theo ID
        public TourFarm GetTourFarmById(int tourid, int farmid)
        {
            return dbContext.TourFarms.SingleOrDefault(tf => tf.TourId == tourid && tf.FarmId == farmid);
        }

        public List<string> GetFarmNamesByTourId(Tour tour)
        {
            return dbContext.TourFarms
                            .Where(f => f.TourId == tour.TourId)
                            .Select(f => f.Farm.FarmName) // Giả sử Farm là đối tượng liên kết và có thuộc tính Name
                            .ToList();
        }

        // Lấy danh sách tất cả tour farms
        public List<TourFarm> GetTourFarms()
        {
            return dbContext.TourFarms
                .Include(tf => tf.Tour) 
                .Include(tf => tf.Farm) 
                .ToList();
        }


        // Thêm hồ sơ tour farm
        public TourFarm AddTourFarm(int tourId, int farmId)
        {
            TourFarm tourFarm = new TourFarm
            {
                TourId = tourId,
                FarmId = farmId
            };

            // Kiểm tra xem TourFarm đã tồn tại chưa
            TourFarm existingTourFarm = this.GetTourFarmById(tourId, farmId);
            if (existingTourFarm == null)
            {
                dbContext.TourFarms.Add(tourFarm); // Thêm TourFarm vào dbContext
                dbContext.SaveChanges(); // Lưu thay đổi vào cơ sở dữ liệu
                return tourFarm; // Trả về đối tượng TourFarm đã thêm
            }
            else
            {
                throw new Exception("Tour Farm already exists."); // Ném ra lỗi nếu đã tồn tại
            }
        }




        // Xóa hồ sơ tour farm theo ID
        // Xóa hồ sơ tour farm theo ID
        public bool DeleteTourFarm(int tourId, int farmId)
        {
            bool isSuccess = false;
            try
            {
                TourFarm tourFarm = this.GetTourFarmById(tourId, farmId); // Use both IDs to find the TourFarm
                if (tourFarm != null)
                {
                    dbContext.TourFarms.Remove(tourFarm);
                    dbContext.SaveChanges();
                    isSuccess = true;
                }
                else
                {
                    throw new Exception("Tour Farm not found.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while deleting the tour farm: " + ex.Message);
            }
            return isSuccess;
        }

        // Cập nhật hồ sơ tour farm
        public bool UpdateTourFarm(TourFarm tourFarm)
        {
            bool isSuccess = false;
            try
            {
                TourFarm existingTourFarm = this.GetTourFarmById(tourFarm.TourId, tourFarm.FarmId); // Use both IDs
                if (existingTourFarm != null)
                {
                    dbContext.Entry(existingTourFarm).CurrentValues.SetValues(tourFarm);
                    dbContext.SaveChanges();
                    isSuccess = true;
                }
                else
                {
                    throw new Exception("Tour Farm not found.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating the tour farm: " + ex.Message);
            }
            return isSuccess;
        }
    }
}
