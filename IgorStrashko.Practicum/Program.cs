using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IgorStrashko.Practicum.BLL;

namespace IgorStrashko.Practicum
{
    class Program
    {
        static void Main(string[] args)
        {
            Order order = new Order(args[0]);

            //Use facade to validate, process and recieve output
            string summary = order.ProcessOrder();
            
            //Wait for further directions
            Console.WriteLine(summary);
            Console.ReadLine();


        }
    }
}
