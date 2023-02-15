using Curogram_Automation_Testing.App_manager;
using Curogram_Automation_Testing.appManager;


namespace Curogram_Automation_Testing
{

    internal class Program
    {
  
        static void Main(string[] args)
        {
            //import methods adn declare objects
            UserInterface initProg = new UserInterface();
            TaskManager startManager = new TaskManager();








            initProg.StartProgram();

            try
            {
                startManager.ParallelRun();
            }
            catch (Exception)
            {
                Console.WriteLine("Error in test execution");
            }









        }
    }
}