using KoiKingdom_BusinessObject;
using KoiKingdom_DAOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiKingdom_Repository
{
    public interface IKoiorderdetailRepo
    {
        // Get KoiOrderDetail by ID
        public Koiorderdetail GetKoiOrderDetailById(int id);

        // Get all KoiOrderDetails
        public List<Koiorderdetail> GetKoiOrderDetails();

        // Add a KoiOrderDetail record
        public bool AddKoiOrderDetail(int KoiOrderId, int KoiId, int FarmId, int Quantity, decimal UnitPrice, decimal? TotalPrice);
    }
}
