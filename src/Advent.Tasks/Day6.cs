using System;
using System.Collections.Generic;
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
                var groupAnswers = line.Split("\n", StringSplitOptions.RemoveEmptyEntries);
                var groupSize = groupAnswers.Length;
                var counts = new Dictionary<char, int>();
                foreach (var personAnswers in groupAnswers)
                {
                    foreach (var answer in personAnswers)
                    {
                        counts.TryAdd(answer, 0);
                        counts[answer]++;
                    }
                }
                count += counts.Count(c => c.Value == groupSize);
            }

            return count;
        }
    }
}
