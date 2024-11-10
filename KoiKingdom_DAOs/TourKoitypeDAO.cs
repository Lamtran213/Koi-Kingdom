using KoiKingdom_BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KoiKingdom_DAOs
{
    public class TourKoitypeDAO
    {
        private KOI_PRNContext dbContext;
        private static TourKoitypeDAO instance;

        // Constructor
        private TourKoitypeDAO()
        {
            dbContext = new KOI_PRNContext();
        }

        // Singleton Pattern
        public static TourKoitypeDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TourKoitypeDAO();
                }
                return instance;
            }
        }

        // Lấy tour koitype theo ID
        public TourKoitype GetTourKoitypeById(int tourId, int koiTypeId)
        {
            return dbContext.TourKoitypes.SingleOrDefault(e => e.TourId == tourId && e.KoiTypeId == koiTypeId);
        }

        public List<string> GetKoiTypeNamesByTourId(Tour tour)
        {
            return dbContext.TourKoitypes
                            .Where(f => f.TourId == tour.TourId)
                            .Select(f => f.KoiType.TypeName) // Giả sử Farm là đối tượng liên kết và có thuộc tính Name
                            .ToList();
        }

        // Thêm hồ sơ tour koitype
        public TourKoitype AddTourKoitype(int tourId, int koiTypeId)
        {
            try
            {
                // Create a new TourKoitype instance
                TourKoitype tourKoitype = new TourKoitype
                {
                    TourId = tourId,
                    KoiTypeId = koiTypeId
                };

                // Check if the TourKoitype already exists
                TourKoitype existingTourKoitype = this.GetTourKoitypeById(tourId, koiTypeId);
                if (existingTourKoitype == null)
                {
                    dbContext.TourKoitypes.Add(tourKoitype); // Add the new TourKoitype to the context
                    dbContext.SaveChanges(); // Save changes to the database

                    return tourKoitype; // Return the newly created TourKoitype
                }
                else
                {
                    throw new Exception("Tour Koitype already exists."); // Error if it already exists
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while adding the tour koitype: " + ex.Message);
            }
        }


        // Xóa hồ sơ tour koitype theo ID
        public bool DeleteTourKoitype(int tourId, int koiTypeId)
        {
            bool isSuccess = false;
            try
            {
                TourKoitype tourKoitype = this.GetTourKoitypeById(tourId, koiTypeId);
                if (tourKoitype != null)
                {
                    dbContext.TourKoitypes.Remove(tourKoitype); // Remove the existing TourKoitype
                    dbContext.SaveChanges(); // Save changes to the database
                    isSuccess = true; // Set success flag to true
                }
                else
                {
                    throw new Exception("Tour Koitype not found."); // Error if not found
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while deleting the tour koitype: " + ex.Message);
            }
            return isSuccess; // Return the success status
        }

        // Cập nhật hồ sơ tour koitype
        public bool UpdateTourKoitype(TourKoitype tourKoitype)
        {
            bool isSuccess = false;
            try
            {
                // Ensure the existing TourKoitype is found
                TourKoitype existingTourKoitype = this.GetTourKoitypeById(tourKoitype.TourId, tourKoitype.KoiTypeId);
                if (existingTourKoitype != null)
                {
                    dbContext.Entry(existingTourKoitype).CurrentValues.SetValues(tourKoitype); // Update existing values
                    dbContext.SaveChanges(); // Save changes to the database
                    isSuccess = true; // Set success flag to true
                }
                else
                {
                    throw new Exception("Tour Koitype not found."); // Error if not found
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating the tour koitype: " + ex.Message);
            }
            return isSuccess; // Return the success status
        }

        // Lấy danh sách tất cả tour koitypes
        public List<TourKoitype> GetTourKoitypes()
        {
            return dbContext.TourKoitypes
                .Include(tk => tk.Tour) // Include related Tour data
                .Include(tk => tk.KoiType) // Include related KoiType data
                .ToList(); // Return the list
        }
    }
}
