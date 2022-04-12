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

        public static async Task<Address> HttpCorreios(string cep)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync($"https://viacep.com.br/ws/{cep}/json");
                response.EnsureSuccessStatusCode();
                string responseBody =await response.Content.ReadAsStringAsync();
                var addressJson = JsonConvert.DeserializeObject<Address>(responseBody);

                return addressJson;
            }
            catch(Exception)
            {
                throw;
            }
        }

        public static async Task<Airport> SearchAiport(string id)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("https://localhost:44346/api/AirPort/" + id);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                var airportJson = JsonConvert.DeserializeObject<Airport>(responseBody);
                return airportJson;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async Task<AirPlane> SearchAirplane(string id)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("https://localhost:44331/api/AirPlane/" + id);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                var airportJson = JsonConvert.DeserializeObject<AirPlane>(responseBody);
                return airportJson;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async Task<Fly> SearchFly(string ticket)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("https://localhost:44348/api/Flight/" + ticket);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                var flyJson = JsonConvert.DeserializeObject<Fly>(responseBody);

                return flyJson;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async Task<Person> SearchPerson(string cpf)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("https://localhost:44327/api/Person/" + cpf);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                var personJson = JsonConvert.DeserializeObject<Person>(responseBody);

                return personJson;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static async Task<BasePrice> SearchBasePrice(string id)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("https://localhost:44358/api/BasePrice/" + id);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                var personJson = JsonConvert.DeserializeObject<BasePrice>(responseBody);

                return personJson;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async Task<Class> SearchClass(string id)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("https://localhost:44344/apiClass/"+ id);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                var classResponse = JsonConvert.DeserializeObject<Class>(responseBody);
                return classResponse; 
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}


//{
//    "reserve": "string",
//  "flightId": "Leo",
//  "personId": "50593308859",
//  "basePriceId": "6251a365634eedcba442d4f7",
//  "classId": "624fa0a33b6840a7a20c266b",
//  "registerDate": "2022-04-11T16:42:44.554Z",
//  "totalValue": 0,
//  "sale": 0
//}