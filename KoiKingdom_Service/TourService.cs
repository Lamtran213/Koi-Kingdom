using KoiKingdom_BusinessObject;
using KoiKingdom_Repository;
using System;
using System.Collections.Generic;

namespace KoiKingdom_Service
{
    public class TourService : ITourService
    {
        private readonly ITourRepo _iTourRepo;

        public TourService()
        {
            _iTourRepo = new TourRepo();
        }

        public Tour GetTourById(int id)
        {
            return _iTourRepo.GetTourById(id);
        }

        public List<Tour> GetTours()
        {
            return _iTourRepo.GetTours();
        }

        public bool UpdateTour(Tour tour)
        {
            return _iTourRepo.UpdateTour(tour);
        }

        public bool DeleteTour(int tourId)
        {
            return _iTourRepo.DeleteTour(tourId);
        }

        public Tour AddTour(string tourName, string duration, DateTime startDate, DateTime endDate, string image, decimal? tourPrice = null, string? description = null, bool status = true, string? departureLocation = null)
        {
            // Gọi đến phương thức AddTour của iTourRepo
            return _iTourRepo.AddTour(tourName, duration, startDate, endDate, image, tourPrice, description, status, departureLocation);
        }
    }
}
