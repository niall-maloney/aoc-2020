using Advent.Tasks;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Advent.Tests
{
    public class AdventTests
    {
        private readonly ITestOutputHelper _output;

        public AdventTests(ITestOutputHelper output)
        {
            _output = output;
        }

        #region Day1

        [Theory]
        [InlineData("Resources/Day1/sample1.txt")]
        [InlineData("Resources/Day1/day1.txt")]
        public async Task Day1_Task1(string file)
        {
            var (a, b, x) = await Day1.Task1(file);
            Assert.Equal(a * b, x);
            _output.WriteLine($"{a} * {b} = {x}");
        }

        [Theory]
        [InlineData("Resources/Day1/sample1.txt")]
        [InlineData("Resources/Day1/day1.txt")]
        public async Task Day1_Task2(string file)
        {
            var (a, b, c, x) = await Day1.Task2(file);
            Assert.Equal(a * b * c, x);
            _output.WriteLine($"{a} * {b} * {c} = {x}");
        }

        #endregion

        #region Day2

        [Theory]
        [InlineData("Resources/Day2/sample2.txt", 2)]
        [InlineData("Resources/Day2/day2.txt", 517)]
        public async Task Day2_Task1(string file, int expected)
        {
            var count = await Day2.Task1(file);
            Assert.Equal(expected, count);
            _output.WriteLine($"{count}");
        }

        [Theory]
        [InlineData("Resources/Day2/sample2.txt", 1)]
        [InlineData("Resources/Day2/day2.txt", 284)]
        public async Task Day2_Task2(string file, int expected)
        {
            var count = await Day2.Task2(file);
            Assert.Equal(expected, count);
            _output.WriteLine($"{count}");
        }

        #endregion

        #region Day3

        [Theory]
        [InlineData("Resources/Day3/sample3.txt", 7)]
        [InlineData("Resources/Day3/day3.txt", 178)]
        public async Task Day3_Task1(string file, int expected)
        {
            var count = await Day3.Task1(file);
            Assert.Equal(expected, count);
            _output.WriteLine($"{count}");
        }

        [Theory]
        [InlineData("Resources/Day3/sample3.txt", 336)]
        [InlineData("Resources/Day3/day3.txt", 3492520200)]
        public async Task Day3_Task2(string file, long expected)
        {
            var count = await Day3.Task2(file);
            Assert.Equal(expected, count);
            _output.WriteLine($"{count}");
        }

        #endregion

        #region Day4

        [Theory]
        [InlineData("Resources/Day4/sample4_0.txt", 2)]
        [InlineData("Resources/Day4/day4.txt", 222)]
        public async Task Day4_Task1(string file, long expected)
        {
            var count = await Day4.Task1(file);
            Assert.Equal(expected, count);
            _output.WriteLine($"{count}");
        }

        [Theory]
        [InlineData("Resources/Day4/sample4_1.txt", 0)]
        [InlineData("Resources/Day4/sample4_2.txt", 4)]
        [InlineData("Resources/Day4/day4.txt", 140)]
        public async Task Day4_Task2(string file, long expected)
        {
            var count = await Day4.Task2(file);
            Assert.Equal(expected, count);
            _output.WriteLine($"{count}");
        }

        #endregion

        #region Day5

        [Theory]
        [InlineData("Resources/Day5/sample5_0.txt", 820)]
        [InlineData("Resources/Day5/day5.txt", 896)]
        public async Task Day5_Task1(string file, long expected)
        {
            var max = await Day5.Task1(file);
            Assert.Equal(expected, max);
            _output.WriteLine($"{max}");
        }

        [Theory]
        [InlineData("Resources/Day5/day5.txt", 659)]
        public async Task Day5_Task2(string file, long expected)
        {
            var actual = await Day5.Task2(file);
            Assert.Equal(expected, actual);
            _output.WriteLine($"{actual}");
        }

        #endregion

        #region Day6

        [Theory]
        [InlineData("Resources/Day6/sample6.txt", 11)]
        [InlineData("Resources/Day6/day6.txt", 6947)]
        public async Task Day6_Task1(string file, long expected)
        {
            var count = await Day6.Task1(file);
            Assert.Equal(expected, count);
            _output.WriteLine($"{count}");
        }

        [Theory]
        [InlineData("Resources/Day6/sample6.txt", 6)]
        [InlineData("Resources/Day6/day6.txt", 3398)]
        public async Task Day6_Task2(string file, long expected)
        {
            var count = await Day6.Task2(file);
            Assert.Equal(expected, count);
            _output.WriteLine($"{count}");
        }

        #endregion

        #region Day7

        [Theory]
        [InlineData("Resources/Day7/sample7_0.txt", 4)]
        [InlineData("Resources/Day7/day7.txt", 233)]
        public async Task Day7_Task1(string file, long expected)
        {
            var count = await Day7.Task1(file);
            Assert.Equal(expected, count);
            _output.WriteLine($"{count}");
        }

        [Theory]
        [InlineData("Resources/Day7/sample7_0.txt", 32)]
        [InlineData("Resources/Day7/sample7_1.txt", 126)]
        [InlineData("Resources/Day7/day7.txt", 421550)]
        public async Task Day7_Task2(string file, long expected)
        {
            var count = await Day7.Task2(file);
            Assert.Equal(expected, count);
            _output.WriteLine($"{count}");
        }

        #endregion

        #region Day8

        [Theory]
        [InlineData("Resources/Day8/sample8.txt", 5)]
        [InlineData("Resources/Day8/day8.txt", 1709)]
        public async Task Day8_Task1(string file, long expected)
        {
            var count = await Day8.Task1(file);
            Assert.Equal(expected, count);
            _output.WriteLine($"{count}");
        }

        [Theory]
        [InlineData("Resources/Day8/sample8.txt", 8)]
        [InlineData("Resources/Day8/day8.txt", 1976)]
        public async Task Day8_Task2(string file, long expected)
        {
            var count = await Day8.Task2(file);
            Assert.Equal(expected, count);
            _output.WriteLine($"{count}");
        }

        #endregion
    }
}