using System;

namespace MoodAnalyzer
{
    public class Program
    {
        static void Main(string[] args)
        {
            //string mood = "I am Happy";
            //Console.WriteLine("Input : " + mood);
            //MoodAnalyze moodAnalyze = new MoodAnalyze(mood);
            //System.Console.WriteLine(moodAnalyze.AnalyzeMood());
            try
            {
                Console.WriteLine("Input : ");
                string mood = Console.ReadLine();
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
