using Curogram_Automation_Testing.AutomationTestScripts.CurogramWebApp.ProviderLoginPage;
using Curogram_Automation_Testing.AutomationTestScripts.CurogramWebApp.AddUsers;
using Curogram_Automation_Testing.AutomationTestScripts.CurogramWebApp.Users.ResetProviderPassword;
using Curogram_Automation_Testing.AutomationTestScripts.CurogramWebApp.Telemedicine;
using Curogram_Automation_Testing.AutomationTestScripts.CurogramAdmin;

namespace Curogram_Automation_Testing.AppManager
{
    internal class TaskManager
    {

        public void ParallelRun()
        {
            //import methods as tasks to be executed
            ProviderLogin t1= new();
            AddUserTest t2 = new();
            ResetProviderPassword t3 = new();
            InstantTelemedicineTest t4 = new();
            CpAdminLoginTest t5 = new();

            //running in parallel
            ParallelOptions parallelOptions = new ParallelOptions
            {
                MaxDegreeOfParallelism = 5
            };
            Parallel.Invoke(parallelOptions,

             () => t1.ProviderLoginTest(),
             () => t2.addUser(),
             () => t3.RestUserPassword(),
             () => t4.Telemed(),
             () => t5.CpAdminLogin()

            );




        }
    }
}
