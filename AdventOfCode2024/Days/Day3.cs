using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2024.Days
{
    internal class Day3
    {
        public static void Day3P2()
        {
            var content = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "Inputs", "day3-input.txt"));
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
            var content = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "Inputs", "day3-input.txt"));
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
    }
}
