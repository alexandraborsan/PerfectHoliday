using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PerfectHoliday.Data;
using PerfectHoliday.Models;
using System.Collections.Generic;

namespace PerfectHoliday.Pages.Bookings
{
    public class EditModel : MealTypesPageModel
    {
        private readonly PerfectHolidayContext _context;

        public EditModel(PerfectHolidayContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Booking Booking { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Booking = await _context.Booking
                .Include(b => b.Hotel)
                .Include(b => b.MealTypes).ThenInclude(b => b.Meal)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Booking == null)
            {
                return NotFound();
            }

            PopulateAssignedMealType(_context, Booking);

            ViewData["HotelID"] = new SelectList(_context.Set<Hotel>(), "Id", "HotelName");
            return Page();
        }

        private IActionResult NotFound()
        {
            throw new NotImplementedException();
        }

        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedMeals)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookingToUpdate = await _context.Booking
            .Include(i => i.Hotel)
            .Include(i => i.MealTypes)
            .ThenInclude(i => i.Meal)
            .FirstOrDefaultAsync(s => s.Id == id);
            if (bookingToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Booking>(
            bookingToUpdate,
            "Booking",
            i => i.BeginDate, i => i.EndDate,
            i => i.ReservationDate, i => i.NumberOfAdults,
            i => i.NumberOfKids, i => i.Price, i => i.HotelID))
            {
                UpdateMealTypes(_context, selectedMeals, bookingToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            UpdateMealTypes(_context, selectedMeals, bookingToUpdate);
            PopulateAssignedMealType(_context, bookingToUpdate);
            return Page();
        }
    }
}
