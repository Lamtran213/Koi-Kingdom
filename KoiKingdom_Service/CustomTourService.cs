using KoiKingdom_BusinessObject;
using KoiKingdom_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiKingdom_Service
{
    public class CustomTourService : ICustomTourService
    {
        private readonly CustomTourRepo customTourRepo;
        public bool CreateCustomTour(Customtourrequest customtourrequest)
        {
            return customTourRepo.CreateCustomTour(customtourrequest);
        }

        public bool DeleteCustomTour(int id)
        {
            return customTourRepo.DeleteCustomTour(id);
        }

        public List<Customtourrequest> GetCustomtourrequests()
        {
            return customTourRepo.GetCustomtourrequests();
        }

        public bool UpdateCustomTour(Customtourrequest customtourrequest)
        {
            return customTourRepo.UpdateCustomTour(customtourrequest);
        }
    }
}
