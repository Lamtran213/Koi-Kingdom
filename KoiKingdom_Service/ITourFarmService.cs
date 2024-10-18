using KoiKingdom_BusinessObject;
using KoiKingdom_DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiKingdom_Service
{
    public interface ITourFarmService
    {
        public bool AddTour(TourFarm tourFarm) => TourFarmDAO.Instance.AddTourFarm(tourFarm);

        public bool DeleteTour(int tourFarmId) => TourFarmDAO.Instance.DeleteTourFarm(tourFarmId);

        public TourFarm GetTourById(int tourFarmId) => TourFarmDAO.Instance.GetTourFarmById(tourFarmId);

        public List<TourFarm> GetTours() => TourFarmDAO.Instance.GetTourFarms();

        public bool UpdateTour(TourFarm tourFarmId) => TourFarmDAO.Instance.UpdateTourFarm(tourFarmId);

    }
}
