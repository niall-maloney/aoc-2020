using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Advent.Tasks
{
    public static class LittleHelper
    {
        public static async Task<T[]> Parse<T>(string file, Func<string, T> parser)
        {
            var input = await File.ReadAllLinesAsync(file);
            return input.Select(parser).ToArray();
        }
    }
}
