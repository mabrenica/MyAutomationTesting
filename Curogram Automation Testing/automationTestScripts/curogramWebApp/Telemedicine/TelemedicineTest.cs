using Curogram_Automation_Testing.appManager;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curogram_Automation_Testing.automationTestScripts.curogramWebApp.Telemedicine
{
    [TestFixture]
    [Parallelizable]
    internal class TelemedicineTest
    {
        [Test]
        public void Telemed()
        {
            SeleniumCommands a = new SeleniumCommands();


            a.NavTo("https://app.staging.curogram.com");
            a.Type("//input[@placeholder='Enter your email address']", "testrigorcpuser@curogram.com");
            a.Type("//input[@placeholder='Enter password']", "password1");
            a.ClickOn("//button[@type='submit']");
            a.Pause(5000);
            a.DClose();
        }
    }
}
