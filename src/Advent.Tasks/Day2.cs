using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Advent.Tasks
{
    public static class Day2
    {
        public static async Task<int> Task1(string file)
        {
            var passwords = await Parse(file);
            return passwords.Count(p =>
            {
                var (rule, password) = p;
                var count = password.Count(c => c == rule.Character);
                return count >= rule.Lower && count <= rule.Upper;
            });
        }

        public static async Task<int> Task2(string file)
        {
            var passwords = await Parse(file);
            return passwords.Count(p =>
            {
                var (rule, password) = p;

                var char1 = password[rule.Lower];
                var char2 = password[rule.Upper];

                return (char1 == rule.Character) ^ (char2 == rule.Character);
            });
        }

        private static async Task<(Rule, string)[]> Parse(string file)
        {
            var input = await File.ReadAllLinesAsync(file);
            return input.Select(line =>
            {
                var s = line.Split(':');
                return (new Rule(s[0]), s[1]);
            }).ToArray();
        }
    }

    public struct Rule
    {
        public Rule(string rule)
        {
            var parts = rule.Split(' ');
            var character = char.Parse(parts[1]);
            var range = parts[0].Split('-');
            var lower = int.Parse(range[0]);
            var upper = int.Parse(range[1]);

            Lower = lower;
            Upper = upper;
            Character = character;
        }

        public int Lower { get; }
        public int Upper { get; }
        public char Character { get; }
    }
}
