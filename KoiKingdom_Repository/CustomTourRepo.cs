using KoiKingdom_BusinessObject;
using KoiKingdom_DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiKingdom_Repository
{
    public class CustomTourRepo : ICustomTourRepo
    {
        public bool CreateCustomTour(Customtourrequest customtourrequest) => CustomTourDAO.Instance.CreateCustomTour(customtourrequest);

        public bool DeleteCustomTour(int id) => CustomTourDAO.Instance.DeleteCustomTour(id);

        public List<Customtourrequest> GetCustomtourrequests() => CustomTourDAO.Instance.GetCustomtourrequests();

        public bool UpdateCustomTour(Customtourrequest customtourrequest) => CustomTourDAO.Instance.UpdateCustomTour(customtourrequest);
    }
}
