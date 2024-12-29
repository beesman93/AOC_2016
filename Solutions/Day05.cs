using AoCHelper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AOC_2016.Solutions
{
    internal class Day05 : BaseDayWithInput
    {
        readonly string input;
        readonly int desiredPwdLen;
        string pwd1;
        readonly char[] pwd2;
        int pwd2Found = 0;
        int idxChecked = 0;
        public Day05()
        {
            input = _input[0];
            desiredPwdLen = 8;
            pwd1 = "";
            pwd2 = new char[desiredPwdLen];
        }
        string GeneratePwd(bool part2)
        {
            bool part1 = !part2;
            if (part1 && pwd1.Length == desiredPwdLen) return pwd1;
            if (part2 && pwd2Found == desiredPwdLen) return String.Concat(pwd2);
            while (!
                ((part1 && pwd1 is not null && pwd1.Length == desiredPwdLen)
                || (part2 && pwd2Found == desiredPwdLen)))
            {
                var hashData = MD5.HashData(Encoding.Default.GetBytes(input + idxChecked));
                if (hashData[0] == 0 && hashData[1] == 0 && hashData[2] < 0x10)
                {
                    if (pwd1 is not null && pwd1.Length < desiredPwdLen)
                    {
                        pwd1 += hashData[2].ToString("X2")[1];
                        if (pwd1.Length == desiredPwdLen && part1) return pwd1;
                    }
                    var pos = hashData[2] & 0x0f;
                    if (pos < desiredPwdLen && pwd2[pos] == 0)
                    {
                        pwd2[pos] = hashData[3].ToString("X2")[0];
                        pwd2Found++;
                        if (pwd2Found == desiredPwdLen && part2) return String.Concat(pwd2);
                    }
                }
                idxChecked++;
            }
            throw new UnreachableException();
        }
        public override ValueTask<string> Solve_1() => new(GeneratePwd(part2:false));

        public override ValueTask<string> Solve_2() => new(GeneratePwd(part2:true));
    }
}
