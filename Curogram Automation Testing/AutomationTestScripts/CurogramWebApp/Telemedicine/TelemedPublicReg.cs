using Curogram_Automation_Testing.appManager;
using Curogram_Automation_Testing.AppManager;
using Curogram_Automation_Testing.AutomationTestScripts.CurogramWebApp.Users.ResetProviderPassword;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curogram_Automation_Testing.AutomationTestScripts.CurogramWebApp.Telemedicine
{
    [TestFixture]
    [Parallelizable]
    internal class TelemedPublicReg
    {
        //Patient Variables
        public static String? PFName;
        public static String? PMName;
        public static String? PLName;
        public static String? CellNo = "9999999999";
        public static String? PEmail;
        public static String? PAddress;
        public static String? PUnitNo;
        public static String? PCity;
        public static String? PCounty;
        public static String? PZip;

        //Guardians Variables
        public static String? GFName;
        public static String? GMName;
        public static String? GLName;
        public static String? GEmail;
        public static String? GAddress;
        public static String? GCity;
        public static String? GZip;

        //Emergency Contanct Variable
        public static String? EcFName;
        public static String? EcMName;
        public static String? EcLName;

        //Insurance Info Variables
        public static String? GId;
        public static String? MId;
        public static String? ICN;
        public static String? ICA;
        public static String? ICity;
        public static String? IZip;

        //Card No Variables
        public static String? CCNum = "4111111111111111";
        public static String? CCExp = "12/35";
        public static String? CVV   = "999" ;

        //MRR Authorization Variables
        public static String? MrrFName;
        public static String? MrrMName;
        public static String? MrrLName;

        //Drivers License Variables
        public static String? DLNum;

        //Window Variables
        public static String? YopWeb;
        public static String? RegPage;
        public static String? WPatient;

        //Set Values to Variables
        public static void ModifyVars()
        {
            SeleniumCommands a = new();
            //Patients
            PFName      = a.StringGenerator("allletters",   9);
            PMName      = a.StringGenerator("allletters",   9);
            PLName      = a.StringGenerator("allletters",   9);
            PEmail      = a.StringGenerator("alphanumeric", 9) + "@mailsac.com";
            PAddress    = a.StringGenerator("allletters",   9);
            PUnitNo     = a.StringGenerator("allnumbers",   4);
            PCity       = a.StringGenerator("allletters",   5);
            PCounty     = a.StringGenerator("allletters",   9);
            PZip        = a.StringGenerator("allnumbers",   5);

            //Guardians
            GFName      = a.StringGenerator("allletters",   9);
            GMName      = a.StringGenerator("allletters",   9);
            GLName      = a.StringGenerator("allletters",   9);
            GEmail      = a.StringGenerator("alphanumeric", 9) + "@mailsac.com";
            GAddress    = a.StringGenerator("allletters",   9);
            GCity       = a.StringGenerator("allletters",   9);
            GZip        = a.StringGenerator("allnumbers",   5);

            //Emergency contacts
            EcFName     = a.StringGenerator("allletters",   9);
            EcMName     = a.StringGenerator("allletters",   9);
            EcLName     = a.StringGenerator("allletters",   9);

            //Insurance
            GId         = a.StringGenerator("alphanumeric", 9);
            MId         = a.StringGenerator("alphanumeric", 9);
            ICN         = a.StringGenerator("allletters",   9);
            ICA         = a.StringGenerator("allletters",   9);
            ICity       = a.StringGenerator("allletters",   9);
            IZip        = a.StringGenerator("allnumbers",   5);

            //MRR Authorization
            MrrFName    = a.StringGenerator("allletters",   9);
            MrrMName    = a.StringGenerator("allletters",   9);
            MrrLName    = a.StringGenerator("allletters",   9);

            //Driver's license
            DLNum       = a.StringGenerator("alphanumeric", 9);

            //Windows
            YopWeb      = a.StringGenerator("allletters",   9);
            RegPage     = a.StringGenerator("allletters",   9);
            WPatient    = a.StringGenerator("allletters",   9);

        }


        //Test execution
        [Test]
        public void TelePubReg()
        {
            ModifyVars();
            SeleniumCommands a = new();
            Console.WriteLine("Testing: Instant Telemedicine Public Registration Test");

            try
            {
                //open yopmail website
                a.StartDriver("Chrome");
                a.SaveWindow(YopWeb, 0);
                a.NavTo("https://mailsac.com/login");
                a.Pause(4);
                a.TypeM("//input[@name='username']", "marnel.abrenica@curogram.com");
                a.TypeM("//input[@name='password']", "G3h_amping123");
                a.ClickOn("//button[@type='submit']");
                a.Pause(4);


                //register generated email in mailsac
                a.TypeM("//input[@type='text'][1]", PEmail);
                a.Pause(1);
                a.ClickOn("//button[contains(text(),'Check the mail!')]");


                //Open registration page
                a.StartNewWindow(RegPage);
                a.NavTo("https://staging.curogram.com/registrations/6400a92a073cd10ee0c9a868");


                //Test Pass
                TestLogger.Logger("Instant Telemedicine Public Registration Test: Pass");
                a.DQuit();
            }

            //Test Failed
            catch (Exception e)
            {
                string message = "Instant Telemedicine Public Registration Test: Fail - -";
                TestLogger.Logger(message + e.Message);
                Console.WriteLine(message + e.Message);
                a.DQuit();
                Assert.That(e.Message, Is.EqualTo(""));

            }

        }

    }
}
