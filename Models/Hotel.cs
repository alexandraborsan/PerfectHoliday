using System.ComponentModel.DataAnnotations;

namespace PerfectHoliday.Models
{
    public class Hotel
    {
        public int Id { get; set; }
        [Display(Name = "Hotel")]
        public string HotelName { get; set; }
        [Display(Name = "Number of Stars")]
        public int NumberOfStars { get; set; }
        [Display(Name = "Adress")]
        public string Adress { get; set; }
        public ICollection<Booking>? Bookings { get; set; }
    }
}
