using KoiKingdom_BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiKingdom_DAOs
{
    public class KoiDAO
    {
        private KOI_PRNContext dbContext;
        private static KoiDAO instance;

        public KoiDAO()
        {
            dbContext = new KOI_PRNContext();
        }

        // Singleton Pattern
        public static KoiDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new KoiDAO();
                }
                return instance;
            }
        }

        // Lấy koi theo ID
        public Koi GetKoiById(int id)
        {
            return dbContext.Kois.SingleOrDefault(e => e.KoiId == id);
        }

        // Lấy danh sách tất cả koi
        public List<Koi> GetKois()
        {
            return dbContext.Kois.ToList();
        }

        // Thêm hồ sơ koi
        public bool AddKoi(Koi koi)
        {
            bool isSuccess = false;
            try
            {
                if (koi != null)
                {
                    Koi existingKoi = this.GetKoiById(koi.KoiId);
                    if (existingKoi == null) // Chỉ thêm nếu chưa tồn tại
                    {
                        dbContext.Kois.Add(koi);
                        dbContext.SaveChanges();
                        isSuccess = true;
                    }
                    else
                    {
                        throw new Exception("Koi already exists.");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while adding the koi: " + ex.Message);
            }
            return isSuccess;
        }

        // Xóa hồ sơ koi theo ID
        public bool DeleteKoi(int koiId)
        {
            bool isSuccess = false;
            try
            {
                Koi koi = this.GetKoiById(koiId);
                if (koi != null)
                {
                    dbContext.Kois.Remove(koi);
                    dbContext.SaveChanges();
                    isSuccess = true;
                }
                else
                {
                    throw new Exception("Koi not found.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while deleting the koi: " + ex.Message);
            }
            return isSuccess;
        }

        // Cập nhật hồ sơ koi
        public bool UpdateKoi(Koi koi)
        {
            bool isSuccess = false;
            try
            {
                Koi existingKoi = this.GetKoiById(koi.KoiId);
                if (existingKoi != null)
                {
                    dbContext.Entry(existingKoi).CurrentValues.SetValues(koi);
                    dbContext.SaveChanges();
                    isSuccess = true;
                }
                else
                {
                    throw new Exception("Koi not found.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating the koi: " + ex.Message);
            }
            return isSuccess;
        }
    }
}
