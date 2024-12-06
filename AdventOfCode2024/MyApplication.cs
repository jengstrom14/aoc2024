using AdventOfCode2024.Days;
using Microsoft.Extensions.Configuration.CommandLine;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection.Metadata.Ecma335;
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

        public void RunProgram()
        {
            _logger.LogInformation("Running Program");
            Day6.Day6P1();
            Day6.Day6P2();
        }
    }
}
