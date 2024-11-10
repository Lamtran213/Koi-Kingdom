using KoiKingdom_BusinessObject;
using KoiKingdom_DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiKingdom_Repository
{
    public class TourFarmRepo : ITourFarmRepo
    {
        public TourFarm AddTourFarm(int tourId, int farmId) => TourFarmDAO.Instance.AddTourFarm(tourId, farmId);
  

        public bool DeleteTourFarm(int tourId, int farmId) => TourFarmDAO.Instance.DeleteTourFarm(tourId, farmId);

        public TourFarm GetTourFarmById(int tourId, int farmId) => TourFarmDAO.Instance.GetTourFarmById(tourId, farmId);

        public List<TourFarm> GetTourFarms() => TourFarmDAO.Instance.GetTourFarms();

        public bool UpdateTourFarm(TourFarm tourFarm) => TourFarmDAO.Instance.UpdateTourFarm(tourFarm);

        public List<string> GetFarmNamesByTourId(Tour tour) => TourFarmDAO.Instance.GetFarmNamesByTourId(tour);
    }
}
