using System;
using LabExam.Interfaces;

namespace LabExam.Logger
{
    public class DefaultLogger : ILogger
    {
        public void Log(string message)
        {
           Console.WriteLine($"MESSAGE: {message}");
        }
    }
}