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
        public bool AddTourFarm(TourFarm tourFarm) => TourFarmDAO.Instance.AddTourFarm(tourFarm);
  

        public bool DeleteTourFarm(int tourId) => TourFarmDAO.Instance.DeleteTourFarm(tourId);

        public TourFarm GetTourFarmById(int id) => TourFarmDAO.Instance.GetTourFarmById(id);

        public List<TourFarm> GetTourFarms() => TourFarmDAO.Instance.GetTourFarms();

        public bool UpdateTourFarm(TourFarm tourFarm) => TourFarmDAO.Instance.UpdateTourFarm(tourFarm);
    }
}
