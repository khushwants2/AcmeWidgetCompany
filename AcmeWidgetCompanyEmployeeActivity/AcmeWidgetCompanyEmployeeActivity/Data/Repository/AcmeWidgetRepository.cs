using AcmeWidgetBusinessModels.Data.Entities;
using AcmeWidgetBusinessModels.Data.Model;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcmeWidgetCompanyEmployeeActivity.Data
{
    public class AcmeWidgetRepository : IAcmeWidgetRepository
    {
        private readonly AcmeDBContext _ctx;
        private readonly ILogger<AcmeWidgetRepository> _logger;
        public AcmeWidgetRepository(AcmeDBContext ctx, ILogger<AcmeWidgetRepository> logger)
        {
            _ctx = ctx;
            _logger = logger;
        }

        public bool CheckUserisAlreadyRegisteredforActivity(Registration registration)
        {
            
            try
            {
                var results = _ctx.RegistrationTable
                    .Where(p => p.EmailAddress == registration.EmailAddress && p.ActivityId == registration.ActivityId)
                    .ToList();
                if (results.Count > 0)
                    return true;               
            }
            catch (Exception ex)
            {
                _logger.LogError($"CheckUserisAlreadyRegisteredforActivity: Failed to check user is registerd. Exception {ex}");
                throw ex;
            }
            return false;
        }

        public IEnumerable<Activity> GetAllActivities()
        {
            try
            {
                var results = _ctx.ActivityTable
                    .OrderBy(p => p.ActivityName)
                    .ToList();
                return results;
            }
            catch (Exception ex)
            {
                _logger.LogError($"GetAllActivities: Failed to Get All Activities. Exception {ex}");
                return null;
            }
        }

        public bool SaveUserRegistration(Registration registration)
        {
            try
            {
                _ctx.RegistrationTable.Add(registration);
                return _ctx.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError($"SaveUserRegistration: Unable to Save user data. Exception {ex}");
                return false;
            }
        }

        public List<RegisteredUserInfo> ShowRegistrationDetailbyCategory(int activityId)
        {
            try
            {
                var results = _ctx.RegistrationTable
                    .Join(
                    _ctx.ActivityTable,
                    reg => reg.ActivityId,
                    act => act.ActivityId,
                    (reg, act) => new RegisteredUserInfo
                    {
                        Id = reg.Id,
                        FirstName = reg.FirstName,
                        LastName = reg.LastName,
                        EmailAddress = reg.EmailAddress,
                        Comments = reg.Comments,
                        ActivityName = act.ActivityName,
                        ActivityId = act.ActivityId
                    }
                    )
                    .Where(r => r.ActivityId == activityId)
                    .OrderByDescending(r => r.Id)
                    .ToList();

                return results;
            }
            catch (Exception ex)
            {
                _logger.LogError($"ShowRegistrationDetailbyCategory: Failed to get user data. Exception {ex}");
                return null;
            }
        }

    }
}
