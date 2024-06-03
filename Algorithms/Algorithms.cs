using System;

namespace DeveloperSample.Algorithms
{
    public static class Algorithms
    {
        public static int GetFactorial(int n)
        {
            if (n < 0)
            {
                throw new ArgumentException("Factorial definition specifies the input must be a positive integer.");
            }

            if (n < 2)
            {
                return 1;
            }

            int result = checked(n * GetFactorial(n - 1));

            return result;
        }

        public static string FormatSeparators(params string[] items)
        {
            string wip = "";
            if (null == items)
            {
                return "";
            }
            if (items == null)
            {
                return "";
            }

            if (items.Length == 0)
            {
                return "";
            }

            if (items.Length == 1)
            {
                return items[0];
            }

            if (items.Length == 2)
            {
                return $"{items[items.Length - 2]} and {items[items.Length - 1]}";
            }

            var idx = items.Length - 1;
            while (idx > -1)
            {
                wip = Next(items, idx) + wip;
                idx--;
            }
            return wip;
        }

        private static string Next(string[] items, int idx)
        {
            if (idx == items.Length - 1)
            {
                return $"{items[items.Length - 2]} and {items[items.Length - 1]}";
            }

            if (idx == items.Length - 2) //skip the first item in the "and" portion
            {
                return "";
            }

            return items[idx] + ", ";
        }

    }
}