using Polly;
using Polly.Retry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2024.Policies
{
    internal class ClientPolicy
    {
        public AsyncRetryPolicy<HttpResponseMessage> ExponentialHttpRetry { get; }
        public AsyncRetryPolicy<HttpResponseMessage> ImmediateHttpRetry { get; }

        public ClientPolicy()
        {
            ExponentialHttpRetry = Policy.HandleResult<HttpResponseMessage>(
                res => !res.IsSuccessStatusCode)
                .WaitAndRetryAsync(5, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));
            ImmediateHttpRetry = Policy.HandleResult<HttpResponseMessage>(
               res => !res.IsSuccessStatusCode)
               .RetryAsync(10);
        }
    }
}
