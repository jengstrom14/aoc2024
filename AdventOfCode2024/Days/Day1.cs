using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2024.Days
{
    internal class Day1
    {
        public static void Day1Part2()
        {
            var list1 = new List<int>();
            var list2 = new List<int>();

            var lines = File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "Inputs", "day1.input"));

            foreach (var line in lines)
            {
                var split = line.Split();
                list1.Add(int.Parse(split[0]));
                list2.Add(int.Parse(split[3]));
            }
            list1.Sort();
            list2.Sort();

            var simscoreByNum = new Dictionary<int, int>();
            int totalSimScore = 0;

            foreach (var number in list1)
            {
                if (simscoreByNum.TryGetValue(number, out var simScore))
                {
                    totalSimScore += simScore;
                    continue;
                }
                var count = list2.Where(x => x == number).Count();
                simScore = number * count;
                simscoreByNum[number] = simScore;
                totalSimScore += simScore;
            }

            Console.WriteLine(totalSimScore);
        }

        public static void Day1Part1()
        {
            var list1 = new List<int>();
            var list2 = new List<int>();

            var lines = File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "Inputs", "day1.input"));

            foreach (var line in lines)
            {
                var split = line.Split();
                list1.Add(int.Parse(split[0]));
                list2.Add(int.Parse(split[3]));
            }
            list1.Sort();
            list2.Sort();

            var totalDiff = 0;

            for(int i = 0; i < list1.Count; i++)
            {
                var difference = Math.Abs(list1[i] - list2[i]);
                totalDiff += difference;
            }

            Console.WriteLine(totalDiff);
        }
    }
}
