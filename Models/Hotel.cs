namespace PerfectHoliday.Models
{
    public class Hotel
    {
        public int Id { get; set; }
        public string HotelName { get; set; }
        public int NumberOfStars { get; set; }
        public string Adress { get; set; }
        public ICollection<Booking>? Bookings { get; set; }
    }
}
