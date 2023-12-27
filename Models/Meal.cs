using System.ComponentModel.DataAnnotations;

namespace PerfectHoliday.Models
{
    public class Meal
    {
        public int Id { get; set; }
        [Display(Name = "Meal Plan")]
        public string MealPlan { get; set; }
        public ICollection<MealType>? MealTypes { get; set; }

    }
}
