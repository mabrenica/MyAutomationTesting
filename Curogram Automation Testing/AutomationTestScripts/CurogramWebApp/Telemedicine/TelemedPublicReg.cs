using Curogram_Automation_Testing.appManager;
using Curogram_Automation_Testing.AppManager;
using NUnit.Framework;

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
        public static String? WProvider;
        public static String? TeleRoom;

        //Set Values to Variables with random strings
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
            WProvider   = a.StringGenerator("allletters",   9);
            TeleRoom    = a.StringGenerator("allletters",   9);

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
                a.StartDriver("Chrome", YopWeb);
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


                //Introduction
                a.WUntil("//div[contains(text(),' introduction ')]");
                a.ClickOn("//button[contains(text(),' Get started')]");

                //Verification using email
                a.WUntil("//div[contains(text(),' identification')]");
                a.ClickOn("//span[contains(text(),'I do not have a cell phone number')]");
                a.TypeM("//input[@placeholder='Email']", PEmail);
                a.ClickOn("//button[contains(text(),'Next')]");
                a.WUntil("//h4[@class='check-result__title']");
                a.SwitchWindow(YopWeb);
                a.RefreshUntil("//strong[contains(text(),'no-reply@curogram.com')]");
                a.ClickOn("//strong[contains(text(),'no-reply@curogram.com')]");
                a.Pause(1);

                //Extract OPT code and enter
                var otpCode = a.GetOtp("//p[@class='o_mb-md o_sick-message']");
                a.SwitchWindow(RegPage);
                a.TypeCode(otpCode, "//input[@placeholder='—']");

                //Demographics
                a.WUntil(" //div[contains(text(),'demographics')]");
                a.TypeM("//input[@placeholder='First Name']", PFName);
                a.TypeM("//input[@placeholder='Middle Name']", PMName);
                a.TypeM("//input[@placeholder='Last Name']", PLName);
                a.TypeM("//input[@placeholder='Cell Phone Number']", CellNo);
                a.ClickOn("//button[contains(text(),'Next')]");


                //Patient Address
                a.WUntil("//div[contains(text(),'patient address')]");
                a.ClickOn("//input[@id='home']");
                a.TypeM("//input[@name='address']", PAddress);
                a.TypeM("//input[@placeholder='Unit Number']", PUnitNo);
                a.TypeM("//input[@placeholder='City']", PCity);
                a.TypeM("//input[@placeholder='County']", PCounty);
                a.ClickOn("//div[@role='combobox']");
                a.ClickOn("//span[contains(text(),'CA')]");
                a.TypeM("//input[@placeholder='Zip Code']", PZip);
                a.ClickOn("//button[contains(text(),'Next')]");

                //Referral Source
                a.WUntil("//div[contains(text(),'referral source')]");
                a.ClickOn("//label[@for='other']");
                a.ClickOn("//button[contains(text(),'Next')]");

                //Screening 
                a.WUntil("//div[contains(text(),'screening')]");
                a.ClickOn("//label[@for='answer_0_1']");
                a.ClickOn("//label[@for='answer_1_1']");
                a.ClickOn("//button[contains(text(),'Next')]");

                //Telemedicine History
                a.WUntil("//div[contains(text(),'Telemedicine History')]");
                a.ClickOn("//label[@for='no']");
                a.ClickOn("//button[contains(text(),'Next')]");

                //Symptoms
                a.WUntil("//div[contains(text(),'Symptoms')]");
                a.ClickOn("//label[@for='false']");
                a.ClickOn("//button[contains(text(),'Next')]");

                //Medical History
                a.WUntil("//div[contains(text(),'Medical History')]");
                a.ClickOn("//label[@for='none']");
                a.ClickOn("//button[contains(text(),'Next')]");

                //Guardian
                a.WUntil("//div[contains(text(),'guardian')]");
                a.TypeM("//input[@placeholder='First Name']", GFName);
                a.TypeM("//input[@placeholder='Middle Name']", GMName);
                a.TypeM("//input[@placeholder='Last Name']", GLName);
                a.ClickOn("//curo-dob[1]//div[@class=\"ng-select-container\"]//div[@role='combobox'][1]");
                a.ClickOn("//span[contains(text(),'January')]");
                a.ClickOn("//curo-dob[1]//div[@class=\"ng-select-container\"]//div[@role='combobox'][1]");
                a.ClickOn("//span[./text()='1']");
                a.ClickOn("//curo-dob[1]//div[@class=\"ng-select-container\"]//div[@role='combobox'][1]");
                a.ClickOn("//span[./text()='2020']");
                a.TypeM("//input[@placeholder='Cell Phone Number']", CellNo);
                a.TypeM("//input[@placeholder='Email']", GEmail);
                a.ClickOn("//ng-select[@formcontrolname='gender']");
                a.ClickOn("//span[contains(text(),'Male')]");
                a.ClickOn("//ng-select[@formcontrolname='relation']");
                a.ClickOn("//span[contains(text(),'Other')]");
                a.TypeM("//input[@name='address']", GAddress);
                a.TypeM("//input[@name='city']", GCity);
                a.ClickOn("//ng-select[@formcontrolname='state']");
                a.ClickOn("//span[contains(text(),'CA')]");
                a.TypeM("//input[@name='zip']", GZip);
                a.ClickOn("//button[contains(text(),'Next')]");

                //Disability
                a.WUntil("//div[contains(text(),'disability')]");
                a.ClickOn("//input[@id='checkbox3']");
                a.ClickOn("//button[contains(text(),'Next')]");

                //Emergency contact
                a.WUntil("//div[contains(text(),'emergency contact')]");
                a.TypeM("//input[@name='firstname']", EcFName);
                a.TypeM("//input[@formcontrolname='middleName']", EcMName);
                a.TypeM("//input[@formcontrolname='lastName']", EcLName);
                a.TypeM("//input[@formcontrolname='phone']", CellNo);
                a.ClickOn("//button[contains(text(),'Next')]");

                //Insurance info
                a.WUntil("//div[contains(text(),'insurance info')]");
                a.TypeM("//input[@formcontrolname='groupId']", GId);
                a.TypeM("//input[@formcontrolname='memberId']", MId);
                a.TypeM("//input[@formcontrolname='companyName']", ICN);
                a.TypeM("//input[@formcontrolname='address']", ICA);
                a.TypeM("//input[@formcontrolname='city']", ICity);
                a.ClickOn("//ng-select[@formcontrolname='state']");
                a.ClickOn("//span[contains(text(),'CA')]");
                a.TypeM("//input[@formcontrolname='zipcode']", IZip);
                a.ClickOn("//button[contains(text(),'Next')]");

                //Insurance Card
                a.WUntil("//div[contains(text(),'insurance card')]");
                a.UploadImage("//curo-card-upload-preview[@class='insurance-card__upload mr-3']//input[@class='d-none']");
                a.UploadImage("//curo-card-upload-preview[@class='insurance-card__upload']//input[@class='d-none']");
                a.Pause(2);
                a.ClickOn("//button[contains(text(),'Next')]");

                //Identification
                a.WUntil("//div[contains(text(),'identification')]");
                a.TypeM("//input[@formcontrolname='driversLicenseId']", DLNum);
                a.ClickOn("//ng-select[@formcontrolname='driversLicenseState']");
                a.ClickOn("//span[contains(text(),'CA')]");
                a.UploadImage("//curo-card-upload-preview[@class='insurance-card__upload mr-3 full-text']//input[@class='d-none']");
                a.UploadImage("//curo-card-upload-preview[@class='insurance-card__upload full-text']//input[@class='d-none']");
                a.Pause(2);
                a.ClickOn("//button[contains(text(),'Next')]");

                //Document submission
                a.WUntil("//div[contains(text(),'document submission')]");
                a.UploadImage("//div[@class='d-flex justify-content-between align-items-center upload-item'][1]//input[@type='file']");
                a.Pause(1);
                a.UploadImage("//div[@class='d-flex justify-content-between align-items-center upload-item'][2]//input[@type='file']");
                a.Pause(1);
                a.UploadImage("//div[@class='d-flex justify-content-between align-items-center upload-item'][3]//input[@type='file']");
                a.ClickOn("//button[contains(text(),'Next')]");

                //Payment
                a.WUntil("//div[contains(text(),'payment')]");
                a.Pause(1);
                a.iFrameInput("//iframe[@title='Secure card number input frame']", "//input[@name='cardnumber']", CCNum);
                a.iFrameInput("//iframe[@title='Secure expiration date input frame']", "//input[@name='exp-date']", CCExp);
                a.iFrameInput("//iframe[@title='Secure CVC input frame']", "//input[@name='cvc']", CVV);

                a.ClickOn("//button[contains(text(),'Next')]");

                //Consent
                a.WUntil("//div[contains(text(),'consent')]");
                a.ClickOn("//button[contains(text(),'I Agree')]");

                //MRR Authorization
                a.WUntil("//div[contains(text(),'MRR authorization')]");
                a.TypeM("//input[@formcontrolname='firstName']", MrrFName);
                a.TypeM("//input[@formcontrolname='middleName']", MrrMName);
                a.TypeM("//input[@formcontrolname='lastName']", MrrLName);
                a.ClickOn("//div[@role='combobox']");
                a.ClickOn("//span[contains(text(),'Other')]");
                a.ClickOn("//button[contains(text(),'I Agree')]");

                //Signature
                a.WUntil("//div[contains(text(),'signature')]");
                a.DrawSign("//curo-signature[@formcontrolname='signature']//canvas");
                a.ClickOn("//button[contains(text(),'Agree and Sign')]");

                //Telemedicine Waiting Room
                a.WUntil("//div[contains(text(),'Thank you for waiting. A provider will be with you shortly.')]", 90);

                //Login as provider
                a.StartNewWindow(WProvider);
                a.SwitchWindow(WProvider);
                a.NavTo("https://app.staging.curogram.com");
                a.WUntil("//input[@type='text']");
                a.TypeM("//input[@type=\'text\']", "testrigorcpuser@curogram.com");
                a.TypeM("//input[@type=\'password\']", "password1");
                a.ClickOn("//button[@type=\'submit\']");
                a.WUntil("//div[contains(text(),'Quick Actions')]");
                a.ClickOn("//div[@style='background-image: url(\"https://files.staging.curogram.com/9efe4805-ffe4-492d-bf70-66fff1fd45e3.png\");']");

                //Open telemedicine dashboard
                a.ClickOn("//span[contains(text(),'Telemedicine')]");
                a.WUntil("//span[contains(text(),'All Availabilities')]");
                a.ClickOn("//span[contains(text(),'All Availabilities')]");
                a.ClickOn("//label[contains(text(),'Available')]");
                a.Pause(3);
                a.VerifyText("//span[@container='body']", PFName + " " + PMName + " " + PLName);
                a.ClickOn("//curogram-icon[@apptooltip='Enter the room']");
                a.Pause(3);

                //Provider telemedicine room
                a.SaveWindow(TeleRoom, 3);
                a.SwitchWindow(TeleRoom);
                a.WUntil("//video[@style='height: 100%; position: absolute;']");
                a.CheckElement("//video[@style='height: 100%; position: absolute;']");
                a.WUntil("//video[@style='height: 100%; position: absolute; transform: scaleX(-1);']");
                a.CheckElement("//video[@style='height: 100%; position: absolute; transform: scaleX(-1);']");
                a.Pause(5);

                //Patient telemedicine room
                a.SwitchWindow(RegPage);
                a.WUntil("//video[@style='height: 100%; width: 100%; object-fit: cover; position: absolute;']");
                a.CheckElement("//video[@style='height: 100%; width: 100%; object-fit: cover; position: absolute;']");
                a.WUntil("//video[@style='height: 100%; width: 100%; object-fit: cover; transform: scaleX(-1);']");
                a.CheckElement("//video[@style='height: 100%; width: 100%; object-fit: cover; transform: scaleX(-1);']");

                //Mark visit complete
                a.SwitchWindow(TeleRoom);
                a.ClickOn("//button[@apptooltip='End Call']");
                a.Pause(2);
                a.ClickOn("//button[contains(text(),'End session')]");
                a.Pause(5);

                //Verify is telemedicine dashboard
                a.ClickOn("//span[contains(text(),'1 Availabilities')]");
                a.ClickOn("//label[contains(text(),' Available ')]");
                a.Pause(4);
                a.TypeM("//input[@placeholder='Find by name']", PFName);
                a.Pause(5);
                a.CheckElement("//span[contains(text(),\" Visit completed \")]");


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
