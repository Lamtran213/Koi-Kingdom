using KoiKingdom_BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiKingdom_DAOs
{
    public class TourDAO
    {
        private KOI_PRNContext dbContext;
        private static TourDAO instance;

        public TourDAO()
        {
            dbContext = new KOI_PRNContext();
        }

        // Singleton Pattern
        public static TourDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TourDAO();
                }
                return instance;
            }
        }

        // Lấy tour theo ID
        public Tour GetTourById(int id)
        {
            return dbContext.Tours.SingleOrDefault(e => e.TourId == id);
        }

        // Lấy danh sách tất cả tour
        public List<Tour> GetTours()
        {
            return dbContext.Tours.ToList();
        }

        // Thêm hồ sơ tour
        public bool AddTour(Tour tour)
        {
            bool isSuccess = false;
            try
            {
                if (tour != null)
                {
                    Tour existingTour = this.GetTourById(tour.TourId);
                    if (existingTour == null) // Chỉ thêm nếu chưa tồn tại
                    {
                        dbContext.Tours.Add(tour);
                        dbContext.SaveChanges();
                        isSuccess = true;
                    }
                    else
                    {
                        throw new Exception("Tour already exists.");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while adding the tour: " + ex.Message);
            }
            return isSuccess;
        }

        // Xóa hồ sơ tour theo ID
        public bool DeleteTour(int tourId)
        {
            bool isSuccess = false;
            try
            {
                Tour tour = this.GetTourById(tourId);
                if (tour != null)
                {
                    dbContext.Tours.Remove(tour);
                    dbContext.SaveChanges();
                    isSuccess = true;
                }
                else
                {
                    throw new Exception("Tour not found.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while deleting the tour: " + ex.Message);
            }
            return isSuccess;
        }

        // Cập nhật hồ sơ tour
        public bool UpdateTour(Tour tour)
        {
            bool isSuccess = false;
            try
            {
                Tour existingTour = this.GetTourById(tour.TourId);
                if (existingTour != null)
                {
                    dbContext.Entry(existingTour).CurrentValues.SetValues(tour);
                    dbContext.SaveChanges();
                    isSuccess = true;
                }
                else
                {
                    throw new Exception("Tour not found.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating the tour: " + ex.Message);
            }
            return isSuccess;
        }

  
    }
}
