using KoiKingdom_BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiKingdom_Service
{
    public interface IKoiorderdetailService
    {
        // Get KoiOrderDetail by ID
        public Koiorderdetail GetKoiOrderDetailById(int id);

        // Get all KoiOrderDetails
        public List<Koiorderdetail> GetKoiOrderDetails();

        // Add a KoiOrderDetail record
        public bool AddKoiOrderDetail(int KoiOrderId, int KoiId, int FarmId, int Quantity, decimal UnitPrice, decimal? TotalPrice);
    }
}
