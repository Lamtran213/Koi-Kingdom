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

        public TourFarm GetTourFarmById(int tourId, int farmid)
        {
            return iTourFarmRepo.GetTourFarmById(tourId, farmid);
        }

        public List<TourFarm> GetTourFarms()
        {
            return iTourFarmRepo.GetTourFarms();
        }

        public TourFarm AddTourFarm(int tourId, int farmId)
        {
            return iTourFarmRepo.AddTourFarm(tourId, farmId);
        }

        public bool UpdateTourFarm(TourFarm tour)
        {
            return iTourFarmRepo.UpdateTourFarm(tour);
        }

        public bool DeleteTourFarm(int tourId, int  farmid)
        {
            return iTourFarmRepo.DeleteTourFarm(tourId, farmid);
        }
    }
}
