using AoCHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC_2016.Solutions
{
    internal class Day06 : BaseDayWithInput
    {
        readonly int N;
        readonly int[][] frequency;
        public Day06() 
        {
            N = _input[0].Length;
            frequency = new int[N][];
            for (int i = 0; i < N; i++)
                frequency[i] = new int[26];
            foreach (var line in _input)
            {
                for (int i = 0; i < N; i++)
                    frequency[i][line[i] - 'a']++;
            }
        }
        public override ValueTask<string> Solve_1()
        {
            StringBuilder sb = new();
            for (int i = 0; i < N; i++)
                sb.Append((char)('a' + Array.IndexOf(frequency[i], frequency[i].Max())));
            return new(sb.ToString());
        }

        public override ValueTask<string> Solve_2()
        {
            StringBuilder sb = new();
            for (int i = 0; i < N; i++)
                sb.Append((char)('a' + Array.IndexOf(frequency[i], frequency[i].Min())));
            return new(sb.ToString());
        }
    }
}
