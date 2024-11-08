using KoiKingdom_BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiKingdom_Repository
{
    public interface ICustomTourRepo
    {
        public bool CreateCustomTour(Customtourrequest customtourrequest);
        public List<Customtourrequest> GetCustomtourrequests();
        public bool DeleteCustomTour(int id);
        public bool UpdateCustomTour(Customtourrequest customtourrequest);
    }
}
