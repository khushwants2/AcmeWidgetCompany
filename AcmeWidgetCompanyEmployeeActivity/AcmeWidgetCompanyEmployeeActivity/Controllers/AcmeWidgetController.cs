using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Threading.Tasks;
using AcmeWidgetBusinessModels.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AcmeWidgetBusinessModels.Data.Model;

using System.Text.Json;
using System.Text.Json.Serialization;
using AcmeWidgetCompanyEmployeeActivity.Data;

namespace AcmeWidgetCompanyEmployeeActivity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcmeWidgetController : ControllerBase
    {
        private readonly IAcmeWidgetRepository _acmeWidgetRepository;
        public AcmeWidgetController(IAcmeWidgetRepository acmeWidgetRepository)
        {
            _acmeWidgetRepository = acmeWidgetRepository;
        }

        [HttpGet]
        public IEnumerable<Activity> Get()
        {
            var results = _acmeWidgetRepository.GetAllActivities();
            return results;
        }

        [Route("Save")]
        [HttpPost]
        public ActionResult SaveUserRegistration([FromBody] Registration registration)
        {
            
            if (ModelState.IsValid)
            {
                try {
                    if (!_acmeWidgetRepository.CheckUserisAlreadyRegisteredforActivity(registration))
                    {
                        bool usersaved = _acmeWidgetRepository.SaveUserRegistration(registration);
                        if (!usersaved)
                            return StatusCode((int)HttpStatusCode.InternalServerError, "Internal Server Error: User Registration is Unsuccessfull.");
                        else
                            return StatusCode((int)HttpStatusCode.OK, "User Registration is Successfull.");
                    }
                    else { 
                        return StatusCode((int)HttpStatusCode.OK, "User Registration is Unsuccessfull. User is already Registered");
                    }
                }
                catch(Exception ex)
                {
                    return StatusCode((int)HttpStatusCode.InternalServerError, "Internal Server Error: User Registration is Unsuccessfull.");
                }    
            }
            else
            {
                string errorMessages = string.Join("; ", ModelState.Values
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage));
                errorMessages = "User Registration is Unsuccessfull due to the respective Exceptions. " + errorMessages;
                return StatusCode((int)HttpStatusCode.ExpectationFailed, errorMessages);
            }
            
        }
        [Route("GetUserList/{activityId}")]
        [HttpGet]
        public string ShowRegistrationDetailbyCategory(int activityId)
        {
            var results = _acmeWidgetRepository.ShowRegistrationDetailbyCategory(activityId);
            //return results;
            if (results.Count == 0)
                return JsonSerializer.Serialize("No Data Found");
            return JsonSerializer.Serialize(results);
        }
    }
}