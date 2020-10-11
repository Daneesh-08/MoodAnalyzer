using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyzer;
namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Arrange
            MoodAnalyze moodAnalyze = new MoodAnalyze();
            //Act
            var result = moodAnalyze.AnalyzeMood("I am in Sad Mood");
            //Assert
            Assert.AreEqual("SAD", result);
        }
        [TestMethod]
        public void TestMethod2()
        {
            //Arrange
            MoodAnalyze moodAnalyze = new MoodAnalyze();
            //Act
            var result = moodAnalyze.AnalyzeMood("I am in Happy Mood");
            //Assert
            Assert.AreEqual("HAPPY", result);
        }
        [TestMethod]
        [DataRow("I am in Sad Mood")]
        public void TestMethod3(string message)
        {
            //Arrange
            MoodAnalyze moodAnalyze = new MoodAnalyze(message);
            //Act
            var result = moodAnalyze.AnalyzeMood();
            //Assert
            Assert.AreEqual("SAD", result);
        }
        [TestMethod]
        [DataRow("I am in Happy Mood")]
        public void TestMethod4(string message)
        {
            //Arrange
            MoodAnalyze moodAnalyze = new MoodAnalyze(message);
            //Act
            var result = moodAnalyze.AnalyzeMood();
            //Assert
            Assert.AreEqual("HAPPY", result);
        }
    }
}