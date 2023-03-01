using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curogram_Automation_Testing.appManager
{
    public class TestLogger
    {
        public static List<string> logMessages = new List<string>();

        public static void Logger(string message)
        {
            string logMessage = $"{message}"; 
            logMessages.Add(logMessage); 
        }


        public static void FilterAndDisplayLogs()
        {
            ConsoleColor c = Console.ForegroundColor;

            for (int a = 0; a < 4;)
            {
                Console.WriteLine("*");
                a++;
            }
            Console.WriteLine("-----------------TEST RESULTS-----------------");
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

            for (int a = 0; a < 4;)
            {
                Console.WriteLine("*");
                a++;
            }

            Console.WriteLine("---------------- TEST SUMMARY --------------------");
            Console.WriteLine($"Total Tests: {passCount + failCount}");
            Console.WriteLine($"Passed Tests: {passCount}");
            Console.WriteLine($"Failed Tests: {failCount}");
        }
    }
}
