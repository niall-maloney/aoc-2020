using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Advent.Tasks
{
    public class Day4
    {
        public static async Task<int> Task1(string file)
        {
            var lines = await LittleHelper.Parse(file, "\n\n", l => l);

            var required = new[] { "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid" };

            return lines.Count(line => required.All(line.Contains));
        }

        public static async Task<int> Task2(string file)
        {
            var lines = await LittleHelper.Parse(file, "\n\n", l => l);
            return lines.Count(IsValid);
        }

        private static bool IsValid(string line)
        {
            var byrMatch = Regex.Match(line, @"byr:(\d{4})(\s|$)");
            var iyrMatch = Regex.Match(line, @"iyr:(\d{4})(\s|$)");
            var eyrMatch = Regex.Match(line, @"eyr:(\d{4})(\s|$)");
            var hgtMatch = Regex.Match(line, @"hgt:(\d*)(cm|in)");
            var hclMatch = Regex.Match(line, @"hcl:(#[0-9a-f]{6})(\s|$)");
            var eclMatch = Regex.Match(line, @"ecl:([a-z]{3})(\s|$)");
            var pidMatch = Regex.Match(line, @"pid:([0-9]{9})(\s|$)");

            var valid = byrMatch.Success &&
                        iyrMatch.Success &&
                        eyrMatch.Success &&
                        hgtMatch.Success &&
                        hclMatch.Success &&
                        eclMatch.Success &&
                        pidMatch.Success;

            if (!valid)
            {
                return false;
            }

            var byr = int.Parse(byrMatch.Groups[1].Value);
            if (byr < 1920 || byr > 2002)
            {
                valid = false;
            }

            var iyr = int.Parse(iyrMatch.Groups[1].Value);
            if (iyr < 2010 || iyr > 2020)
            {
                valid = false;
            }

            var eyr = int.Parse(eyrMatch.Groups[1].Value);
            if (eyr < 2020 || eyr > 2030)
            {
                valid = false;
            }

            var hgt = int.Parse(hgtMatch.Groups[1].Value);
            var units = hgtMatch.Groups[2].Value;
            switch (units)
            {
                case "cm":
                {
                    if (hgt < 150 || hgt > 193)
                    {
                        valid = false;
                    }
                    break;
                }
                case "in":
                {
                    if (hgt < 59 || hgt > 76)
                    {
                        valid = false;
                    }
                    break;
                }
                default:
                {
                    valid = false;
                    break;
                }
            }

            var ecl = eclMatch.Groups[1].Value;
            var colors = new[] { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };
            if (colors.All(c => c != ecl))
            {
                valid = false;
            }

            return valid;
        }
    }
}
