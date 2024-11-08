using KoiKingdom_BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiKingdom_DAOs
{
    public class CustomTourDAO
    {
        private KOI_PRNContext dbContext;
        private static CustomTourDAO instance;
        public CustomTourDAO()
        {
            dbContext = new KOI_PRNContext();
        }
        public static CustomTourDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CustomTourDAO();
                }
                return instance;
            }
        }
        public bool CreateCustomTour(Customtourrequest customtourrequest)
        {
            bool isCreate = false;
            try
            {
                if (customtourrequest != null)
                {
                    dbContext.Customtourrequests.Add(customtourrequest);
                    isCreate = true;
                    dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return isCreate;
        }

        public List<Customtourrequest> GetCustomtourrequests()
        {
            return dbContext.Customtourrequests.ToList();
        }
        public Customtourrequest GetCustomtourrequestbByID(int id)
        {
            return dbContext.Customtourrequests.SingleOrDefault(m => m.RequestId == id);
        }
        public bool DeleteCustomTour(int id)
        {
            bool isDeleted = false;
            try
            {
                Customtourrequest customtourrequest = GetCustomtourrequestbByID(id);
                if (customtourrequest != null)
                {
                    dbContext.Customtourrequests.Remove(customtourrequest);
                    isDeleted = true;
                    dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
            }
            return isDeleted;
        }
        public bool UpdateCustomTour(Customtourrequest customtourrequest)
        {
            bool isUpdate = false;
            try
            {
                Customtourrequest updateCustomTour = this.GetCustomtourrequestbByID(customtourrequest.RequestId);
                if (updateCustomTour != null)
                {
                    dbContext.Entry(updateCustomTour).CurrentValues.SetValues(customtourrequest);
                    dbContext.SaveChanges();
                    isUpdate = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return isUpdate;
        }
    }
}
