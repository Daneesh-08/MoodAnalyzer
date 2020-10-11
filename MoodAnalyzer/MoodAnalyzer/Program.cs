using System;

namespace MoodAnalyzer
{
    public class Program
    {
        static void Main(string[] args)
        {
            string mood = "I am Happy";
            Console.WriteLine("Input : " + mood);
            MoodAnalyze moodAnalyze = new MoodAnalyze(mood);
            System.Console.WriteLine(moodAnalyze.AnalyzeMood());
        }
    }
}
