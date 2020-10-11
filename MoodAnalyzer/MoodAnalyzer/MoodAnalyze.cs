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
            if (message.Contains("Sad"))
                return "SAD";
            else
                return "HAPPY";
        }
        public string AnalyzeMood()
        {
            if (this.message.Contains("Sad"))
                return "SAD";
            else
                return "HAPPY";
        }
    }
}
