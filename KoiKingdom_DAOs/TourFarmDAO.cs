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
        public TourFarm GetTourFarmById(int id)
        {
            return dbContext.TourFarms.SingleOrDefault(e => e.TourId == id);
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
        public bool AddTourFarm(TourFarm tourFarm)
        {
            bool isSuccess = false;
            try
            {
                if (tourFarm != null)
                {
                    TourFarm existingTourFarm = this.GetTourFarmById(tourFarm.TourId);
                    if (existingTourFarm == null) 
                    {
                        dbContext.TourFarms.Add(tourFarm);
                        dbContext.SaveChanges();
                        isSuccess = true;
                    }
                    else
                    {
                        throw new Exception("Tour Farm already exists.");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while adding the tour farm: " + ex.Message);
            }
            return isSuccess;
        }

        // Xóa hồ sơ tour farm theo ID
        public bool DeleteTourFarm(int tourId)
        {
            bool isSuccess = false;
            try
            {
                TourFarm tourFarm = this.GetTourFarmById(tourId);
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
                TourFarm existingTourFarm = this.GetTourFarmById(tourFarm.TourId);
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
