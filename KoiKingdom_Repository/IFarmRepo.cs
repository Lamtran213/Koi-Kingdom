using KoiKingdom_BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiKingdom_Repository
{
    public interface IFarmRepo
    {
        // Get farm by ID
        public Farm GetFarmById(int id);

        // Get farm by Name
        public Farm GetFarmByName(string name);
        // Get list of all farms
        public List<Farm> GetFarms();
        // Add farm profile
        public bool AddFarmProfile(Farm farmProfile);

        // Delete farm profile by ID
        public bool DeleteFarmProfile(int farmID);
        // Update farm profile
        public bool UpdateFarmProfile(Farm farmProfile);
    }
}
