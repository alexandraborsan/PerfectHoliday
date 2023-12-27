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
    public class IndexModel : PageModel
    {
        private readonly PerfectHoliday.Data.PerfectHolidayContext _context;

        public IndexModel(PerfectHoliday.Data.PerfectHolidayContext context)
        {
            _context = context;
        }

        public IList<Booking> Booking { get;set; } = default!;
        public BookingData BookingD { get; set; }
        public int BookingId { get; set; }
        public int MealId { get; set; }
        public async Task OnGetAsync(int? id, int? mealId)
        {
            BookingD = new BookingData();

            BookingD.Bookings = await _context.Booking
            .Include(b => b.Hotel)
            .Include(b => b.MealTypes)
            .ThenInclude(b => b.Meal)
            .AsNoTracking()
            .OrderBy(b => b.BeginDate)
            .ToListAsync();
            if (id != null)
            {
                BookingId = id.Value;
                Booking booking = BookingD.Bookings
                .Where(i => i.Id == id.Value).Single();
                BookingD.Meals = booking.MealTypes.Select(s => s.Meal);
            }
        }

        public async Task OnGetAsync()
        {
            {
                Booking = await _context.Booking
                .Include(b => b.Hotel)
                .ToListAsync();
            }
        }
    }
}
