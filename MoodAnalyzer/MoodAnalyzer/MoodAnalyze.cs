using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalyzer
{
    public class MoodAnalyze
    {
        private string message;
        public MoodAnalyze()
        {
        }
        public MoodAnalyze(string message)
        {
            this.message = message;
        }
        public string AnalyzeMood(string message)
        {
            try
            {
                if (message.Equals(string.Empty))
                    throw new MoodAnalyzeException(MoodAnalyzeException.ExceptionType.EMPTY_MESSAGE, "Mood should not be empty");
                if (message.Contains("Sad"))
                    return "SAD";
                else
                    return "HAPPY";
            }
            catch (NullReferenceException)
            {
                throw new MoodAnalyzeException(MoodAnalyzeException.ExceptionType.NULL_MESSAGE, "Mood should not be null");
            }
        }
        public string AnalyzeMood()
        {
            try
            {
                if (this.message.Equals(string.Empty))
                    throw new MoodAnalyzeException(MoodAnalyzeException.ExceptionType.EMPTY_MESSAGE, "Mood should not be empty");
                if (this.message.Contains("Sad"))
                    return "SAD";
                else
                    return "HAPPY";
            }
            catch (NullReferenceException)
            {
                throw new MoodAnalyzeException(MoodAnalyzeException.ExceptionType.NULL_MESSAGE, "Mood should not be null");
            }
        }
    }
}
