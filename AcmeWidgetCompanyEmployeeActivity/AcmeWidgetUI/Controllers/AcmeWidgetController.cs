using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AcmeWidgetBusinessModels.Data.Entities;
using AcmeWidgetBusinessModels.Data.Model;
using System.Net.Http;
using System.Text.Json;
using System.Net;
using System.IO;
using AcmeWidgetUI.Services;

namespace AcmeWidgetUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcmeWidgetController : ControllerBase
    {        
        private IAcmeWidgetUIService _acmeWidgetUIService;      

        public AcmeWidgetController( IAcmeWidgetUIService acmeWidgeUIService)
        {          
            _acmeWidgetUIService = acmeWidgeUIService;          

        }
        [Route("getactivities")]
        [HttpGet]
        public async Task<IEnumerable<Activity>> GetActivities()
        {
            return await _acmeWidgetUIService.GetallActivitiesfromDB();
        }

        [Route("saveuserregistration")]
        [HttpPost]
        public async Task<IEnumerable<RegisteredUserInfo>> SaveUserRegistration([FromBody] Registration data)
        {
            
            var result =await _acmeWidgetUIService.SaveUserRegistration(data);
            if (result.Contains("User Registration is Successfull."))
                return await _acmeWidgetUIService.ShowRegistrationDetailbyCategory(data.ActivityId);
            else
            return null;
            
        }


    }
}