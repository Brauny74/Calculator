using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;

namespace ConsoleCalculator
{
    public struct CalcResult
    {
        public readonly double Result;
        public readonly bool Error;
        public readonly string Status;
        public CalcResult(double result, bool error, string status)
        {
            Result = result;
            Error = error;
            Status = status;
        }
    }

    public static class Calculator
    {
        private static bool ExprValid(string expr)
        {
            Regex rx = new Regex("^[0-9+*-/^()., ]+$", RegexOptions.IgnoreCase);
            MatchCollection matches = rx.Matches(expr);
            int p = 0;
            foreach (char c in expr)
            {
                if (c == '(')
                    p++;
                if (c == ')')
                    p--;
            }
            return p == 0 && matches.Count > 0;
        }

        private static double Calculate(string expr)
        {
            var result = Convert.ToDouble(new DataTable().Compute(expr, null));
            return result;
        }

        public static double RunExpression(string expr)
        {
            double result;
            if (ExprValid(expr))
            {
                result = Calculate(expr);
            }
            else
            {
                throw new ArgumentException("Invalid expression.");
            }
            return result;
        }
    }
}