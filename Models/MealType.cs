namespace PerfectHoliday.Models
{
    public class MealType
    {
        public int Id { get; set; }
        public int BookingId { get; set; }
        public Booking Booking { get; set; }
        public int MealId { get; set; }
        public Meal Meal { get; set; }

    }
}
