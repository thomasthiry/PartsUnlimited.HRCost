using System;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;

namespace PartsUnlimited.HRCost.Application.Services
{
    public class OnlineApiService
    {
        public int GetBaseHolidays(int employeeId)
        {
            var httpClient = new HttpClient {BaseAddress = new Uri("https://partsunlimitedHRCost.azurewebsites.net")};

            var response = httpClient.GetAsync($"/externalsystem/baseholidays?employeeId={employeeId}").Result;
                
            var responseText = response.Content.ReadAsStringAsync().Result;

            var responseObject = JsonConvert.DeserializeObject<ResponseObject>(responseText);

            return Convert.ToInt32(responseObject.BaseHolidays);
        }

        internal class ResponseObject
        {
            public int BaseHolidays { get; set; }
        }
    }
}