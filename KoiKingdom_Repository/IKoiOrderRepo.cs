using KoiKingdom_BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiKingdom_Repository
{
    public interface IKoiOrderRepo
    {
        public Koiorder GetKoiOrderById(int id);

        public List<Koiorder> GetKoiOrder();

        public bool AddKoi(int CustomerId, DateTime DeliveryDate, bool Status, DateTime? EstimatedDelivery);

        public int AddKoiReturnId(int CustomerId, DateTime deliveryDate, bool status, DateTime? EstimatedDelivery);

        public bool DeleteKoi(int koiOrderId);

        public bool UpdateKoi(Koiorder koiOrder);


    }
}
