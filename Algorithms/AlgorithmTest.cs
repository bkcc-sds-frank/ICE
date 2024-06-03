using System;
using Xunit;

namespace DeveloperSample.Algorithms
{
    public class AlgorithmTest
    {
        [Fact]
        public void CanGetFactorial()
        {
            Assert.Equal(1, Algorithms.GetFactorial(0));
            Assert.Equal(1, Algorithms.GetFactorial(1));
            Assert.Equal(2, Algorithms.GetFactorial(2));
            Assert.Equal(6, Algorithms.GetFactorial(3));
            Assert.Equal(24, Algorithms.GetFactorial(4));
            var argEx = Assert.Throws<ArgumentException>(() => Algorithms.GetFactorial(-1));
            var overEx = Assert.Throws<OverflowException>(() => Algorithms.GetFactorial(20));
        }

        [Fact(Skip = "Not implemented")]
        public void CanFormatSeparators()
        {
            Assert.Equal("a, b and c", Algorithms.FormatSeparators("a", "b", "c"));
        }
    }
}