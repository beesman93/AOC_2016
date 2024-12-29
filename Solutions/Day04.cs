using AoCHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC_2016.Solutions
{
    internal class Day04: BaseDayWithInput
    {
        struct Room(string name, int sectorId)
        {
            public Room(string nameWithSecotorId) : this(
                String.Join('-',nameWithSecotorId.Split('-').SkipLast(1)),
                int.Parse(nameWithSecotorId.Split('-').Last())
                )
            { }

            public string name = name;
            public int sectorId = sectorId;
            public string checkSum = String.Concat(
                name.Where(c => c != '-')
                .CountBy(c => c)
                .OrderByDescending(charCount => charCount.Value)//sort by count
                .ThenBy(charCount => charCount.Key)//sort by letter
                .Take(5)//get top 5
                .Select(charCount => charCount.Key)//only letters
                );
            public string DecryptName()
            {
                var sid = sectorId % 26;
                return String.Concat(
                    name.Select(c => c == '-' ? ' ' 
                    : (char)(((c - 'a' + sid) % 26) + 'a')));
            }
        }
        public Day04()
        {
        }
        public override ValueTask<string> Solve_1()
        {
            long ans = 0;
            foreach (var line in _input)
            {
                var parts = line.Split('[');
                var room = new Room(parts.First());
                var check = parts.Last().TrimEnd(']');
                if (room.checkSum == check)
                {
                    ans += room.sectorId;
                }
            }
            return new($"{ans}");
        }
        public override ValueTask<string> Solve_2()
        {
            long ans = 0;
            foreach(var line in _input)
            {
                var parts = line.Split('[');
                var room = new Room(parts.First());
                var check = parts.Last().TrimEnd(']');
                if (room.checkSum == check)
                {
                    var name = room.DecryptName();
                    if (name.Contains("northpole"))
                        return new($"{room.sectorId}");
                }
            }
            throw new Exception("Not found");
        }
    }
}
