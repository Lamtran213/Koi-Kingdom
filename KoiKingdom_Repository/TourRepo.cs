using KoiKingdom_BusinessObject;
using KoiKingdom_DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiKingdom_Repository
{
    public class TourRepo : ITourRepo
    {

        public Tour AddTour(string tourName, string duration, DateTime startDate, DateTime endDate, string image, decimal? tourPrice = null, string? description = null, bool status = true, string? departureLocation = null)=> TourDAO.Instance.AddTour(tourName, duration, startDate, endDate, image, tourPrice, description, status, departureLocation);
        public bool DeleteTour(int tourId) => TourDAO.Instance.DeleteTour(tourId);

        public Tour GetTourById(int id) => TourDAO.Instance.GetTourById(id);

        public List<Tour> GetTours() => TourDAO.Instance.GetTours();

        public bool UpdateTour(Tour tour) => TourDAO.Instance.UpdateTour(tour);

    }
}
