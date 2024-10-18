using KoiKingdom_BusinessObject;
using KoiKingdom_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiKingdom_Service
{
    public class TourFarmService : ITourFarmService
    {
        private ITourFarmRepo iTourFarmRepo;

        public TourFarmService()
        {
            iTourFarmRepo = new TourFarmRepo();
        }

        public TourFarm GetTourById(int id)
        {
            return iTourFarmRepo.GetTourFarmById(id);
        }

        public List<TourFarm> GetTours()
        {
            return iTourFarmRepo.GetTourFarms();
        }

        public bool AddTour(TourFarm tour)
        {
            return iTourFarmRepo.AddTourFarm(tour);
        }

        public bool UpdateTour(TourFarm tour)
        {
            return iTourFarmRepo.UpdateTourFarm(tour);
        }

        public bool DeleteTour(int tourId)
        {
            return iTourFarmRepo.DeleteTourFarm(tourId);
        }
    }
}
