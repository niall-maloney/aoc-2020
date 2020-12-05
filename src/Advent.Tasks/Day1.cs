using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Advent.Tasks
{
    public class Day1
    {
        public static async Task<(int a, int b, int x)> Task1(string file)
        {
            var numbers = await Parse(file);

            var map = new Dictionary<int, int?>();
            foreach (var number in numbers)
            {
                if (map.TryGetValue(number, out var match))
                {
                    return (number, match.Value, number * match.Value);
                }

                map[2020 - number] = number;
            }
            throw new KeyNotFoundException();
        }

        public static async Task<(int a, int b, int c, int x)> Task2(string file)
        {
            var numbers = await Parse(file);

            var startingMap = numbers.ToDictionary(n => 2020 - n, n => n);

            var finalMap = new Dictionary<int, (int, int)>();
            foreach (var number in numbers)
            {
                if (finalMap.TryGetValue(number, out var match))
                {
                    var (match1, match2) = match;
                    return (number, match1, match2, number * match1 * match2);
                }
                foreach (var (key, value) in startingMap)
                {
                    finalMap[key - number] = (value, number);
                }
            }
            throw new KeyNotFoundException();
        }

        private static Task<int[]> Parse(string file)
        {
            return LittleHelper.Parse(file, "\n", int.Parse);
        }
    }
}