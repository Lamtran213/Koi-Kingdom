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

        public bool AddTour(Tour tour);

        public bool DeleteTour(int tourId);

        public bool UpdateTour(Tour tour);
    }
}
