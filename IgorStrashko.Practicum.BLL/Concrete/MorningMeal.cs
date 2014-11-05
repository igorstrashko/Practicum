using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IgorStrashko.Practicum.BLL.Abstract;

namespace IgorStrashko.Practicum.BLL
{
    internal class MorningMeal: MealType
    {
        public MorningMeal()
        {
            Entrees = new List<string>();
            Sides = new List<string>();
            Drinks = new List<string>();
            Desserts = new List<string>();

        }
        //Morning dish implementations
        public override string Entree
        {
            get
            {
                return "eggs";
            }
        }

        public override string Side
        {
            get
            {
                return "toast";
            }
        }

        public override string Drink
        {
            get
            {
                return "coffee";
            }

        }

        public override string Dessert
        {
            get
            {
                return "error";//no dessert in the morning :-(
            }
        }

        //Morning allowances
        protected  override int AllowedDrinks
        {
            get { return Int16.MaxValue; }
        }

        protected override int AllowedDesserts
        {
            get { return 0; }
        }

      
    }
}
