using Curogram_Automation_Testing.AutomationTestScripts.CurogramWebApp.ProviderLoginPage;
using Curogram_Automation_Testing.AutomationTestScripts.CurogramWebApp.AddUsers;
using Curogram_Automation_Testing.AutomationTestScripts.CurogramWebApp.Users.ResetProviderPassword;
using Curogram_Automation_Testing.AutomationTestScripts.CurogramWebApp.Telemedicine;
using Curogram_Automation_Testing.AutomationTestScripts.CurogramAdmin;


namespace Curogram_Automation_Testing.AppManager
{

    internal class TaskManager
    {

        public static void TaskRunner()
        {
            Dictionary<int, Tuple<Action, string>> testMethods = new();


            //import test classes
            ProviderLogin t1 = new();
            AddUserTest t2 = new();
            ResetProviderPassword t3 = new();
            CpAdminLoginTest t4 = new();
            Telemed1 t5 = new();



            //add list to tasks
            testMethods.Add(1, Tuple.Create(new Action(t1.ProviderLoginTest), "Provider Login Test"));
            testMethods.Add(2, Tuple.Create(new Action(t2.addUser), "Add User Test"));
            testMethods.Add(3, Tuple.Create(new Action(t3.ResetUserPassword), "Reset User Password Test"));
            testMethods.Add(4, Tuple.Create(new Action(t4.CpAdminLogin), "CP Admin Login Test"));
            testMethods.Add(5, Tuple.Create(new Action(t5.Telemed), "Instant Telemedicine Test"));


            //Display test case list
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("--------------- Available Test Cases ---------------");
            foreach (var item in testMethods)
            {
                Console.WriteLine("Test Case ID: {0} || Test Case Name: {1}", item.Key, item.Value.Item2);
            }
            Console.ResetColor();




            bool validMethodSelected = false;
            List<Tuple<Action, string>> selectedMethods = new List<Tuple<Action, string>>();
            int maxParallelism = 4; // set maximum number of running methods
            ParallelOptions options = new ParallelOptions { MaxDegreeOfParallelism = maxParallelism };

            Console.ForegroundColor = ConsoleColor.Black;
            for (int a = 0; a < 3;)
            {
                Console.WriteLine("*");
                a++;
            }
            Console.ResetColor();

            do
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Enter Test ID separated by Comma and press Enter to run test scripts. Otherwise, press ESC to exit.");
                Console.ResetColor();
                var input = Console.ReadKey(true);
                if (input.Key == ConsoleKey.Escape)
                {
                    Console.WriteLine("TEST CANCELED");
                    return;                
                }

                string[] selectedMethodIds = Console.ReadLine().Split(',');
                selectedMethods.Clear();
                foreach (string methodId in selectedMethodIds)
                {
                    if (int.TryParse(methodId, out int id) && testMethods.TryGetValue(id, out var method))
                    {
                        selectedMethods.Add(method);
                    }
                }

                if (selectedMethods.Count > 0)
                {
                    validMethodSelected = true;
                    Parallel.Invoke(options, selectedMethods.Select(m => m.Item1).ToArray());
                    Console.WriteLine("TEST EXECUTION COMPLETE");

                }
                else
                {
                    Console.WriteLine("No valid test methods selected.");
                }
            } while (!validMethodSelected);
        
        }
    }
}
