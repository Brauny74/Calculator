using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0 && args[0].Trim() != "")
            {
                try
                {
                    double calcResult = Calculator.RunExpression(args[0]);
                    Console.WriteLine(calcResult);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine("Error: " + e.Message);
                }
            }
            else
                Console.WriteLine("Error: There is no valid argument.");
            Console.Write("Press any key to continue");
            Console.ReadKey();
        }
    }
}
