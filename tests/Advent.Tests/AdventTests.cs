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
    }
}
