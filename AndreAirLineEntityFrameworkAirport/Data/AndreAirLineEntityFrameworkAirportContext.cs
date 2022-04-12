using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace AndreAirLineEntityFrameworkAirport.Data
{
    public class AndreAirLineEntityFrameworkAirportContext : DbContext
    {
        public AndreAirLineEntityFrameworkAirportContext (DbContextOptions<AndreAirLineEntityFrameworkAirportContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Airport> Airport { get; set; }
    }
}
