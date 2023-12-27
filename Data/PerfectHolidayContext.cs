using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PerfectHoliday.Models;

namespace PerfectHoliday.Data
{
    public class PerfectHolidayContext : DbContext
    {
        public PerfectHolidayContext (DbContextOptions<PerfectHolidayContext> options)
            : base(options)
        {
        }

        public DbSet<PerfectHoliday.Models.Booking> Booking { get; set; } = default!;

        public DbSet<PerfectHoliday.Models.Hotel>? Hotel { get; set; }
    }
}
