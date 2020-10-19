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
        [TestMethod]
        [DataRow(null)]
        public void TestMethod5(string message)
        {
            try
            {
                //Arrange
                MoodAnalyze moodAnalyze = new MoodAnalyze(message);
                //Act
                var result = moodAnalyze.AnalyzeMood();
            }
            catch (MoodAnalyzeException e)
            {
                //Assert
                Assert.AreEqual("Mood should not be null", e.Message);
            }
        }
        [TestMethod]
        [DataRow("")]
        public void TestMethod6(string message)
        {
            try
            {
                //Arrange
                MoodAnalyze moodAnalyze = new MoodAnalyze(message);
                //Act
                var result = moodAnalyze.AnalyzeMood();
            }
            catch (MoodAnalyzeException e)
            {
                //Assert
                Assert.AreEqual("Mood should not be empty", e.Message);
            }
        }
        [TestMethod]
        public void GivenMoodAnalyzeClassName_ShouldReturnMoodAnalyseObject()
        {
            //Arrange
            string message = null;
            object expected = new MoodAnalyze(message);
            //Act
            object obj = MoodAnalyserFactory.CreateMoodAnalyserObject("MoodAnalyzer.MoodAnalyze", "MoodAnalyze");
            //Assert
            expected.Equals(obj);
        }
        [TestMethod]
        public void GivenMoodAnalyzeImproperClassName_ShouldThrowMoodAnalysisException()
        {
            try
            {
                //Arrange
                string message = null;
                object expected = new MoodAnalyze(message);
                //Act
                object obj = MoodAnalyserFactory.CreateMoodAnalyserObject("MoodAnalyzer.ModAnalize", "ModAnalize");
            }
            catch (MoodAnalyzeException e)
            {
                //Assert
                Assert.AreEqual("class not found", e.Message);
            }
        }
        [TestMethod]
        public void GivenMoodAnalyzeImproperConstructorName_ShouldThrowMoodAnalysisException()
        {
            try
            {
                //Arrange
                string message = null;
                object expected = new MoodAnalyze(message);
                //Act
                object obj = MoodAnalyserFactory.CreateMoodAnalyserObject("MoodAnalyzer.MoodAnalyze", "ModAnalize");
            }
            catch (MoodAnalyzeException e)
            {
                //Assert
                Assert.AreEqual("constructor not found", e.Message);
            }
        }
        [TestMethod]
        public void GivenMoodAnalyzeClassName_ShouldReturnMoodAnalyseObjectUsingParametrisedConstructor()
        {

            //Arrange
            string message = null;
            object expected = new MoodAnalyze(message);
            //Act
            object obj = MoodAnalyserFactory.CreateMoodAnalyserObjectUsingParameterisedConstructor("MoodAnalyzer.MoodAnalyze", "MoodAnalyze", message);
            //Assert
            expected.Equals(obj);
        }

        [TestMethod]
        public void GivenMoodAnalyzeImproperClassName_ShouldThrowMoodAnalysisExceptionForParameterisedConstructor()
        {
            try
            {
                //Arrange
                string message = null;
                object expected = new MoodAnalyze(message);
                //Act
                object obj = MoodAnalyserFactory.CreateMoodAnalyserObjectUsingParameterisedConstructor("MoodAnalyzer.ModAnalize", "ModAnalize", message);
            }
            catch (MoodAnalyzeException e)
            {
                //Assert
                Assert.AreEqual("class not found", e.Message);
            }
        }
        [TestMethod]
        public void GivenMoodAnalyzeImproperConstructorName_ShouldThrowMoodAnalysisExceptionForParameterisedConstructor()
        {
            try
            {
                //Arrange
                string message = null;
                object expected = new MoodAnalyze(message);
                //Act
                object obj = MoodAnalyserFactory.CreateMoodAnalyserObjectUsingParameterisedConstructor("MoodAnalyzer.MoodAnalyze", "ModAnalize", message);
            }
            catch (MoodAnalyzeException e)
            {
                //Assert
                Assert.AreEqual("constructor not found", e.Message);
            }
        }
        [TestMethod]
        public void GivenHappyMessageUsingReflectionWhenProper_ShouldReturnHAPPY()
        {
            //Arrange
            string message = "HAPPY";
            string methodName = "AnalyzeMood";
            //Act
            string actual = MoodAnalyserFactory.InvokeAnalyseMood(message, methodName);
            //Assert
            Assert.AreEqual("HAPPY", actual);
        }
        [TestMethod]
        public void GivenImproperMethodName_ShouldThrowMoodAnalysisException()
        {
            try
            {
                //Act
                string actual = MoodAnalyserFactory.InvokeAnalyseMood("HAPPY", "AnaliseMod");
            }
            catch (MoodAnalyzeException e)
            {
                //Assert
                Assert.AreEqual("no such method", e.Message);
            }
        }
        [TestMethod]
        public void GivenHappyMessageWithReflection_ShouldReturnHAPPY()
        {
            //Arrange
            string message = "HAPPY";
            string fieldName = "message";
            //Act
            string actual = MoodAnalyserFactory.SetField(message, fieldName);
            //Assert
            Assert.AreEqual("HAPPY", actual);
        }
        [TestMethod]
        public void GivenImproperFieldName_ShouldThrowExceptionWithNoField()
        {
            try
            {
                //Arrange
                string message = "HAPPY";
                string fieldName = "mesege";
                //Act
                string actual = MoodAnalyserFactory.SetField(message, fieldName);
            }
            catch (MoodAnalyzeException e)
            {
                //Assert
                Assert.AreEqual("no such field found", e.Message);
            }
        }
        [TestMethod]
        public void GivenNullMessage_ShouldThrowException()
        {
            try
            {
                //Arrange
                string message = null;
                string fieldName = "message";
                //Act
                string actual = MoodAnalyserFactory.SetField(message, fieldName);
            }
            catch (MoodAnalyzeException e)
            {
                //Assert
                Assert.AreEqual("message should not be null", e.Message);
            }
        }
    }
}