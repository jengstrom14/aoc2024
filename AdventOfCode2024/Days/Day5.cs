using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2024.Days
{
    internal class Day5
    {
        public static void Day5P2()
        {
            var lines = File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "Inputs", "day5.input"));
            var earlierThan = new Dictionary<int, List<int>>();
            var laterThan = new Dictionary<int, List<int>>();
            var secondPart = false;
            var pageSets = new List<List<int>>();
            foreach (var line in lines)
            {
                if (line.Equals(string.Empty))
                {
                    secondPart = true;
                    continue;
                }

                if (!secondPart)
                {
                    var splitLine = line.Split('|');
                    var left = int.Parse(splitLine[0]);
                    var right = int.Parse(splitLine[1]);
                    if (!laterThan.TryGetValue(right, out var earlierList))
                    {
                        laterThan[right] = [];
                        earlierList = laterThan[right];
                    }
                    earlierList.Add(left);
                    if (!earlierThan.TryGetValue(left, out var laterList))
                    {
                        earlierThan[left] = [];
                        laterList = earlierThan[left];
                    }
                    laterList.Add(right);
                }
                else
                {
                    var pageSet = new List<int>();
                    var splitLine = line.Split(',');
                    foreach(var pageNum in splitLine)
                    {
                        pageSet.Add(int.Parse(pageNum));
                    }
                    pageSets.Add(pageSet);
                }
            }
            var middleValueSum = 0;
            foreach (var pageSet in pageSets)
            {
                if (InOrder(laterThan, pageSet))
                {
                    continue;
                }

                //var sorted = Resort(pageSet, earlierThan);
                middleValueSum += pageSet[(pageSet.Count / 2)];
            }
            Console.WriteLine(middleValueSum);
        }

        //private List<int> Resort(List<int> pageSet, Dictionary<int,List<int>> earlierRules)
        //{
        //    //get first page
        //    var page = pageSet[0];
            
        //}

        public static void Day5P1()
        {
            var lines = File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "Inputs", "day5.input"));
            var earlierThan = new Dictionary<int, List<int>>();
            //var laterThan = new Dictionary<int, List<int>>();
            var secondPart = false;
            var pageSets = new List<List<int>>();
            foreach (var line in lines)
            {
                if (line.Equals(string.Empty))
                {
                    secondPart = true;
                    continue;
                }

                if (!secondPart)
                {
                    var splitLine = line.Split('|');
                    var left = int.Parse(splitLine[0]);
                    var right = int.Parse(splitLine[1]);
                    //if (!laterThan.TryGetValue(right, out var earlierList))
                    //{
                    //    laterThan[right] = [];
                    //    earlierList = laterThan[right];
                    //}
                    //earlierList.Add(left);
                    if (!earlierThan.TryGetValue(left, out var laterList))
                    {
                        earlierThan[left] = [];
                        laterList = earlierThan[left];
                    }
                    laterList.Add(right);
                }
                else
                {
                    var pageSet = new List<int>();
                    var splitLine = line.Split(',');
                    foreach(var pageNum in splitLine)
                    {
                        pageSet.Add(int.Parse(pageNum));
                    }
                    pageSets.Add(pageSet);
                }
            }
            var middleValueSum = 0;
            foreach (var pageSet in pageSets)
            {
                if (!InOrder(earlierThan, pageSet))
                {
                    continue;
                }

                middleValueSum += pageSet[(pageSet.Count / 2)];
            }
            Console.WriteLine(middleValueSum);
        }

        private static bool InOrder(Dictionary<int, List<int>> earlierThanRules, List<int> pageSetToCheck)
        {
            var pageSet = pageSetToCheck.ToList();
            pageSet.Reverse();
            var unallowedFurtherPages = new List<int>();
            foreach (var page in pageSet)
            {
                if (unallowedFurtherPages.Contains(page))
                {
                    return false;
                }

                if (!earlierThanRules.TryGetValue(page, out var pageNumsThatAreNotAllowedAfter))
                {
                    continue;
                }
                unallowedFurtherPages.AddRange(pageNumsThatAreNotAllowedAfter);
            }
            return true;
        }
    }
}
