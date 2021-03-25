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
            if (args.Length > 0 && args[0] != null && args[0].Trim() != "")
            {
                CalcResult calcResult = Calculator.RunExpression(args[0]);
                if (!calcResult.Error)
                {
                    Console.WriteLine(calcResult.Result);
                }
                else
                {
                    Console.WriteLine("Error: " + calcResult.Status);
                }
            }
            else
                Console.WriteLine("No valid argument found.");
            Console.Write("Press Enter to continue");
            Console.ReadLine();
        }
    }
}
