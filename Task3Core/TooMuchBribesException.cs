using System;

namespace Task3Core
{
    public class TooMuchBribesException : Exception
    {
        public TooMuchBribesException()
        {
        }

        public TooMuchBribesException(string message) : base(message)
        {
        }
    }
}