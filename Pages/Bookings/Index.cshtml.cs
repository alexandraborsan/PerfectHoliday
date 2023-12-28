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
        public string BeginDateSort { get; set; }
        public string ReservationDateSort { get; set; }
        public string? CurrentFilter { get; set; }
        public DateTime? CurrentDateFilter { get; set; }
        public async Task OnGetAsync(int? id, int? mealId, string sortOrder, string searchString, DateTime searchDate)
        {
            BookingD = new BookingData();
            BeginDateSort = String.IsNullOrEmpty(sortOrder) ? "beginDate_desc" : "beginDate";
            ReservationDateSort = String.IsNullOrEmpty(sortOrder) ? "reservationDate_desc" : "reservationDate";
            CurrentFilter = searchString;
            CurrentDateFilter = searchDate;

            BookingD.Bookings = await _context.Booking
            .Include(b => b.Hotel)
            .Include(b => b.MealTypes)
            .ThenInclude(b => b.Meal)
            .AsNoTracking()
            .OrderBy(b => b.BeginDate)
            .ToListAsync();
            if (!String.IsNullOrEmpty(searchString))
            {
                BookingD.Bookings = BookingD.Bookings.Where(s => s.Hotel.HotelName.Contains(searchString));
            }
            if (searchDate != default)
            {
                BookingD.Bookings = BookingD.Bookings.Where(s => s.ReservationDate.Date == searchDate.Date
                || s.BeginDate.Date == searchDate.Date);
            }
                if (id != null)
            {
                BookingId = id.Value;
                Booking booking = BookingD.Bookings
                .Where(i => i.Id == id.Value).Single();
                BookingD.Meals = booking.MealTypes.Select(s => s.Meal);
            }
            switch (sortOrder)
            {
                case "beginDate_desc":
                    BookingD.Bookings = BookingD.Bookings.OrderByDescending(s => s.BeginDate);
                    break;
                case "reservationDate_desc":
                    BookingD.Bookings = BookingD.Bookings.OrderByDescending(s => s.ReservationDate);
                    break;
                case "beginDate":
                    BookingD.Bookings = BookingD.Bookings.OrderBy(s => s.BeginDate);
                    break;
                case "reservationDate":
                    BookingD.Bookings = BookingD.Bookings.OrderBy(s => s.ReservationDate);
                    break;
                default:
                    BookingD.Bookings = BookingD.Bookings.OrderBy(s => s.BeginDate);
                    break;
            }

        }
    }
}
