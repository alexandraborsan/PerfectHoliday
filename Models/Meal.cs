namespace PerfectHoliday.Models
{
    public class Meal
    {
        public int Id { get; set; }
        public string MealPlan { get; set; }
        public ICollection<MealType>? MealTypes { get; set; }

    }
}
