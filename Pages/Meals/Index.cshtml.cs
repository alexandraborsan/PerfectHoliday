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
    public class IndexModel : PageModel
    {
        private readonly PerfectHoliday.Data.PerfectHolidayContext _context;

        public IndexModel(PerfectHoliday.Data.PerfectHolidayContext context)
        {
            _context = context;
        }

        public IList<Meal> Meal { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Meal != null)
            {
                Meal = await _context.Meal.ToListAsync();
            }
        }
    }
}
