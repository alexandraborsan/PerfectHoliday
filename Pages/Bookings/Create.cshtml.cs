using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PerfectHoliday.Data;
using PerfectHoliday.Models;

namespace PerfectHoliday.Pages.Bookings
{
    public class CreateModel : MealTypesPageModel
    {
        private readonly PerfectHoliday.Data.PerfectHolidayContext _context;

        public CreateModel(PerfectHoliday.Data.PerfectHolidayContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["HotelID"] = new SelectList(_context.Set<Hotel>(), "Id",
           "HotelName");
            var booking = new Booking();
            booking.MealTypes = new List<MealType>();
            PopulateAssignedMealType(_context, booking);
            return Page();
        }

        [BindProperty]
        public Booking Booking { get; set; }
        public async Task<IActionResult> OnPostAsync(string[] selectedMeals)
        {
            var newBooking = new Booking();
            if (selectedMeals != null)
            {
                newBooking.MealTypes = new List<MealType>();
                foreach (var cat in selectedMeals)
                {
                    var catToAdd = new MealType
                    {
                        MealId = int.Parse(cat)
                    };
                    newBooking.MealTypes.Add(catToAdd);
                }
            }
            Booking.MealTypes = newBooking.MealTypes;

            if (!ModelState.IsValid || _context.Booking == null || Booking == null)
            {
                return Page();
            }

            _context.Booking.Add(Booking);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }

    }
}
