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
            var patientEmail = a.StringGenerator(1)+"@mailsac.com";
            var patientFirstName = a.StringGenerator(2);
            var patientLastName = a.StringGenerator(3);
            var patientFullName = patientFirstName+" "+ patientLastName;



            a.NavTo("https://app.staging.curogram.com");
            a.Pause(5000);
            a.DQuit();
        }
    }
}
