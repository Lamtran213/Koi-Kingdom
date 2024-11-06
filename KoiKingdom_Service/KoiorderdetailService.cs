using KoiKingdom_BusinessObject;
using KoiKingdom_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiKingdom_Service
{
    public class KoiorderdetailService : IKoiorderdetailService
    {
        private IKoiorderdetailRepo iKoiOrderDetailRepo;

        public KoiorderdetailService()
        {
            iKoiOrderDetailRepo = new KoiorderdetailRepo(); // Ensure you have a FarmRepo class
        }

        public bool AddKoiOrderDetail(int KoiOrderId, int KoiId, int FarmId, int Quantity, decimal UnitPrice, decimal? TotalPrice)
        {
            return iKoiOrderDetailRepo.AddKoiOrderDetail(KoiOrderId, KoiId, FarmId, Quantity, UnitPrice, TotalPrice);
        }

        public Koiorderdetail GetKoiOrderDetailById(int id)
        {
            return iKoiOrderDetailRepo.GetKoiOrderDetailById(id);
        }

        public List<Koiorderdetail> GetKoiOrderDetails()
        {
            return iKoiOrderDetailRepo.GetKoiOrderDetails();
        }
    }
}
