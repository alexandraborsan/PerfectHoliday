using Microsoft.AspNetCore.Mvc.RazorPages;
using PerfectHoliday.Data;

namespace PerfectHoliday.Models
{
    public class MealTypesPageModel
    {
        public class YourPageModel : PageModel
        {
            public List<AssignedMealType> AssignedMealTypeList;

            public void PopulateAssignedMealType(PerfectHolidayContext context, Booking booking)
            {
                var allMeals = context.Meal;
                var mealTypes = new HashSet<int>(booking.MealTypes.Select(c => c.MealId));

                AssignedMealTypeList = new List<AssignedMealType>();

                foreach (var cat in allMeals)
                {
                    AssignedMealTypeList.Add(new AssignedMealType
                    {
                        MealId = cat.Id,
                        Name = cat.MealPlan,
                        Assigned = mealTypes.Contains(cat.Id)
                    });
                }
            }

            public void UpdateMealTypes(PerfectHolidayContext context, string[] selectedMeals, Booking bookingToUpdate)
            {
                if (selectedMeals == null)
                {
                    bookingToUpdate.MealTypes = new List<MealType>();
                    return;
                }

                var selectedMealsHS = new HashSet<string>(selectedMeals);
                var mealTypes= new HashSet<int>(bookingToUpdate.MealTypes.Select(c => c.Meal.Id));

                foreach (var cat in context.Meal)
                {
                    if (selectedMealsHS.Contains(cat.Id.ToString()))
                    {
                        if (!mealTypes.Contains(cat.Id))
                        {
                            bookingToUpdate.MealTypes.Add(new MealType
                            {
                                BookingId = bookingToUpdate.Id,
                                MealId = cat.Id
                            });
                        }
                    }
                    else
                    {
                        if (mealTypes.Contains(cat.Id))
                        {
                            MealType mealToRemove = bookingToUpdate.MealTypes.SingleOrDefault(i => i.MealId == cat.Id);
                            context.Remove(mealToRemove);
                        }
                    }
                }
            }
        }

    }
}
