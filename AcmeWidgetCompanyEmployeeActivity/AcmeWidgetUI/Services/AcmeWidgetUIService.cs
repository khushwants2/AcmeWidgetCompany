using AcmeWidgetBusinessModels.Data.Entities;
using AcmeWidgetBusinessModels.Data.Model;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AcmeWidgetUI.Services
{
    public class AcmeWidgetUIService: IAcmeWidgetUIService
    {
        private readonly ILogger<AcmeWidgetUIService> _logger;
        private static string baseAddress;
        private static readonly HttpClient _httpclient = new HttpClient {
            BaseAddress = new Uri("https://localhost:44320"),
            Timeout = new TimeSpan(0, 1, 0)
        };

        public AcmeWidgetUIService(ILogger<AcmeWidgetUIService> logger)
        {

            baseAddress = "https://localhost:44320/";
            _logger = logger;
        }
        public async Task<IEnumerable<Activity>> GetallActivitiesfromDB()
        {
            try
            {
                var response = await _httpclient.GetAsync("api/AcmeWidget");
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
                JsonSerializerOptions options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                // Display the content.
                IEnumerable<Activity> activities = JsonSerializer.Deserialize<IEnumerable<Activity>>(content, options);
                return activities;
            }
            catch (Exception ex)
            {
                _logger.LogError($"GetallActivitiesfromDB: Failed to get activities. Exception {ex}");
                return null;
            }

        }

        public async Task<string> SaveUserRegistration(Registration datafromUI) {
            try
            {

                var serializeData = JsonSerializer.Serialize(datafromUI);
                var request = new HttpRequestMessage(HttpMethod.Post, "api/AcmeWidget/save");
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                request.Content = new StringContent(serializeData);
                request.Content.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");

                var response = await _httpclient.SendAsync(request);
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                return content;
            }
            catch (Exception ex)
            {
                _logger.LogError($"SaveUserRegistration: Failed to save user. Exception {ex}");
                return "";
            }
        }

        public async Task<IEnumerable<RegisteredUserInfo>> ShowRegistrationDetailbyCategory(int activityid)
        { 
            try
            {
                var response = await _httpclient.GetAsync($"api/AcmeWidget/GetUserList/{activityid}");
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
                JsonSerializerOptions options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                // Display the content.
                IEnumerable<RegisteredUserInfo> registeredUserInfo = JsonSerializer.Deserialize<IEnumerable<RegisteredUserInfo>>(content, options);
                return registeredUserInfo;
                }
                catch (Exception ex)
                {
                    _logger.LogError($"ShowRegistrationDetailbyCategory: Failed to get activities. Exception {ex}");
                    return null;
                }
        }

        
    }
}
