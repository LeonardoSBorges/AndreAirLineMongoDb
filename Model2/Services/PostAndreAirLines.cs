using ModelShare.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace ModelShare.Services
{
    public class PostAndreAirLines
    {
        private static readonly HttpClient client = new HttpClient();
        public static async Task PostLog(LogDTO newLogDTO)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync<LogDTO>($"https://localhost:44364/api/Log/", newLogDTO);
        }
    }
}
