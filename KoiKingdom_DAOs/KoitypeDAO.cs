using KoiKingdom_BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiKingdom_DAOs
{
    public class KoitypeDAO // Changed class name from KoiTypeDAO to KoitypeDAO
    {
        private KOI_PRNContext dbContext;
        private static KoitypeDAO instance; // Changed from KoiTypeDAO to KoitypeDAO

        public KoitypeDAO() // Updated constructor name
        {
            dbContext = new KOI_PRNContext();
        }

        // Singleton Pattern
        public static KoitypeDAO Instance // Changed from KoiTypeDAO to KoitypeDAO
        {
            get
            {
                if (instance == null)
                {
                    instance = new KoitypeDAO(); // Changed from KoiTypeDAO to KoitypeDAO
                }
                return instance;
            }
        }

        // Lấy koitype theo ID
        public Koitype GetKoitypeById(int id) // Changed method name and return type
        {
            return dbContext.Koitypes.SingleOrDefault(e => e.KoiTypeId == id); // Updated to use Koitypes
        }

        public Koitype GetKoitypeByName(string name)
        {
            return dbContext.Koitypes.SingleOrDefault(e => e.TypeName.Equals(name));
        }

        // Lấy danh sách tất cả koitype
        public List<Koitype> GetKoitypes() // Changed method name and return type
        {
            return dbContext.Koitypes.ToList(); // Updated to use Koitypes
        }

        // Thêm hồ sơ koitype
        public bool AddKoitype(Koitype koitype) // Changed method name and parameter type
        {
            bool isSuccess = false;
            try
            {
                if (koitype != null)
                {
                    Koitype existingKoitype = this.GetKoitypeById(koitype.KoiTypeId); // Updated to use Koitype
                    if (existingKoitype == null) // Chỉ thêm nếu chưa tồn tại
                    {
                        dbContext.Koitypes.Add(koitype); // Updated to use Koitypes
                        dbContext.SaveChanges();
                        isSuccess = true;
                    }
                    else
                    {
                        throw new Exception("Koitype already exists."); // Updated exception message
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while adding the koitype: " + ex.Message); // Updated exception message
            }
            return isSuccess;
        }

        // Xóa hồ sơ koitype theo ID
        public bool DeleteKoitype(int koitypeId) // Changed method name and parameter type
        {
            bool isSuccess = false;
            try
            {
                Koitype koitype = this.GetKoitypeById(koitypeId); // Updated to use Koitype
                if (koitype != null)
                {
                    dbContext.Koitypes.Remove(koitype); // Updated to use Koitypes
                    dbContext.SaveChanges();
                    isSuccess = true;
                }
                else
                {
                    throw new Exception("Koitype not found."); // Updated exception message
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while deleting the koitype: " + ex.Message); // Updated exception message
            }
            return isSuccess;
        }

        // Cập nhật hồ sơ koitype
        public bool UpdateKoitype(Koitype koitype) // Changed method name and parameter type
        {
            bool isSuccess = false;
            try
            {
                Koitype existingKoitype = this.GetKoitypeById(koitype.KoiTypeId); // Updated to use Koitype
                if (existingKoitype != null)
                {
                    dbContext.Entry(existingKoitype).CurrentValues.SetValues(koitype); // Updated to use Koitype
                    dbContext.SaveChanges();
                    isSuccess = true;
                }
                else
                {
                    throw new Exception("Koitype not found."); // Updated exception message
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating the koitype: " + ex.Message); // Updated exception message
            }
            return isSuccess;
        }
    }
}
