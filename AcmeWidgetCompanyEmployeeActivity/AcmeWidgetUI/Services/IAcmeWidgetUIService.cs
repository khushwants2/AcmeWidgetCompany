using AcmeWidgetBusinessModels.Data.Entities;
using AcmeWidgetBusinessModels.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcmeWidgetUI.Services
{
   public interface IAcmeWidgetUIService
    {
        //public IEnumerable<Activity> GetallActivitiesfromDB();
        public  Task<IEnumerable<Activity>> GetallActivitiesfromDB();
        public Task<string> SaveUserRegistration(Registration datafromUI);

        public Task<IEnumerable<RegisteredUserInfo>> ShowRegistrationDetailbyCategory(int activityid);
    }
}
