using KoiKingdom_BusinessObject;
using KoiKingdom_DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace KoiKingdom_Repository
{
    public class KoiorderdetailRepo : IKoiorderdetailRepo
    {
        public bool AddKoiOrderDetail(int KoiOrderId, int KoiId, int FarmId, int Quantity, decimal UnitPrice, decimal? TotalPrice) => KoiorderdetailDAO.Instance.AddKoiOrderDetail(KoiOrderId, KoiId, FarmId, Quantity, UnitPrice, TotalPrice);

        public Koiorderdetail GetKoiOrderDetailById(int id) => KoiorderdetailDAO.Instance.GetKoiOrderDetailById(id);

        public List<Koiorderdetail> GetKoiOrderDetails() => KoiorderdetailDAO.Instance.GetKoiOrderDetails();
    }
}
