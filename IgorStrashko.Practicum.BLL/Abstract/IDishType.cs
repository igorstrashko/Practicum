using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IgorStrashko.Practicum.BLL.Abstract
{
    public interface IDishType
    {
        string Entree { get;}
        string Side { get; }
        string Drink { get; }
        string Dessert { get;}
    }
}
