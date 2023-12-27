namespace PerfectHoliday.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime ReservationDate { get; set; }
        public int NumberOfAdults { get; set; }
        public int? NumberOfKids { get; set; } // Acesta este optional
        public decimal Price { get; set; }

        public Booking()
        {
            ReservationDate = DateTime.Now; // Se seteaza la data creari obiectului respectiv
        }
    }
}
