using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PerfectHoliday.Data;
using PerfectHoliday.Models;

namespace PerfectHoliday.Pages.Hotels
{
    public class IndexModel : PageModel
    {
        private readonly PerfectHoliday.Data.PerfectHolidayContext _context;

        public IndexModel(PerfectHoliday.Data.PerfectHolidayContext context)
        {
            _context = context;
        }

        public IList<Hotel> Hotel { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Hotel != null)
            {
                Hotel = await _context.Hotel.ToListAsync();
            }
        }
    }
}
