using KoiKingdom_BusinessObject;
using KoiKingdom_DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiKingdom_Repository
{
    public class KoiOrderRepo : IKoiOrderRepo
    {
        public bool AddKoi(int CustomerId, DateTime DeliveryDate, bool Status, DateTime? EstimatedDelivery) => KoiorderDAO.Instance.AddKoi(CustomerId, DeliveryDate, Status, EstimatedDelivery);
        public bool DeleteKoi(int koiOrderId) => KoiorderDAO.Instance.DeleteKoi(koiOrderId);

        public Koiorder GetKoiOrderById(int id) => KoiorderDAO.Instance.GetKoiOrderById(id);

        public List<Koiorder> GetKoiOrder() => KoiorderDAO.Instance.GetKoiOrder();
        public bool UpdateKoi(Koiorder koiOrder) => KoiorderDAO.Instance.UpdateKoi(koiOrder);
    }
}
