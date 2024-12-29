using AoCHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC_2016.Solutions
{
    internal class Day03 : BaseDayWithInput
    {
        struct Triangle(int a, int b, int c)
        {
            public int a = a, b = b, c = c;
            public readonly bool IsValid()
            {
                return a + b > c && a + c > b && b + c > a;
            }
        }
        public Day03()
        {
        }

        public override ValueTask<string> Solve_1()
        {
            List<Triangle> triangles = [];
            foreach (var line in _input)
            {
                var sides = line.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                triangles.Add(new Triangle(sides[0], sides[1], sides[2]));
            }
            return new($"{triangles.Count(t => t.IsValid())}");
        }
        public override ValueTask<string> Solve_2()
        {
            List<Triangle> triangles = [];
            for(int i=0; i < _input.Length; i += 3)
            {
                var sides1 = _input[i    ].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                var sides2 = _input[i + 1].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                var sides3 = _input[i + 2].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                triangles.Add(new Triangle(sides1[0], sides2[0], sides3[0]));
                triangles.Add(new Triangle(sides1[1], sides2[1], sides3[1]));
                triangles.Add(new Triangle(sides1[2], sides2[2], sides3[2]));
            }
            return new($"{triangles.Count(t => t.IsValid())}");
        }
    }
}
