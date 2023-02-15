namespace Curogram_Automation_Testing.App_manager
{
    internal class UserInterface
    {
        public void StartProgram()
        {

            Console.WriteLine("Welcome to Curogram Test Automation");
            Console.WriteLine("Press any key to continue. . .");
            Console.ReadKey();

        }


        public void TestComplete() {
            Console.WriteLine("Test execution completed. Please close this window.");
        }
    }
}
