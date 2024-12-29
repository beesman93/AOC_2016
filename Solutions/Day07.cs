using AoCHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC_2016.Solutions
{
    internal class Day07 : BaseDayWithInput
    {

        public Day07()
        {
            
        }

        bool HasABBAoutsideBrackets(string s)
        {
            bool hasInnerABBA = false;
            bool inBrackets = false;
            for (int i =0;i< s.Length - 3; i++)
            {
                if (s[i] == '[') inBrackets = true;
                if (s[i] == ']') inBrackets = false;
                var span = s.AsSpan(i, 4);
                if (span[0] == span[3] && span[1] == span[2] && span[0] != span[1])
                {
                    if (inBrackets)
                        return false;
                    hasInnerABBA = true;
                }
            }
            return hasInnerABBA;
        }

        bool HasABA(string s)
        {
            HashSet<string> supernetPairs = [];
            HashSet<string> hypernetPairs = [];
            bool inBrackets = false;
            for (int i = 0; i < s.Length - 2; i++)
            {
                if (s[i] == '[') inBrackets = true;
                if (s[i] == ']') inBrackets = false;
                var span = s.AsSpan(i, 3);
                if (span[0] == span[2] && span[0] != span[1])
                {
                    if (inBrackets)
                    {
                        if (hypernetPairs.Contains(span[..2].ToString())) return true;
                        supernetPairs.Add(span[..2].ToString());
                    }
                    else
                    {
                        if (supernetPairs.Contains(span[1..].ToString())) return true;
                        hypernetPairs.Add(span[1..].ToString());
                    }
                }
            }
            return false;
        }
        public override ValueTask<string> Solve_1() => new($"{_input.Count(HasABBAoutsideBrackets)}");

        public override ValueTask<string> Solve_2() => new($"{_input.Count(HasABA)}");
    }
}
