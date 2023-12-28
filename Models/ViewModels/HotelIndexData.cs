using PerfectHoliday.Models;
using System.Security.Policy;

namespace PerfectHoliday.Models.ViewModels
{
    public class HotelIndexData
    {
        public IEnumerable<Hotel> Hotels { get; set; }
        public IEnumerable<Booking> Bookings { get; set; }
    }
}
