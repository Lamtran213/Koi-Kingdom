using KoiKingdom_BusinessObject;
using KoiKingdom_DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace KoiKingdom_Service
{
    public interface IFarmService
    {
        public Farm GetFarmById(int id) => FarmDAO.Instance.GetFarmById(id);

        public Farm GetFarmByName(string name) => FarmDAO.Instance.GetFarmByName(name);

        public List<Farm> GetFarms() => FarmDAO.Instance.GetFarms();

        public bool AddFarmProfile(Farm customerProfile) => FarmDAO.Instance.AddFarmProfile(customerProfile);

        public bool DeleteFarmProfile(int customerID) => FarmDAO.Instance.DeleteFarmProfile(customerID);

        public bool UpdateFarmProfile(Farm customerProfile) => FarmDAO.Instance.UpdateFarmProfile(customerProfile);
    }
}
