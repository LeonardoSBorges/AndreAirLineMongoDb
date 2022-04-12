using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace InsertData.Posts
{
    public class InsertAirport
    { 
        private readonly HttpClient client = new HttpClient();
        public async Task PostData(AirPort fileDeserialize)
        {
            try
            {
                HttpResponseMessage response = client.PostAsync(@"");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                var addressJson = JsonConvert.DeserializeObject<Address>(responseBody);

                return addressJson;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
