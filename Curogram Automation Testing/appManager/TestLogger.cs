
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using System.Collections.Concurrent;

namespace Curogram_Automation_Testing.appManager
{
    public class TestLogger
    {
        public static List<string> logMessages = new List<string>();
        public static ConcurrentQueue<string> eventLogs = new ConcurrentQueue<string>();

        public static void Logger(string message)
        {
            string logMessage = $"{message}"; 
            logMessages.Add(logMessage); 
        }

        public static void EventLogger(string message)
        {
            string logMessage = $"[{DateTime.Now.ToString("hh:mm:ss tt")}] " + $"{message}";
            eventLogs.Enqueue(logMessage);
        }

        public static void FilterAndDisplayLogs()
        {
            Console.ForegroundColor = ConsoleColor.Black;
            for (int a = 0; a < 4;)
            {
                Console.WriteLine("*");
                a++;
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("------------------- TEST RESULTS -------------------");
            Console.ResetColor();
            foreach (string logMessage in logMessages)
            {
                if (logMessage.Contains("Pass")) 
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(logMessage);                    
                    Console.ResetColor();
                }

                else if (logMessage.Contains("Fail"))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(logMessage);                  
                    Console.ResetColor();
                }
            }

            int passCount = 0;
            int failCount = 0;

            foreach (string logMessage in logMessages)
            {
                if (logMessage.Contains("Pass"))
                {
                    passCount++;
                }
                else if (logMessage.Contains("Fail"))
                {
                    failCount++;
                }
            }

            Console.ForegroundColor = ConsoleColor.Black;
            for (int a = 0; a < 3;)
            {
                Console.WriteLine("*");
                a++;
            }
            Console.ResetColor();


            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("---------------- TEST SUMMARY --------------------");
            Console.WriteLine($"Total Tests: {passCount + failCount}");
            Console.WriteLine($"Passed Tests: {passCount}");
            Console.WriteLine($"Failed Tests: {failCount}");
            Console.ResetColor();
        }
    }
}
