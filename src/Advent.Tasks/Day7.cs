using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Advent.Tasks
{
    public class Day7
    {
        public static async Task<int> Task1(string file)
        {
            var rules = await ParseRules(file);

            var lookup = rules
                .SelectMany(kvp => kvp.Value, (kvp, c) => (from: kvp.Key, bag: c.Item1))
                .ToLookup(x => x.bag, x => x.from);

            var bags = new HashSet<string>();
            BagsThatContain("shiny gold", lookup, bags);

            return bags.Skip(1).Count();
        }

        public static async Task<int> Task2(string file)
        {
            var rules = await ParseRules(file);
            return TotalBags(rules, "shiny gold") - 1;
        }

        private static void BagsThatContain(string bag, ILookup<string, string> lookup, HashSet<string> bags)
        {
            bags ??= new HashSet<string>();

            if (bags.Contains(bag))
                return;

            bags.Add(bag);

            foreach (var b in lookup[bag])
                BagsThatContain(b, lookup, bags);
        }

        private static int TotalBags(Dictionary<string, (string, int)[]> rules, string bag)
        {
            var current = rules[bag];

            if (!current.Any()) return 1;

            var total = 1;
            foreach (var (key, value) in current)
            {
                var increase = TotalBags(rules, key);
                total += value * increase;
            }

            return total;
        }

        private static async Task<Dictionary<string, (string, int)[]>> ParseRules(string file)
        {
            var lines = await LittleHelper.Parse(file, "\n", s => s);

            var rules = new Dictionary<string, (string, int)[]>();
            foreach (var line in lines)
            {
                var regex = Regex.Match(line, @"(.*) bags contain (.*)");
                var bag = regex.Groups[1].Value;

                var inner = new List<(string, int)>();
                if (!regex.Groups[2].Value.EndsWith("no other bags."))
                {
                    foreach (var rule in regex.Groups[2].Value.Split(','))
                    {
                        var ruleMatch = Regex.Match(rule, @"(\d)(.*) bag[s]?[.]?");
                        inner.Add((ruleMatch.Groups[2].Value.Trim(), int.Parse(ruleMatch.Groups[1].Value)));
                    }
                }

                rules.Add(bag, inner.ToArray());
            }
            return rules;
        }
    }
}
