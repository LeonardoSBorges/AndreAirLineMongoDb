using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ModelShare;

namespace AndreAirLine.Dapper.Data
{
    public class AndreAirLineDapperContext : DbContext
    {
        public AndreAirLineDapperContext (DbContextOptions<AndreAirLineDapperContext> options)
            : base(options)
        {
        }

        public DbSet<ModelShare.Airport> Airport { get; set; }
    }
}
