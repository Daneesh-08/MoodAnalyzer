using System;

namespace MoodAnalyzer
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string mood = string.Empty;
                MoodAnalyze moodAnalyser = new MoodAnalyze(mood);
                string result = moodAnalyser.AnalyzeMood();
                Console.WriteLine(result);
            }
            catch (MoodAnalyzeException m)
            {
                Console.WriteLine(m.Message);
            }
        }
    }
}
