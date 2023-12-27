namespace PerfectHoliday.Models
{
    public class BookingData
    {
        public IEnumerable<Booking> Bookings { get; set; }
        public IEnumerable<Meal> Meals { get; set; }
        public IEnumerable<MealType> MealTypes { get; set; }
    }
}
