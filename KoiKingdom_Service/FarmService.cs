using KoiKingdom_BusinessObject;
using KoiKingdom_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiKingdom_Service
{
    public class FarmService : IFarmService
    {
        private IFarmRepo iFarmRepo;

        public FarmService()
        {
            iFarmRepo = new FarmRepo(); // Ensure you have a FarmRepo class
        }

        public Farm GetFarmById(int id)
        {
            return iFarmRepo.GetFarmById(id);
        }

        public List<Farm> GetFarms()
        {
            return iFarmRepo.GetFarms();
        }

        public bool AddFarmProfile(Farm farm)
        {
            return iFarmRepo.AddFarmProfile(farm);
        }

        public bool UpdateFarmProfile(Farm farm)
        {
            return iFarmRepo.UpdateFarmProfile(farm);
        }

        public bool DeleteFarmProfile(int farmId)
        {
            return iFarmRepo.DeleteFarmProfile(farmId);
        }

        public List<string> GetFarmsName()
        {
            return iFarmRepo.GetFarmsName();
        }
    }
}
