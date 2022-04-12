using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AndreAirLinesView.Models;

namespace AndreAirLinesView.Data
{
    public class AndreAirLinesViewContext : DbContext
    {
        public AndreAirLinesViewContext (DbContextOptions<AndreAirLinesViewContext> options)
            : base(options)
        {
        }

        public DbSet<AndreAirLinesView.Models.Airport> Airport { get; set; }
    }
}
