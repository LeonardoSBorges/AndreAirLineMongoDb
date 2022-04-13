using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AndreAirLines.EF.Models;

namespace AndreAirLines.EF.Data
{
    public class AndreAirLinesEFContext : DbContext
    {
        public AndreAirLinesEFContext (DbContextOptions<AndreAirLinesEFContext> options)
            : base(options)
        {
        }

        public DbSet<AndreAirLines.EF.Models.Airport> Airport { get; set; }
    }
}
