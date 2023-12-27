using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PerfectHoliday.Data;
using PerfectHoliday.Models;

namespace PerfectHoliday.Pages.Bookings
{
    public class DetailsModel : PageModel
    {
        private readonly PerfectHoliday.Data.PerfectHolidayContext _context;

        public DetailsModel(PerfectHoliday.Data.PerfectHolidayContext context)
        {
            _context = context;
        }

      public Booking Booking { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Booking == null)
            {
                return NotFound();
            }

            var booking = await _context.Booking.FirstOrDefaultAsync(m => m.Id == id);
            if (booking == null)
            {
                return NotFound();
            }
            else 
            {
                Booking = booking;
            }
            return Page();
        }
    }
}
