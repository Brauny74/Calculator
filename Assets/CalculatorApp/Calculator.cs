using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;

namespace CalcApp
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
            Regex rx = new Regex("(?:[0-9 ()]+[*+/-])+[0-9 ()]+", RegexOptions.IgnoreCase);
            MatchCollection matches = rx.Matches(expr);
            return matches.Count > 0;
        }

        private static double Calculate(string expr)
        {
            var result = Convert.ToDouble(new DataTable().Compute(expr, null));
            return result;
        }

        public static CalcResult RunExpression(string expr)
        {
            double result;
            CalcResult output;
            if (ExprValid(expr))
            {
                result = Calculate(expr);
                output = new CalcResult(result, false, "Ok");
            }
            else
            {
                output = new CalcResult(0.0, true, "Invalid Expression");
            }
            return output;
        }
    }
}