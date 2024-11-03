using KoiKingdom_BusinessObject;
using KoiKingdom_Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiKingdom_Repository
{
    public class KoiOrderService : IKoiOrderService
    {
        private IKoiOrderRepo iKoiOrderRepo;

        // Sửa tên constructor thành KoiService
        public KoiOrderService()
        {
            iKoiOrderRepo = new KoiOrderRepo();
        }


        public bool AddKoi(int CustomerId, DateTime DeliveryDate, bool Status, DateTime? EstimatedDelivery)
        {
            return iKoiOrderRepo.AddKoi(CustomerId, DeliveryDate, Status, EstimatedDelivery);
        }

        public bool DeleteKoi(int koiOrderId)
        {
           return iKoiOrderRepo.DeleteKoi(koiOrderId);
        }

        public Koiorder GetKoiOrderById(int id)
        {
            return iKoiOrderRepo.GetKoiOrderById(id);
        }

        public List<Koiorder> GetKoiOrder()
        {
            return iKoiOrderRepo.GetKoiOrder();
        }

        public bool UpdateKoi(Koiorder koiOrder)
        {
            return iKoiOrderRepo.UpdateKoi(koiOrder);
        }
    }
}
