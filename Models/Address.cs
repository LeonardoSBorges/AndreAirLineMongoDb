using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Address
    {
        [JsonProperty("cep")]
        public string Cep{ get; set; }

        [JsonProperty("localidade")]
        public string City { get; set; }
        public string Country { get; set; } = "Brasil";

        [JsonProperty("logradouro")]
        public string Street { get; set; }

        [JsonProperty("bairro")]
        public string District { get; set; }

        [JsonProperty("cep")]
        public int Number { get; set; }

        public Address()
        {

        }

        public Address(string cep, string city, string street, string district, int number)
        {
            Cep = cep;
            City = city;
            Street = street;
            District = district;
            Number = number;
        }
    }
}
