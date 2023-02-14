﻿using Curogram_Automation_Testing.automationTestScripts.curogramWebApp.providerLoginPage;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.DevTools.V107.ServiceWorker;
using Curogram_Automation_Testing.automationTestScripts.curogramWebApp.AddUsers;
using Curogram_Automation_Testing.automationTestScripts.curogramWebApp.users;
using Curogram_Automation_Testing.automationTestScripts.curogramWebApp.users.ResetProviderPassword;
using Curogram_Automation_Testing.automationTestScripts.curogramWebApp.Telemedicine;

namespace Curogram_Automation_Testing.appManager
{
    internal class TaskManager
    {

        public void ParallelRun()
        {
            //import methods as tasks to be executed
            ProviderLogin t1= new ProviderLogin();
            AddUserTest t2 = new AddUserTest();
            ResetProviderPassword t3 = new ResetProviderPassword();
            TelemedicineTest t4 = new TelemedicineTest();

            //running in parallel
            ParallelOptions parallelOptions = new ParallelOptions
            {
                MaxDegreeOfParallelism = 5
            };
            Parallel.Invoke(parallelOptions,

             () => t1.ProviderLoginTest(),
             () => t2.addUser(),
             () => t3.RestUserPassword(),
             () => t4.Telemed()

            );




        }
    }
}
