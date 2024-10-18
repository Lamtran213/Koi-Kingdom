using KoiKingdom_BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KoiKingdom_DAOs
{
    public class FarmDAO
    {
        private KOI_PRNContext dbContext;
        private static FarmDAO instance;

        // Constructor
        public FarmDAO()
        {
            dbContext = new KOI_PRNContext();
        }

        // Singleton Pattern
        public static FarmDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FarmDAO();
                }
                return instance;
            }
        }

        // Get farm by ID
        public Farm GetFarmById(int id)
        {
            return dbContext.Farms.SingleOrDefault(e => e.FarmId == id);
        }

        // Get farm by Name
        public Farm GetFarmByName(string name)
        {
            return dbContext.Farms.SingleOrDefault(e => e.FarmName.Equals(name));
        }

        // Get list of all farms
        public List<Farm> GetFarms()
        {
            return dbContext.Farms.ToList();
        }

        // Add farm profile
        public bool AddFarmProfile(Farm farmProfile)
        {
            bool isSuccess = false;
            try
            {
                if (farmProfile != null)
                {
                    Farm existingFarm = this.GetFarmById(farmProfile.FarmId);
                    if (existingFarm == null) // Only add if it doesn't already exist
                    {
                        dbContext.Farms.Add(farmProfile);
                        dbContext.SaveChanges();
                        isSuccess = true;
                    }
                    else
                    {
                        throw new Exception("Farm already exists.");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while adding the farm: " + ex.Message);
            }
            return isSuccess;
        }

        // Delete farm profile by ID
        public bool DeleteFarmProfile(int farmID)
        {
            bool isSuccess = false;
            try
            {
                Farm farmProfile = this.GetFarmById(farmID);
                if (farmProfile != null)
                {
                    dbContext.Farms.Remove(farmProfile);
                    dbContext.SaveChanges();
                    isSuccess = true;
                }
                else
                {
                    throw new Exception("Farm not found.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while deleting the farm: " + ex.Message);
            }
            return isSuccess;
        }

        // Update farm profile
        public bool UpdateFarmProfile(Farm farmProfile)
        {
            bool isSuccess = false;
            try
            {
                Farm existingFarm = this.GetFarmById(farmProfile.FarmId);
                if (existingFarm != null)
                {
                    dbContext.Entry(existingFarm).CurrentValues.SetValues(farmProfile);
                    dbContext.SaveChanges();
                    isSuccess = true;
                }
                else
                {
                    throw new Exception("Farm not found.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating the farm: " + ex.Message);
            }
            return isSuccess;
        }
    }
}
