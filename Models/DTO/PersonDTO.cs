using Models;
using System;

namespace Models.DTO
{
    public class PersonDTO
    {
        public string Document { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime Date { get; set; }
        public string Email { get; set; }
        public Address Address { get; set; }
    }
}
