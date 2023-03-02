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
            var a1 = a.StringGenerator("allletters",   9);
            var a2 = a.StringGenerator("allletters",   9);
            var a3 = a.StringGenerator("allletters",   9);
            var a4 = a.StringGenerator("alphanumeric", 9);
            var a5 = a.StringGenerator("allletters",   9);
            var a6 = a.StringGenerator("allnumbers",   4);
            var a7 = a.StringGenerator("allletters",   5);
            var a8 = a.StringGenerator("allletters",   9);
            var a9 = a.StringGenerator("allnumbers",   5);
            PFName   = a1;
            PMName = a2;
            PLName = a3;
            PEmail = a4 + "@mailsac.com";
            PAddress = a5;
            PUnitNo = a6;
            PCity = a7;
            PCounty = a8;
            PZip = a9;


            var b1 = a.StringGenerator("allletters",   9);
            var b2 = a.StringGenerator("allletters",   9);
            var b3 = a.StringGenerator("allletters",   9);
            var b4 = a.StringGenerator("alphanumeric", 9);
            var b5 = a.StringGenerator("allletters",   9);
            var b6 = a.StringGenerator("allletters",   9);
            var b7 = a.StringGenerator("allnumbers",   5);
            GFName = b1;
            GMName = b2;
            GLName = b3;
            GEmail = b4 + "@mailsac.com";
            GAddress = b5;
            GCity = b6;
            GZip = b7;


            var c1 = a.StringGenerator("allletters", 9);
            var c2 = a.StringGenerator("allletters", 9);
            var c3 = a.StringGenerator("allletters", 9);
            EcFName = c1;
            EcMName = c2;
            EcLName = c3;


            var d1 = a.StringGenerator("alphanumeric", 9);
            var d2 = a.StringGenerator("alphanumeric", 9);
            var d3 = a.StringGenerator("allletters",   9);
            var d4 = a.StringGenerator("allletters",   9);
            var d5 = a.StringGenerator("allletters",   9);
            var d6 = a.StringGenerator("allnumbers",   5);
            GId = d1;
            MId = d2;
            ICN = d3;
            ICA = d4;
            ICity = d5;
            IZip = d6;


            var e1 = a.StringGenerator("allletters", 9);
            var e2 = a.StringGenerator("allletters", 9);
            var e3 = a.StringGenerator("allletters", 9);
            MrrFName = e1;
            MrrMName = e2;
            MrrLName = e3;


            var f1 = a.StringGenerator("alphanumeric", 9);
            DLNum = f1;


            var g1 = a.StringGenerator("allletters", 9);
            var g2 = a.StringGenerator("allletters", 9);
            var g3 = a.StringGenerator("allletters", 9);
            YopWeb = g1;
            RegPage = g2;
            WPatient = g3;
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
