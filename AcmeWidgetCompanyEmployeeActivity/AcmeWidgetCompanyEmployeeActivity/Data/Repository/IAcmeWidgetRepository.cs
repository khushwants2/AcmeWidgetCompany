using System.Collections.Generic;
using AcmeWidgetBusinessModels.Data.Entities;
using AcmeWidgetBusinessModels.Data.Model;

namespace AcmeWidgetCompanyEmployeeActivity.Data
{
    public interface IAcmeWidgetRepository
    {
        IEnumerable<Activity> GetAllActivities();
        List<RegisteredUserInfo> ShowRegistrationDetailbyCategory(int activityId);

        bool CheckUserisAlreadyRegisteredforActivity(Registration registration);
        bool SaveUserRegistration(Registration registration);
    }
}