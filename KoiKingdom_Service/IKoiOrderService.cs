using KoiKingdom_BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiKingdom_Service
{
    public interface IKoiOrderService
    {
        public Koiorder GetKoiOrderById(int id);

        public List<Koiorder> GetKoiOrder();

        public bool AddKoi(int CustomerId, DateTime DeliveryDate, bool Status, DateTime? EstimatedDelivery);

        public bool DeleteKoi(int koiOrderId);

        public bool UpdateKoi(Koiorder koiOrder);

    }
}
