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
            string logMessage = $"{message}"; // add a timestamp to the log message
            //Console.WriteLine(logMessage); // print the log message to the console
            logMessages.Add(logMessage); // add the log message to the list
        }


        public static void FilterAndDisplayLogs()
        {
            for (int a = 0; a < 4;)
            {
                Console.WriteLine("*");
                a++;
            }
            Console.WriteLine("-----------------TEST RESULTS-----------------");
            foreach (string logMessage in logMessages)
            {
                if (logMessage.Contains("Pass") || logMessage.Contains("Fail")) // check if the log message contains "PASS" or "FAIL"
                {
                    Console.WriteLine(logMessage); // print the log message to the console
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

            Console.WriteLine("---------------- TEST SUMMARY --------------------");
            Console.WriteLine($"Total Tests: {passCount + failCount}");
            Console.WriteLine($"Passed Tests: {passCount}");
            Console.WriteLine($"Failed Tests: {failCount}");
        }
    }
}
