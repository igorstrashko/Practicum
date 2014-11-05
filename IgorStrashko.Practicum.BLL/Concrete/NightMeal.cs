using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IgorStrashko.Practicum.BLL.Abstract;

namespace IgorStrashko.Practicum.BLL
{
    internal class NightMeal: MealType
    {
        public NightMeal()
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
                return "steak";
            }
        }

        public override string Side
        {
            get
            {
                return "potato";
            }
        }

        public override string Drink
        {
            get
            {
                return "wine";
            }

        }

        public override string Dessert
        {
            get
            {
                return "cake";
            }
        }

        //Morning allowances
        protected  override int AllowedSides
        {
            get { return Int16.MaxValue; }
        }
      
    }
}
