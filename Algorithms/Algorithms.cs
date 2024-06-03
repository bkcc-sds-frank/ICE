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

        public static string FormatSeparators(params string[] items) => throw new NotImplementedException();
    }
}