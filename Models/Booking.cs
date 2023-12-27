﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PerfectHoliday.Models
{
    public class Booking
    {
        public int Id { get; set; }
        [Display(Name = "Begining Date")]
        public DateTime BeginDate { get; set; }
        [Display(Name = "Ending Date")]
        public DateTime EndDate { get; set; }
        [Display(Name = "Reservation Date")]
        public DateTime ReservationDate { get; set; }
        [Display(Name = "Number of adults")]
        public int NumberOfAdults { get; set; }
        [Display(Name = "Number of kids")]
        public int? NumberOfKids { get; set; } // Acesta este optional

        [Column(TypeName = "decimal(6, 2)")] 
        public decimal Price { get; set; }
        public int? HotelID { get; set; }
        public Hotel? Hotel { get; set; }

        public Booking()
        {
            ReservationDate = DateTime.Now; // Se seteaza la data creari obiectului respectiv
        }
    }
}


