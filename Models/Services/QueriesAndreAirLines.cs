using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Models.Services
{
    public class QueriesAndreAirLines
    {
        static readonly HttpClient client = new HttpClient();

        public static async Task<AirPort> SearchAiportInApi(string id)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("https://localhost:44346/api/AirPort/" + id);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                var airportJson = JsonConvert.DeserializeObject<AirPort>(responseBody);
                return airportJson;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
