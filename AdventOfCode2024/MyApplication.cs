using AdventOfCode2024.Days;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2024
{
    internal class MyApplication
    {
        private readonly ILogger<MyApplication> _logger;

        public MyApplication(ILogger<MyApplication> logger)
        {
            _logger = logger;
        }

        public void RunProgram()
        {
            _logger.LogInformation("Running Program");

            //Console.WriteLine("day 1");
            //Console.WriteLine("part 1");
            //Day1.Day1Part1();
            //Console.WriteLine("part 2");
            //Day1.Day1Part2();
            //Console.WriteLine();

            //Console.WriteLine("day 2");
            //Console.WriteLine("part 1");
            //Day2.Day2Part1();
            //Console.WriteLine("part 2");
            //Day2.Day2Part2();
            //Console.WriteLine();

            //Console.WriteLine("day 3");
            //Console.WriteLine("part 1");
            //Day3.Day3P1();
            //Console.WriteLine("part 2");
            //Day3.Day3P2();
            //Console.WriteLine();

            //Console.WriteLine("day 4");
            //Console.WriteLine("part 1");
            //Day4.Day4P1();
            //Console.WriteLine("part 2");
            //Day4.Day4P2();
            //Console.WriteLine();

            //Console.WriteLine("day 5");
            //Console.WriteLine("part 1");
            //Day5.Day5P1();
            //Console.WriteLine("part 2");
            //Day5.Day5P2();
            //Console.WriteLine();

            Console.WriteLine("day 5");
            Day5_2.Day5();
            Console.WriteLine();

            Console.WriteLine("day 6");
            Console.WriteLine("part 1");
            Day6.Day6P1();
            Console.WriteLine("part 2");
            Day6.Day6P2();
            Console.WriteLine();
        }
    }
}
