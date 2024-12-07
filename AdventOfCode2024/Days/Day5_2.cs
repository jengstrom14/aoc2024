using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2024.Days
{
    internal class Day5_2
    {
        public static void Day5()
        {
            var lines = File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "Inputs", "day5.input"));

            var rules = lines
                .TakeWhile(l => l.Contains('|'))
                .Select(line => line.Split("|"))
                .Select(numbers => (First: int.Parse(numbers[0]), Second: int.Parse(numbers[1])));

            var updatesStr = lines
                .SkipWhile(l => l.Contains('|'))
                .Select(line => line.Split(','));
            var updates = new List<int[]>();
            foreach (var numStr in updatesStr)
            {
                if (numStr[0] == string.Empty)
                {
                    continue;
                }
                var temp = new List<int>();
                temp.AddRange(numStr.Select(int.Parse));
                updates.Add([.. temp]);
            }

            var dependentOn = new Dictionary<int, HashSet<int>>();
            foreach (var (former, latter) in rules)
            {
                if (!dependentOn.TryGetValue(latter, out HashSet<int>? deps))
                {
                    deps = [];
                    dependentOn[latter] = deps;
                }

                deps.Add(former);
            }

            Console.WriteLine($"Part 1: {GetMiddlePage(false, dependentOn, updates)}");
            Console.WriteLine($"Part 2: {GetMiddlePage(true, dependentOn, updates)}");
        }
        static int GetMiddlePage(bool takeIncorrectlyReordered, Dictionary<int, HashSet<int>> rules, IEnumerable<int[]> updates)
        {
            var result = 0;
            foreach (var update in updates)
            {
                var isCorrect = true;
                for (int i = 0; i < update.Length; i++)
                {
                Again:
                    var shouldBeEarlier = rules[update[i]];
                    for (int j = i + 1; j < update.Length; ++j)
                    {
                        if (shouldBeEarlier.Contains(update[j]))
                        {
                            isCorrect = false;
                            if (takeIncorrectlyReordered)
                            {
                                (update[i], update[j]) = (update[j], update[i]);
                                i = 0;
                                goto Again;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }

                    if (!takeIncorrectlyReordered && !isCorrect)
                    {
                        break;
                    }
                }

                if (takeIncorrectlyReordered != isCorrect)
                {
                    result += update[update.Length / 2];
                }
            }

            return result;
        }
    }
}
