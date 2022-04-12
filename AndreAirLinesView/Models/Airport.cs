using System.ComponentModel.DataAnnotations;

namespace AndreAirLinesView.Models
{
    public class Airport
    {
        [Key]
        public string Abbreviation { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public  string Continent { get; set; }
    }
}
