using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ViewAirport.Models;

namespace ViewAirport.Data
{
    public class ViewAirportContext : DbContext
    {
        public ViewAirportContext (DbContextOptions<ViewAirportContext> options)
            : base(options)
        {
        }

        public DbSet<ViewAirport.Models.Airport> Airport { get; set; }
    }
}
