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
            string input = args.ToString();
            if (args.Length == 0)
            {
                Console.WriteLine("Enter arguments in comma-separated list:");
                input = Console.ReadLine();
            }
            while (!string.IsNullOrEmpty(input))
            {
                Order order = new Order(input);

                //Use facade to validate, process and recieve output
                string summary = order.ProcessOrder();

                //Wait for further directions
                Console.WriteLine(summary);
                input = Console.ReadLine();
            }

        }
    }
}
