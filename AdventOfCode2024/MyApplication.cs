using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2024
{
    internal class MyApplication
    {
        private readonly ILogger<MyApplication> _logger;

        public MyApplication(ILogger<MyApplication> logger)
        {
            _logger = logger;
        }

        public async Task RunProgram()
        {
            _logger.LogInformation("Running Program");
            var list1 = new List<int>();
            var list2 = new List<int>();

            var lines = File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "day1-input.txt"));

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

        public async Task Day1Part2()
        {
            _logger.LogInformation("Running Program");
            var list1 = new List<int>();
            var list2 = new List<int>();

            var lines = File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "day1-input.txt"));

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

        public async Task Day1Part1()
        {
            _logger.LogInformation("Running Program");
            var list1 = new List<int>();
            var list2 = new List<int>();

            var lines = File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "day1-input.txt"));

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
