using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Advent.Tasks
{
    public class Day5
    {
        public static async Task<int> Task1(string file)
        {
            var seats = await GetSeats(file);
            return seats.Max();
        }

        public static async Task<int> Task2(string file)
        {
            var seats = await GetSeats(file);
            for (var row = 0; row < 128; row++)
            {
                for (var col = 0; col < 8; col++)
                {
                    var seat = row * 8 + col;
                    if (seats.Contains(seat))
                    {
                        continue;
                    }

                    if (seats.Contains((row - 1) * 8 + col - 1) && seats.Contains((row + 1) * 8 + col + 1))
                    {
                        return seat;
                    }
                }
            }
            return -1;
        }

        private static async Task<HashSet<int>> GetSeats(string file)
        {
            var lines = await LittleHelper.Parse(file, "\n", s => s);
            var map = new Dictionary<string, string> { { "F", "0" }, { "B", "1" }, { "L", "0" }, { "R", "1" } };
            var regex = new Regex(string.Join("|", map.Keys));
            var seats = new HashSet<int>();
            foreach (var line in lines)
            {
                var pass = regex.Replace(line, m => map[m.Value]);
                var row = Convert.ToInt32(pass.Substring(0, 7), 2);
                var col = Convert.ToInt32(pass.Substring(7, 3), 2);
                var seat = row * 8 + col;
                seats.Add(seat);
            }
            return seats;
        }
    }
}
