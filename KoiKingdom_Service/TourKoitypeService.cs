using KoiKingdom_BusinessObject;
using KoiKingdom_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiKingdom_Service
{
    public class TourKoitypeService : ITourKoitypeService
    {
        private ITourKoitypeRepo iTourKoitypeRepo; // Changed to IKoitypeRepo

        // Constructor
        public TourKoitypeService() // Changed to KoitypeService
        {
            iTourKoitypeRepo = new TourKoitypeRepo(); // Changed to KoitypeRepo
        }

        public TourKoitype AddTourKoitype(int tourId, int koiTypeId)
        {
            return iTourKoitypeRepo.AddTourKoitype(tourId, koiTypeId);
        }

        public bool DeleteTourKoitype(int tourId, int tourKoiTypeId)
        {
            return iTourKoitypeRepo.DeleteTourKoitype(tourId,tourKoiTypeId);
        }

        public TourKoitype GetTourKoitypeById(int tourId, int tourKoiTypeId)
        {
            return iTourKoitypeRepo.GetTourKoitypeById(tourId, tourKoiTypeId);
        }

        public List<TourKoitype> GetTourKoitypes()
        {
            return iTourKoitypeRepo.GetTourKoitypes();
        }

        public bool UpdateTourKoitype(TourKoitype tourKoitype)
        {
            return iTourKoitypeRepo.UpdateTourKoitype(tourKoitype);
        }

    }
}
