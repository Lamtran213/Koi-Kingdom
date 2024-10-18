using KoiKingdom_BusinessObject;
using KoiKingdom_DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiKingdom_Repository
{
    public class FarmRepo : IFarmRepo
    {
        public bool AddFarmProfile(Farm farmProfile) => FarmDAO.Instance.AddFarmProfile(farmProfile);

        public bool DeleteFarmProfile(int farmID) => FarmDAO.Instance.DeleteFarmProfile(farmID);

        public Farm GetFarmById(int id) => FarmDAO.Instance.GetFarmById(id);

        public Farm GetFarmByName(string name) => FarmDAO.Instance.GetFarmByName(name);

        public List<Farm> GetFarms() => FarmDAO.Instance.GetFarms();

        public bool UpdateFarmProfile(Farm farmProfile) => FarmDAO.Instance.UpdateFarmProfile(farmProfile);
    }
}
    