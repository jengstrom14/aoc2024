using Microsoft.Extensions.Configuration.CommandLine;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
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
            var lines = File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "day4-input.txt"));

            var total = 0;
            var rowCount = lines.Length;
            var colCount = lines[0].Length;

            for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < colCount; columnIndex++)
                {
                    var charToCheck = lines[rowIndex][columnIndex];
                    if (charToCheck != 'M' && charToCheck != 'S')
                    {
                        continue;
                    }

                    if (rowIndex <= rowCount - 3 && columnIndex <= colCount - 3)
                    {
                        if (lines[rowIndex + 1][columnIndex + 1] == 'A' &&

                            ((lines[rowIndex][columnIndex] == 'M' && lines[rowIndex + 2][columnIndex + 2] == 'S') ||
                            (lines[rowIndex][columnIndex] == 'S' && lines[rowIndex + 2][columnIndex + 2] == 'M')) &&

                            ((lines[rowIndex][columnIndex + 2] == 'M' && lines[rowIndex + 2][columnIndex] == 'S') ||
                            (lines[rowIndex][columnIndex + 2] == 'S' && lines[rowIndex + 2][columnIndex] == 'M')))
                        {
                            total++;
                        }
                    }
                }
            }

            Console.WriteLine(total);
        }

        public async Task Day4P2()
        {
            _logger.LogInformation("Running Program");
            var lines = File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "day4-input.txt"));

            var total = 0;
            var rowCount = lines.Length;
            var colCount = lines[0].Length;

            for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < colCount; columnIndex++)
                {
                    var charToCheck = lines[rowIndex][columnIndex];
                    if (charToCheck != 'M' && charToCheck != 'S')
                    {
                        continue;
                    }

                    if (rowIndex <= rowCount - 3 && columnIndex <= colCount - 3)
                    {
                        if (lines[rowIndex + 1][columnIndex + 1] == 'A' &&

                            ((lines[rowIndex][columnIndex] == 'M' && lines[rowIndex + 2][columnIndex + 2] == 'S') ||
                            (lines[rowIndex][columnIndex] == 'S' && lines[rowIndex + 2][columnIndex + 2] == 'M')) &&

                            ((lines[rowIndex][columnIndex + 2] == 'M' && lines[rowIndex + 2][columnIndex] == 'S') ||
                            (lines[rowIndex][columnIndex + 2] == 'S' && lines[rowIndex + 2][columnIndex] == 'M')))
                        {
                            total++;
                        }
                    }
                }
            }

            Console.WriteLine(total);
        }
        
        public async Task Day4P1()
        {
            _logger.LogInformation("Running Program");
            var lines = File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "day4-input.txt"));

            var total = 0;
            var rowCount = lines.Length;
            var colCount = lines[0].Length;

            for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < colCount; columnIndex++)
                {
                    var charToCheck = lines[rowIndex][columnIndex];
                    if (charToCheck != 'X')
                    {
                        continue;
                    }

                    //check in the following order
                    //W, NW, N, NE, E, SE, S, SW

                    //W
                    if (columnIndex >= 3)
                    {
                        if ($"{lines[rowIndex][columnIndex]}{lines[rowIndex][columnIndex - 1]}{lines[rowIndex][columnIndex - 2]}{lines[rowIndex][columnIndex - 3]}" == "XMAS")
                        {
                            total++;
                        }
                    }

                    //NW
                    if (rowIndex >= 3 && columnIndex >= 3)
                    {
                        if ($"{lines[rowIndex][columnIndex]}{lines[rowIndex - 1][columnIndex - 1]}{lines[rowIndex - 2][columnIndex - 2]}{lines[rowIndex - 3][columnIndex - 3]}" == "XMAS")
                        {
                            total++;
                        }
                    }

                    //N
                    if (rowIndex >= 3)
                    {
                        if ($"{lines[rowIndex][columnIndex]}{lines[rowIndex - 1][columnIndex]}{lines[rowIndex - 2][columnIndex]}{lines[rowIndex - 3][columnIndex]}" == "XMAS")
                        {
                            total++;
                        }
                    }

                    //NE
                    if (rowIndex >= 3 && columnIndex <= colCount - 4)
                    {
                        if ($"{lines[rowIndex][columnIndex]}{lines[rowIndex - 1][columnIndex + 1]}{lines[rowIndex - 2][columnIndex + 2]}{lines[rowIndex - 3][columnIndex + 3]}" == "XMAS")
                        {
                            total++;
                        }
                    }

                    //E
                    if (columnIndex <= colCount - 4)
                    {
                        if ($"{lines[rowIndex][columnIndex]}{lines[rowIndex][columnIndex + 1]}{lines[rowIndex][columnIndex + 2]}{lines[rowIndex][columnIndex + 3]}" == "XMAS")
                        {
                            total++;
                        }
                    }

                    //SE
                    if (rowIndex <= rowCount - 4 && columnIndex <= colCount - 4)
                    {
                        if ($"{lines[rowIndex][columnIndex]}{lines[rowIndex + 1][columnIndex + 1]}{lines[rowIndex + 2][columnIndex + 2]}{lines[rowIndex + 3][columnIndex + 3]}" == "XMAS")
                        {
                            total++;
                        }
                    }

                    //S
                    if (rowIndex <= rowCount - 4)
                    {
                        if ($"{lines[rowIndex][columnIndex]}{lines[rowIndex + 1][columnIndex]}{lines[rowIndex + 2][columnIndex]}{lines[rowIndex + 3][columnIndex]}" == "XMAS")
                        {
                            total++;
                        }
                    }

                    //SW
                    if (rowIndex <= rowCount - 4 && columnIndex >= 3)
                    {
                        if ($"{lines[rowIndex][columnIndex]}{lines[rowIndex + 1][columnIndex - 1]}{lines[rowIndex + 2][columnIndex - 2]}{lines[rowIndex + 3][columnIndex - 3]}" == "XMAS")
                        {
                            total++;
                        }
                    }
                }
            }

            Console.WriteLine(total);
        }

        public async Task Day3P2()
        {
            _logger.LogInformation("Running Program");

            var content = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "day3-input.txt"));
            var total = 0;
            bool enabled = true;

            Regex regex = new Regex(@"mul\((\d{1,3}),(\d{1,3})\)|do\(\)|don\'t\(\)");

            var matches = regex.Matches(content);

            foreach (Match match in matches)
            {
                switch (match.Value)
                {
                    case "do()":
                        enabled = true;
                        break;
                    case "don't()":
                        enabled = false;
                        break;
                    default:
                        if (enabled)
                        {
                            var firstNum = int.Parse(match.Groups[1].Value);
                            var secondNum = int.Parse(match.Groups[2].Value);
                            total += firstNum * secondNum;
                        }
                        break;
                }
            }

            Console.WriteLine(total);
        }

        public async Task Day3P1()
        {
            _logger.LogInformation("Running Program");

            var content = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "day3-input.txt"));
            var total = 0;

            Regex regex = new Regex(@"mul\((\d{1,3}),(\d{1,3})\)");

            var matches = regex.Matches(content);
            foreach (Match match in matches)
            {
                var firstNum = int.Parse(match.Groups[1].Value);
                var secondNum = int.Parse(match.Groups[2].Value);
                total += firstNum * secondNum;
            }

            Console.WriteLine(total);
        }

        public async Task Day2Part2()
        {
            _logger.LogInformation("Running Program");

            var lines = File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "day2-input.txt"));

            var reports = new List<List<int>>();
            foreach (var line in lines)
            {
                var split = line.Split();
                var report = new List<int>();
                foreach (var item in split)
                {
                    report.Add(int.Parse(item));
                }
                reports.Add(report);
            }
            var safeReportCount = 0;

            foreach (var report in reports)
            {
                for (int i = 0; i < report.Count; i++)
                {
                    var copyList = report.ToList();
                    copyList.RemoveAt(i);
                    if (CheckDay2Report(copyList))
                    {
                        safeReportCount++;
                        break;
                    }
                }
            }

            Console.WriteLine(safeReportCount);
        }

        private bool CheckDay2Report(List<int> report)
        {
            var minchange = 1;
            var maxChange = 3;
            var asc = false;
            var desc = false;
            for (int i = 0; i < report.Count - 1; i++)
            {
                var difference = report[i] - report[i + 1];
                if (difference > 0)
                {
                    desc = true;
                }
                else if (difference < 0)
                {
                    asc = true;
                }
                else
                {
                    break;
                }
                var posDifference = Math.Abs(difference);
                if (posDifference < minchange || posDifference > maxChange)
                {
                    break;
                }
                if (asc && desc)
                {
                    break;
                }
                if (i == report.Count - 2)
                {
                    return true;
                }
            }
            return false;
        }

        public async Task Day2Part1()
        {
            _logger.LogInformation("Running Program");

            var lines = File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "day2-input.txt"));

            var reports = new List<List<int>>();
            foreach (var line in lines)
            {
                var split = line.Split();
                var report = new List<int>();
                foreach (var item in split)
                {
                    report.Add(int.Parse(item));
                }
                reports.Add(report);
            }
            var safeReportCount = 0;
            var minchange = 1;
            var maxChange = 3;

            foreach (var report in reports)
            {
                var asc = false;
                var desc = false;
                for (int i = 0; i < report.Count - 1; i++)
                {
                    var difference = report[i] - report[i + 1];
                    if (difference > 0)
                    {
                        desc = true;
                    }
                    else if (difference < 0)
                    {
                        asc = true;
                    }
                    else
                    {
                        break;
                    }
                    var posDifference = Math.Abs(difference);
                    if (posDifference < minchange || posDifference > maxChange)
                    {
                        break;
                    }
                    if (asc && desc)
                    {
                        break;
                    }
                    if (i == report.Count - 2)
                    {
                        safeReportCount++;
                    }
                }
            }
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
