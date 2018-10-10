﻿using Xunit;
using Xunit.Sdk;

namespace Xunit
{
    /// <summary>
    /// Works just like [Fact] except that failures are retried (by default, 3 times).
    /// </summary>
    [XunitTestCaseDiscoverer("Xunit.RetryFactDiscoverer", "XunitRetry")]
    public class RetryAttribute : FactAttribute
    { 
        public RetryAttribute(int maxRetries = 3, int exponentialBackoffMs = 1000)
        {
            MaxRetries = maxRetries;
            ExponentialBackoffMs = exponentialBackoffMs;
        }

        /// <summary>
        /// Number of retries allowed for a failed test. If unset (or set less than 1), will
        /// default to 3 attempts.
        /// </summary>
        public int MaxRetries { get; set; }

        /// <summary>
        /// https://en.wikipedia.org/wiki/Exponential_backoff
        /// </summary>
        public int ExponentialBackoffMs { get; set; }
    }
}
