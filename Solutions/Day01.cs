using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AoCHelper;

namespace AOC_2016.Solutions
{
    internal class Day01 : BaseDayWithInput
    {
        readonly (int x, int y)[] directions = new (int x, int y)[] { (0, 1), (1, 0), (0, -1), (-1, 0) };//N,E,S,W
        static int TurnRight(int dir) => (dir + 1) % 4;
        static int TurnLeft(int dir) => (dir + 3) % 4;
        public Day01()
        {

        }
        public override ValueTask<string> Solve_1()
        {
            int dir = 0;//N
            (int x, int y) pos = (0, 0);
            foreach (var instruction in _input[0].Split(", "))
            {
                dir = instruction[0] switch
                {
                    'R' => TurnRight(dir),
                    'L' => TurnLeft(dir),
                    _ => throw new Exception()
                };
                pos.x += directions[dir].x * int.Parse(instruction[1..]);
                pos.y += directions[dir].y * int.Parse(instruction[1..]);
            }
            return new($"{pos.x+pos.y}");
        }
        public override ValueTask<string> Solve_2()
        {
            int dir = 0;//N
            (int x, int y) pos = (0, 0);
            HashSet<(int x, int y)> visited = [(0,0)];
            foreach (var instruction in _input[0].Split(", "))
            {

                dir = instruction[0] switch
                {
                    'R' => TurnRight(dir),
                    'L' => TurnLeft(dir),
                    _ => throw new Exception()
                };
                for (int i = 0; i < int.Parse(instruction[1..]); i++)
                {
                    pos.x += directions[dir].x;
                    pos.y += directions[dir].y;
                    if (!visited.Add(pos))
                        return new($"{pos.x + pos.y}");
                }

            }
            return new($"{pos.x + pos.y}");
        }
    }
}
