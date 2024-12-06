using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2024.Days
{
    internal class Day2
    {
        public static void Day2Part2()
        {
            var lines = File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "Inputs", "day2-input.txt"));

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

        private static bool CheckDay2Report(List<int> report)
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
            var lines = File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "Inputs", "day2-input.txt"));

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
    }
}
