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
            SeleniumCommands a = new SeleniumCommands();
            var a1 = a.StringGenerator("allletters",   9);
            var a2 = a.StringGenerator("allletters",   9);
            var a3 = a.StringGenerator("allletters",   9);
            var a4 = a.StringGenerator("alphanumeric", 9);
            var a5 = a.StringGenerator("allletters",   9);
            var a6 = a.StringGenerator("allnumbers",   4);
            var a7 = a.StringGenerator("allletters",   5);
            var a8 = a.StringGenerator("allletters",   9);
            var a9 = a.StringGenerator("allnumbers",   5);
            TelemedPublicReg.PFName   = a1;
            TelemedPublicReg.PMName   = a2;
            TelemedPublicReg.PLName   = a3;
            TelemedPublicReg.PEmail   = a4 + "@mailsac.com";
            TelemedPublicReg.PAddress = a5;
            TelemedPublicReg.PUnitNo  = a6;
            TelemedPublicReg.PCity    = a7;
            TelemedPublicReg.PCounty  = a8;
            TelemedPublicReg.PZip     = a9;


            var b1 = a.StringGenerator("allletters",   9);
            var b2 = a.StringGenerator("allletters",   9);
            var b3 = a.StringGenerator("allletters",   9);
            var b4 = a.StringGenerator("alphanumeric", 9);
            var b5 = a.StringGenerator("allletters",   9);
            var b6 = a.StringGenerator("allletters",   9);
            var b7 = a.StringGenerator("allnumbers",   5);
            TelemedPublicReg.GFName   = b1;
            TelemedPublicReg.GMName   = b2;
            TelemedPublicReg.GLName   = b3;
            TelemedPublicReg.GEmail   = b4 + "@mailsac.com";
            TelemedPublicReg.GAddress = b5;
            TelemedPublicReg.GCity    = b6;
            TelemedPublicReg.GZip     = b7;


            var c1 = a.StringGenerator("allletters", 9);
            var c2 = a.StringGenerator("allletters", 9);
            var c3 = a.StringGenerator("allletters", 9);
            TelemedPublicReg.EcFName = c1;
            TelemedPublicReg.EcMName = c2;
            TelemedPublicReg.EcLName = c3;


            var d1 = a.StringGenerator("alphanumeric", 9);
            var d2 = a.StringGenerator("alphanumeric", 9);
            var d3 = a.StringGenerator("allletters",   9);
            var d4 = a.StringGenerator("allletters",   9);
            var d5 = a.StringGenerator("allletters",   9);
            var d6 = a.StringGenerator("allnumbers",   5);
            TelemedPublicReg.GId   = d1;
            TelemedPublicReg.MId   = d2;
            TelemedPublicReg.ICN   = d3;
            TelemedPublicReg.ICA   = d4;
            TelemedPublicReg.ICity = d5;
            TelemedPublicReg.IZip  = d6;


            var e1 = a.StringGenerator("allletters", 9);
            var e2 = a.StringGenerator("allletters", 9);
            var e3 = a.StringGenerator("allletters", 9);
            TelemedPublicReg.MrrFName = e1;
            TelemedPublicReg.MrrMName = e2;
            TelemedPublicReg.MrrLName = e3;


            var f1 = a.StringGenerator("alphanumeric", 9);
            TelemedPublicReg.DLNum = f1;


            var g1 = a.StringGenerator("allletters", 9);
            var g2 = a.StringGenerator("allletters", 9);
            var g3 = a.StringGenerator("allletters", 9);
            TelemedPublicReg.YopWeb    = g1;
            TelemedPublicReg.RegPage   = g2;
            TelemedPublicReg.WPatient  = g3;
        }


        //Test execution
        [Test]
        public void TelePubReg()
        {
            ModifyVars();
            SeleniumCommands a = new SeleniumCommands();
            Console.WriteLine("Testing: Instant Telemedicine Public Registration Test");

            try
            {
                //open yopmail website
                a.StartDriver("Chrome");
                a.SaveWindow(TelemedPublicReg.YopWeb, 0);
                a.NavTo("https://mailsac.com/login");
                a.Pause(4);
                a.TypeM("//input[@name='username']", "marnel.abrenica@curogram.com");
                a.TypeM("//input[@name='password']", "G3h_amping123");
                a.ClickOn("//button[@type='submit']");
                a.Pause(4);


                //register generated email in mailsac
                a.TypeM("//input[@type='text'][1]", TelemedPublicReg.PEmail);
                a.Pause(1);
                a.ClickOn("//button[contains(text(),'Check the mail!')]");


                //Open registration page
                a.StartNewWindow(TelemedPublicReg.RegPage);
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
