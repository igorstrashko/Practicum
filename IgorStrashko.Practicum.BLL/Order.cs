using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using  IgorStrashko.Practicum.BLL;
using IgorStrashko.Practicum.BLL.Abstract;

namespace IgorStrashko.Practicum
{
    /// <summary>
    /// Facade class to validate and process an order
    /// </summary>
    public class Order
    {
        public bool IsValid { get; set; }
        public string Error { get; set; }
        //Standard error messages
        public const string INVALID_LENGTH = "Input has to have Time of Day and at least one Dish Type selection";
        public const string INVALID_TOD = "You must enter time of day as 'morning' or 'night'";

        protected string MealType { get; set; }
        protected IList<DishType> DishTypes { get; set; }

        public Order(string input)
        {
            DishTypes = new List<DishType>();
            var splitInput = input.Split(',').Where(s=>s.Length>0).ToArray();
            //Must have meal type specified + at least 1 selectin (so 2 args min)
            if (input == null || splitInput.Length < 2)
            {
                IsValid = false;
                Error = INVALID_LENGTH;
            }
            else
            {
                IsValid = true;
                var isFirst = true;
                foreach (var s in splitInput)
                {
                    //Time of Day must be first element
                    if (isFirst)
                    {
                        if (s.ToLower() == "morning")
                            MealType = "morning";
                        else if (s.ToLower() == "night")
                            MealType = "night";
                        else
                        {
                            IsValid = false;
                            Error = INVALID_TOD;
                        }
                        isFirst = false;//done with Time of Day
                    }
                    else
                    {
                        //Convert to DishType enum if possible
                        DishType dt = (DishType)Enum.Parse(typeof(DishType), s);
                        DishTypes.Add(dt);
                    }
                }

            }
        }

        public string ProcessOrder()
        {
            var output = "";
            if (IsValid)
            {
                //Get meal type that customer wants (morning, night, snack, etc)
                MealType mealType = GetMealType(MealType);
                //Add dish types customer specified to the meal
                mealType.AddItems(DishTypes);
                output=mealType.ToSummary();
            }
            else
            {
                output=Error;
            }
            return output;
        }
        /// <summary>
        /// Factory-type method to create proper MealType object based on timeofDay
        /// </summary>
        /// <param name="timeofDay"></param>
        /// <returns></returns>
        private static MealType GetMealType(string timeofDay)
        {
            switch (timeofDay.ToLower())
            {
                case "morning":
                    return new MorningMeal();
                case "night":
                    return new NightMeal();
                default:
                    return null;
            }
        }
    }
}
    
