using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Advent.Tasks
{
    public static class LittleHelper
    {
        public static async Task<T[]> Parse<T>(string file, string separator, Func<string, T> parser)
        {
            var input = await File.ReadAllTextAsync(file);
            var lines = input.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            return lines.Select(parser).ToArray();
        }
    }
}
