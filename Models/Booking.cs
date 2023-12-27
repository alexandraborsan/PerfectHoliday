using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PerfectHoliday.Models
{
    public class Booking
    {
        public int Id { get; set; }
        
        [Display(Name = "Begining Date")]
        [DataType(DataType.Date)]
        public DateTime BeginDate { get; set; }
        [Display(Name = "Ending Date")]
        [DataType(DataType.Date)] 
        public DateTime EndDate { get; set; }
        [Display(Name = "Reservation Date")]
        [DataType(DataType.Date)]
        public DateTime ReservationDate { get; set; }
        [Display(Name = "Number of adults")]
        public int NumberOfAdults { get; set; }
        [Display(Name = "Number of children")]
        public int? NumberOfKids { get; set; } // Acesta este optional

        [Column(TypeName = "decimal(6, 2)")] 
        public decimal Price { get; set; }
        [Display(Name = "Hotel")]
        public int? HotelID { get; set; }
        public Hotel? Hotel { get; set; }
        [Display(Name = "Meal Type")]
        public ICollection<MealType>? MealTypes { get; set; }

        public Booking()
        {
            ReservationDate = DateTime.Now; // Se seteaza la data creari obiectului respectiv
        }
    }
}


