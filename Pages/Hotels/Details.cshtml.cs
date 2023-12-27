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
    public class DetailsModel : PageModel
    {
        private readonly PerfectHoliday.Data.PerfectHolidayContext _context;

        public DetailsModel(PerfectHoliday.Data.PerfectHolidayContext context)
        {
            _context = context;
        }

      public Hotel Hotel { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Hotel == null)
            {
                return NotFound();
            }

            var hotel = await _context.Hotel.FirstOrDefaultAsync(m => m.Id == id);
            if (hotel == null)
            {
                return NotFound();
            }
            else 
            {
                Hotel = hotel;
            }
            return Page();
        }
    }
}
