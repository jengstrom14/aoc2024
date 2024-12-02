using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
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
        }
    }
}
