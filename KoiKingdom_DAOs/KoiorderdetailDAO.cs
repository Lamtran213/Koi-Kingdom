using KoiKingdom_BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiKingdom_DAOs
{
    public class KoiorderdetailDAO
    {
        private KOI_PRNContext dbContext;
        private static KoiorderdetailDAO instance;

        public KoiorderdetailDAO()
        {
            dbContext = new KOI_PRNContext();
        }

        // Singleton Pattern
        public static KoiorderdetailDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new KoiorderdetailDAO();
                }
                return instance;
            }
        }

        // Get KoiOrderDetail by ID
        public Koiorderdetail GetKoiOrderDetailById(int id)
        {
            return dbContext.Koiorderdetails.SingleOrDefault(e => e.KoiOrderDetailId == id);
        }

        // Get all KoiOrderDetails
        public List<Koiorderdetail> GetKoiOrderDetails()
        {
            return dbContext.Koiorderdetails.ToList();
        }

        // Add a KoiOrderDetail record
        public bool AddKoiOrderDetail(int KoiOrderId, int KoiId, int FarmId, int Quantity, decimal UnitPrice, decimal? TotalPrice)
        {
            bool isSuccess = false;
            try
            {
                // Create a new KoiOrderDetail instance
                Koiorderdetail koiOrderDetail = new Koiorderdetail
                {
                    KoiOrderId = KoiOrderId,
                    KoiId = KoiId,
                    FarmId = FarmId,
                    Quantity = Quantity,
                    UnitPrice = UnitPrice,
                    TotalPrice = TotalPrice
                };

                // Check if an order detail with the same ID already exists
                Koiorderdetail existingOrderDetail = this.GetKoiOrderDetailById(koiOrderDetail.KoiOrderDetailId);
                if (existingOrderDetail == null) // Only add if it doesn't exist
                {
                    dbContext.Koiorderdetails.Add(koiOrderDetail);
                    dbContext.SaveChanges();
                    isSuccess = true;
                }
                else
                {
                    throw new Exception("Koi Order Detail already exists.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while adding the koi order detail: " + ex.Message);
            }
            return isSuccess;
        }

    }
}
