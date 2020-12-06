using System;
using System.Linq;
using System.Threading.Tasks;

namespace Advent.Tasks
{
    public class Day6
    {
        public static async Task<int> Task1(string file)
        {
            var lines = await LittleHelper.Parse(file, "\n\n", s => s);
            return lines.Sum(line => line.Distinct().Count(char.IsLetter));
        }

        public static async Task<int> Task2(string file)
        {
            var lines = await LittleHelper.Parse(file, "\n\n", s => s);

            var count = 0;
            foreach (var line in lines)
            {
                var answers = line.Split("\n", StringSplitOptions.RemoveEmptyEntries)
                    .Select(s => s.ToCharArray())
                    .ToArray();

                count += answers
                    .Skip(1)
                    .Aggregate(answers.First(), (p1, p2) => p1.Intersect(p2).ToArray())
                    .Count();
            }

            return count;
        }
    }
}
