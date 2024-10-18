using KoiKingdom_BusinessObject;
using KoiKingdom_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiKingdom_Service
{
    public class TourService : ITourService
    {
        private ITourRepo iTourRepo;

        public TourService()
        {
            iTourRepo = new TourRepo();
        }

        public Tour GetTourById(int id)
        {
            return iTourRepo.GetTourById(id);
        }

        public List<Tour> GetTours()
        {
            return iTourRepo.GetTours();
        }

        public bool AddTour(Tour tour)
        {
            return iTourRepo.AddTour(tour);
        }

        public bool UpdateTour(Tour tour)
        {
            return iTourRepo.UpdateTour(tour);
        }

        public bool DeleteTour(int tourId)
        {
            return iTourRepo.DeleteTour(tourId);
        }
    }

}
