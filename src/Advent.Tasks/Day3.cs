using System.Linq;
using System.Threading.Tasks;

namespace Advent.Tasks
{
    public static class Day3
    {
        public static async Task<int> Task1(string file)
        {
            var map = await Parse(file);

            return Solve(map, 3, 1);
        }

        public static async Task<long> Task2(string file)
        {
            var map = await Parse(file);

            var slopes = new[] { (1, 1), (3, 1), (5, 1), (7, 1), (1, 2) };

            long solution = 1;
            foreach (var (right, down) in slopes)
            {
                solution *= Solve(map, right, down);
            }

            return solution;
        }

        private static int Solve(int[][] map, int right, int down)
        {
            var slope = map.Length;
            var width = map[0].Length;

            var count = 0;
            var x = 0;
            var y = 0;
            while (y < slope - 1)
            {
                x += right;
                y += down;

                if (x >= width)
                {
                    x -= width;
                }

                count += map[y][x];
            }

            return count;
        }

        private static Task<int[][]> Parse(string file)
        {
            return LittleHelper.Parse(file, "\n", line => { return line.Select(c => c == '.' ? 0 : 1).ToArray(); });
        }
    }
}
