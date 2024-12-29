using AoCHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC_2016.Solutions
{
    internal class Day02 : BaseDayWithInput
    {

        public Day02()
        {

        }

        static readonly int[,] keypad = new int[3, 3] { 
            { 1, 2, 3 }, 
            { 4, 5, 6 }, 
            { 7, 8, 9 }
        };

        static (int row, int col) Move((int row, int col) pos, char dir) => dir switch
        {
            'U' => pos.row > 0 ? (pos.row - 1, pos.col) : pos,
            'D' => pos.row < 2 ? (pos.row + 1, pos.col) : pos,
            'L' => pos.col > 0 ? (pos.row, pos.col - 1) : pos,
            'R' => pos.col < 2 ? (pos.row, pos.col + 1) : pos,
            _ => pos
        };
        public override ValueTask<string> Solve_1()
        {
            string ans = "";
            (int row, int col) pos = (1, 1);//start at 5
            foreach(var line in _input)
            {
                foreach (var dir in line)
                {
                    pos = Move(pos, dir);
                }
                ans += keypad[pos.row, pos.col];
            }
            return new(ans);
        }

        static readonly char[,] keypad2 = new char[5, 5] {
            { ' ', ' ', '1', ' ', ' ' },
            { ' ', '2', '3', '4', ' ' },
            { '5', '6', '7', '8', '9' },
            { ' ', 'A', 'B', 'C', ' ' },
            { ' ', ' ', 'D', ' ', ' ' }
        };
        static (int row, int col) Move2((int row, int col) pos, char dir) => dir switch
        {
            'U' => pos.row > 0 && keypad2[pos.row - 1, pos.col] != ' ' ? (pos.row - 1, pos.col) : pos,
            'D' => pos.row < 4 && keypad2[pos.row + 1, pos.col] != ' ' ? (pos.row + 1, pos.col) : pos,
            'L' => pos.col > 0 && keypad2[pos.row, pos.col - 1] != ' ' ? (pos.row, pos.col - 1) : pos,
            'R' => pos.col < 4 && keypad2[pos.row, pos.col + 1] != ' ' ? (pos.row, pos.col + 1) : pos,
            _ => pos
        };

        public override ValueTask<string> Solve_2()
        {
            string ans = "";
            (int row, int col) pos = (2, 0);//start at 5
            foreach (var line in _input)
            {
                foreach (var dir in line)
                {
                    pos = Move2(pos, dir);
                }
                ans += keypad2[pos.row, pos.col];
            }
            return new(ans);
        }
    }
}
