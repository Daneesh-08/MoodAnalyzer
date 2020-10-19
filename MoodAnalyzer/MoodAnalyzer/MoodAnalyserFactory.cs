﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Text.RegularExpressions;

namespace MoodAnalyzer
{
    public class MoodAnalyserFactory
    {
        public static object CreateMoodAnalyserObject(string className, string constructorName)
        {
            string pattern = @"." + constructorName + "$";
            Match result = Regex.Match(className, pattern);
            if (result.Success)
            {
                try
                {
                    Assembly executing = Assembly.GetExecutingAssembly();
                    Type moodAnalyseType = executing.GetType(className);
                    return Activator.CreateInstance(moodAnalyseType);
                }
                catch (ArgumentNullException)
                {
                    throw new MoodAnalyzeException(MoodAnalyzeException.ExceptionType.NO_SUCH_CLASS, "class not found");
                }
            }
            else
            {
                throw new MoodAnalyzeException(MoodAnalyzeException.ExceptionType.NO_SUCH_METHOD, "constructor not found");
            }
        }
        public static object CreateMoodAnalyserObjectUsingParameterisedConstructor(string className, string constructorName, string message)
        {
            Type type = typeof(MoodAnalyze);
            if (type.Name.Equals(className) || type.FullName.Equals(className))
            {
                if (type.Name.Equals(constructorName))
                {
                    ConstructorInfo ctor = type.GetConstructor(new[] { typeof(string) });
                    object instance = ctor.Invoke(new object[] { message });
                    return instance;
                }
                else
                {
                    throw new MoodAnalyzeException(MoodAnalyzeException.ExceptionType.NO_SUCH_METHOD, "constructor not found");
                }
            }
            else
            {
                throw new MoodAnalyzeException(MoodAnalyzeException.ExceptionType.NO_SUCH_CLASS, "class not found");
            }
        }
        public static string InvokeAnalyseMood(string message, string methodName)
        {
            try
            {
                string className = "MoodAnalyzer.MoodAnalyze";
                Type type = Type.GetType(className);
                object moodAnalyserObj = CreateMoodAnalyserObjectUsingParameterisedConstructor(className, "MoodAnalyze", message);
                MethodInfo methodInfo = type.GetMethod(methodName);
                object mood = methodInfo.Invoke(moodAnalyserObj, null);
                return mood.ToString();
            }
            catch (NullReferenceException)
            {
                throw new MoodAnalyzeException(MoodAnalyzeException.ExceptionType.NO_SUCH_METHOD, "no such method");
            }
        }
        public static string SetField(string message, string fieldName)
        {
            try
            {
                MoodAnalyze moodanalyzer = new MoodAnalyze();
                Type type = Type.GetType("MoodAnalyzer.MoodAnalyze");
                FieldInfo fieldInfo = type.GetField(fieldName);
                if (message == null)
                {
                    throw new MoodAnalyzeException(MoodAnalyzeException.ExceptionType.EMPTY_MESSAGE, "message should not be null");
                }
                fieldInfo.SetValue(moodanalyzer, message);
                return moodanalyzer.message;
            }
            catch (NullReferenceException)
            {
                throw new MoodAnalyzeException(MoodAnalyzeException.ExceptionType.NO_SUCH_FIELD, "no such field found");
            }
        }
    }
}
