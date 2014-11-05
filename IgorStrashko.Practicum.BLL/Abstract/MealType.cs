using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IgorStrashko.Practicum.BLL;

namespace IgorStrashko.Practicum.BLL.Abstract
{
    public abstract class MealType: IDishType
    {
        //Containers for items in order
        public IList<string> Entrees { get; set; }
        public IList<string> Sides { get; set; }
        public IList<string> Drinks { get; set; }
        public IList<string> Desserts { get; set; }
        bool invalidItemTypeFound = false;

        //Default for allowed number of dish types
        protected virtual int AllowedEntrees { get { return 1; } }
        protected virtual int AllowedSides { get { return 1; } }
        protected virtual int AllowedDrinks { get { return 1; } }
        protected virtual int AllowedDesserts { get { return 1; } }

        public void AddItems(IList<DishType> dishTypes)
        {
            foreach (var dishType in dishTypes)
            {
                switch (dishType)
                {
                    case DishType.Entree:
                        if (Entrees.Count < AllowedEntrees)
                            Entrees.Add(Entree);
                        else Entrees.Add("error");
                        break;
                    case DishType.Side:
                        if (Sides.Count < AllowedSides)
                            Sides.Add(Side);
                        else Sides.Add("error");
                        break;
                    case DishType.Drink:
                        if (Drinks.Count < AllowedDrinks)
                            Drinks.Add(Drink);
                        else
                            Drinks.Add("error");
                        break;
                    case DishType.Dessert:
                        if (Desserts.Count < AllowedDesserts)
                            Desserts.Add(Dessert);
                        else
                            Desserts.Add("error");
                        break;
                    default://Not one of allowed dish types, once we encounter that, no need to continue
                        invalidItemTypeFound = true;
                        return;
                }
            }
        }

        public virtual string ToSummary()
        {
            StringBuilder summary = new StringBuilder();
            bool stop = false;
            Func<IList<string>, StringBuilder, bool> action = (l, sb) =>
            {
                foreach (var s in l)
                {
                    if (s != "error")
                    {
                        sb.Append(s);
                        sb.Append(", ");
                    }
                    else
                    {
                        //Add "error" and return 
                        sb.Append(s);
                        //No further processing is needed, error encountered
                        stop = true;
                        return true;
                    }
                }
                return true;
            };

            if (Entrees.Count > 1 && (!Entrees.Where(e => e == "error").Any()))
            {
                summary.Append(string.Format("{0}(x{1}), ", Entree, Entrees.Count));
            }
            else
            {
                action(Entrees, summary);
            }
            if (!stop)
            {
                if (Sides.Count > 1 && (!Sides.Where(e => e == "error").Any()))
                {
                    summary.Append(string.Format("{0}(x{1}), ", Side, Sides.Count));
                }
                else
                {
                    action(Sides, summary);
                }
            }
            if (!stop)
            {
                if (Drinks.Count > 1 && (!Drinks.Where(e => e == "error").Any()))
                {
                    summary.Append(string.Format("{0}(x{1}), ", Drink, Drinks.Count));
                }
                else
                {
                    action(Drinks, summary);
                }
            }
            if (!stop)
            {
                if (Desserts.Count > 1 && (!Desserts.Where(e => e == "error").Any()))
                {
                    summary.Append(string.Format("{0}(x{1}), ", Dessert, Desserts.Count));
                }
                else
                {
                    action(Desserts, summary);
                }
            }
            if (!stop)
            {
                if (invalidItemTypeFound)
                {
                    summary.Append("error");
                    return summary.ToString();
                }
            }
            return summary.ToString().Trim().TrimEnd(',');
        }

        //IDish types
        public abstract string Entree { get; }

        public abstract string Side { get; }

        public abstract string Drink {get;}

        public abstract string Dessert { get; }
    }
}
