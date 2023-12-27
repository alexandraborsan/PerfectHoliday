using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PerfectHoliday.Data;
using PerfectHoliday.Models;

namespace PerfectHoliday.Pages.Meals
{
    public class DetailsModel : PageModel
    {
        private readonly PerfectHoliday.Data.PerfectHolidayContext _context;

        public DetailsModel(PerfectHoliday.Data.PerfectHolidayContext context)
        {
            _context = context;
        }

      public Meal Meal { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Meal == null)
            {
                return NotFound();
            }

            var meal = await _context.Meal.FirstOrDefaultAsync(m => m.Id == id);
            if (meal == null)
            {
                return NotFound();
            }
            else 
            {
                Meal = meal;
            }
            return Page();
        }
    }
}
