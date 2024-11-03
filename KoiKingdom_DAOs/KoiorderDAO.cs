using KoiKingdom_BusinessObject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace KoiKingdom_DAOs
{
    public class KoiorderDAO
    {
        private KOI_PRNContext dbContext;
        private static KoiorderDAO instance;

        public KoiorderDAO()
        {
            dbContext = new KOI_PRNContext();
        }

        public static KoiorderDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new KoiorderDAO();
                }
                return instance;
            }
        }

        public Koiorder GetKoiOrderById(int id)
        {
            return dbContext.Koiorders.SingleOrDefault(e => e.KoiOrderId == id);
        }

        // Lấy danh sách tất cả koi
        public List<Koiorder> GetKoiOrder()
        {
            return dbContext.Koiorders.ToList();
        }

        public bool AddKoi(int CustomerId, DateTime DeliveryDate, bool Status, DateTime? EstimatedDelivery)
        {
            bool isSuccess = false;
            try
            {
                // Create a new employee object
                Koiorder newkoiOrder = new Koiorder
                {
                    CustomerId = CustomerId,
                    DeliveryDate = DeliveryDate,
                    Status = Status,
                    EstimatedDelivery = EstimatedDelivery,
                };
                dbContext.Koiorders.Add(newkoiOrder);
                dbContext.SaveChanges();
                isSuccess = true;

            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while adding the koi: " + ex.Message);
            }
            return isSuccess;
        }
        public bool DeleteKoi(int koiOrderId)
        {
            bool isSuccess = false;
            try
            {
                Koiorder koiOrder = this.GetKoiOrderById(koiOrderId);
                if (koiOrder != null)
                {
                    dbContext.Koiorders.Remove(koiOrder);
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
        public bool UpdateKoi(Koiorder koiOrder)
        {
            bool isSuccess = false;
            try
            {
                Koiorder existingKoiOrder = this.GetKoiOrderById(koiOrder.KoiOrderId);
                if (existingKoiOrder != null)
                {
                    dbContext.Entry(existingKoiOrder).CurrentValues.SetValues(koiOrder);
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
