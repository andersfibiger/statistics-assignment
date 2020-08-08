using System;

namespace Statistics.Common
{
    public class StatisticException : Exception
    {
        public int StatusCode { get; }

        public StatisticException(string message, int statusCode) : base(message)
        {
            StatusCode = statusCode;
        }
    }
}
