using KoiKingdom_BusinessObject;
using KoiKingdom_DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiKingdom_Repository
{
    public class TourKoitypeRepo : ITourKoitypeRepo
    {
        public TourKoitype AddTourKoitype(int tourId, int koiTypeId) => TourKoitypeDAO.Instance.AddTourKoitype(tourId, koiTypeId);


        public bool DeleteTourKoitype(int tourId, int koiTypeId) => TourKoitypeDAO.Instance.DeleteTourKoitype(tourId, koiTypeId);

        public TourKoitype GetTourKoitypeById(int tourId, int koiTypeId) => TourKoitypeDAO.Instance.GetTourKoitypeById(tourId, koiTypeId);

        public List<TourKoitype> GetTourKoitypes() => TourKoitypeDAO.Instance.GetTourKoitypes();

        public bool UpdateTourKoitype(TourKoitype tourKoitype) => TourKoitypeDAO.Instance.UpdateTourKoitype(tourKoitype);

        public List<string> GetKoiTypeNamesByTourId(Tour tour) => TourKoitypeDAO.Instance.GetKoiTypeNamesByTourId(tour);
    }
}
