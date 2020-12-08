using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Advent.Tasks
{
    public class Day8
    {
        public static async Task<int> Task1(string file)
        {
            var instructions = await LittleHelper.Parse(file, "\n", l =>
            {
                var instruction = l.Split(' ');
                return (instruction[0], instruction[1]);
            });

            return Run(instructions).acc;
        }

        public static async Task<int> Task2(string file)
        {
            var instructions = await LittleHelper.Parse(file, "\n", l =>
            {
                var instruction = l.Split(' ');
                return (instruction[0], instruction[1]);
            });

            for (var i = 0; i < instructions.Length; i++)
            {
                var copy = instructions.Select(t => t).ToArray();

                switch (copy[i].Item1)
                {
                    case "jmp":
                    {
                        copy[i].Item1 = "nop";
                        break;
                    }
                    case "nop":
                    {
                        copy[i].Item1 = "jmp";
                        break;
                    }
                }

                var (end, acc) = Run(copy);
                if (end)
                {
                    return acc;
                }
            }

            return -1;
        }

        private static (bool end, int acc) Run((string, string)[] instructions)
        {
            var acc = 0;
            var visited = new HashSet<int>();
            for (var i = 0; i < instructions.Length; i++)
            {
                if (visited.Contains(i))
                {
                    return (false, acc);
                }

                visited.Add(i);
                var (op, arg) = instructions[i];

                if (op == "acc")
                {
                    acc += int.Parse(arg);
                }

                if (op == "jmp")
                {
                    i += int.Parse(arg) - 1;
                }
            }

            return (true, acc);
        }
    }
}