using Curogram_Automation_Testing.appManager;
using Curogram_Automation_Testing.AppManager;



namespace Curogram_Automation_Testing
{

    internal class Program
    {

        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("  WELCOME TO CUROGRAM AUTOMATION TESTING  ");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Black;
            for (int a = 0; a < 3;)
            {
                Console.WriteLine("*");
                a++;
            }
            Console.ResetColor();

            try
            {
                TaskManager.TaskRunner();
            }
            catch (Exception)
            {
                Console.WriteLine("Error in test execution");
            }


            TestLogger.FilterAndDisplayLogs();
            Console.WriteLine("Press any key to exit...");
            Console.ReadLine();
        }
    }
}
