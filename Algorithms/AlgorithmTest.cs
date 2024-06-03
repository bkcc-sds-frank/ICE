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

        [Fact]
        public void CanFormatSeparators()
        {
            Assert.Equal("", Algorithms.FormatSeparators(null));
            Assert.Equal("", Algorithms.FormatSeparators(""));
            Assert.Equal("a", Algorithms.FormatSeparators("a"));
            Assert.Equal("a and b", Algorithms.FormatSeparators("a", "b"));
            Assert.Equal("a and b", Algorithms.FormatSeparators("a", "b"));
            Assert.Equal("item1, item2 and item3", Algorithms.FormatSeparators("item1", "item2", "item3"));
            Assert.Equal("a, b, c and d", Algorithms.FormatSeparators("a", "b", "c", "d"));
        }
    }
}