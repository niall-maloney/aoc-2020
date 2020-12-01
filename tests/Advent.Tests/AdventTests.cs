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
    }
}
