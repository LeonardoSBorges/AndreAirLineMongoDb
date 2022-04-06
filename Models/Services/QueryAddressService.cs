using Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace AndreAirLinesWebApplication.Service
{
    public class QueryAddressService 
    {
        public static async Task<Address> HTTPCorreios(string cep)
        {
            var client = new HttpClient();

            client.BaseAddress = new Uri("https://viacep.com.br/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.GetAsync($"ws/{cep}/json/");

            var viaCep = await response.Content.ReadAsStringAsync();
            var address = JsonConvert.DeserializeObject<Address>(viaCep);
            return address;
        }

        
    }
}
