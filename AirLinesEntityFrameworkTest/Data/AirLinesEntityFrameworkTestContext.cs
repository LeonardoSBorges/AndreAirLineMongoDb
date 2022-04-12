using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ModelShare;

namespace AirLinesEntityFrameworkTest.Data
{
    public class AirLinesEntityFrameworkTestContext : DbContext
    {
        public AirLinesEntityFrameworkTestContext (DbContextOptions<AirLinesEntityFrameworkTestContext> options)
            : base(options)
        {
        }

        public DbSet<ModelShare.Airport> Airport { get; set; }
    }
}
