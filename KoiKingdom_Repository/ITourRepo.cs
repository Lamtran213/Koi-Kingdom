using KoiKingdom_BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiKingdom_Repository
{
    public interface ITourRepo
    {
        public Tour GetTourById(int id);

        public List<Tour> GetTours();

        public Tour AddTour(string tourName, string duration, DateTime startDate, DateTime endDate, string image, decimal? tourPrice = null, string? description = null, bool status = true, string? departureLocation = null);

        public bool DeleteTour(int tourId);

        public bool UpdateTour(Tour tour);
    }
}
