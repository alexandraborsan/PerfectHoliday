using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PerfectHoliday.Data;
using PerfectHoliday.Models;
using PerfectHoliday.Models.ViewModels;

namespace PerfectHoliday.Pages.Hotels
{
    public class IndexModel : PageModel
    {
        private readonly PerfectHoliday.Data.PerfectHolidayContext _context;

        public IndexModel(PerfectHoliday.Data.PerfectHolidayContext context)
        {
            _context = context;
        }

        public IList<Hotel> Hotel { get; set; } = default!;

        public HotelIndexData HotelData { get; set; }
        public int HotelId { get; set; }
        public int BookingId { get; set; }
        public async Task OnGetAsync(int? id, int? bookingID)
        {
            HotelData = new HotelIndexData();
            HotelData.Hotels = await _context.Hotel
            .Include(i => i.Bookings)
            .OrderBy(i => i.HotelName)
            .ToListAsync();
            if (id != null)
            {
                HotelId = id.Value;
                Hotel hotel = HotelData.Hotels
                .Where(i => i.Id == id.Value).Single();
                HotelData.Bookings = hotel.Bookings;
            }
        }
    }
}
