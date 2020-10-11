using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalyzer
{
    public class MoodAnalyzeException : Exception
    {
        public enum ExceptionType
        {
            NULL_MESSAGE, EMPTY_MESSAGE
        }
        private readonly ExceptionType type;
        public MoodAnalyzeException(ExceptionType type, string message) : base(message)
        {
            this.type = type;
        }
    }
}
