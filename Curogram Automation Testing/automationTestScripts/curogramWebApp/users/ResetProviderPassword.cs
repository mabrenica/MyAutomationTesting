/* 
 * Mailsac username: marnel.abrenica@curogram.com
 * Mailsac password: G3h_amping123
 */



using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using System.Net.Http.Headers;
using System.Net;
using Curogram_Automation_Testing.AppManager;

namespace Curogram_Automation_Testing.AutomationTestScripts.CurogramWebApp.Users.ResetProviderPassword
{
    [TestFixture]
    [Parallelizable]
    internal class ResetProviderPassword
    {
        public static String FirstName;
        public static String LastName;
        public static String Email;
        public static String Password;

        //modify class variables
        public static void ModifyVars()
        {
            SeleniumCommands stringGen= new SeleniumCommands();
            var genFirstName = stringGen.StringGenerator("allletters");
            ResetProviderPassword.FirstName = genFirstName;

            var genLastName = stringGen.StringGenerator("allletters");
            ResetProviderPassword.LastName = genLastName;   

            var genEmail = stringGen.StringGenerator("alphaneumeric");
            ResetProviderPassword.Email = genEmail;

            var genPassword = stringGen.StringGenerator("alphaneumeric");
            ResetProviderPassword.Password = genPassword + 11;
        }
 



        private IWebDriver? driver;
        public IDictionary<string, object>? vars { get; private set; }
        private IJavaScriptExecutor? js;

        public string waitForWindow(int timeout)
        {

            try
            {
                Thread.Sleep(timeout);
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }

            var whNow = ((IReadOnlyCollection<object>)driver.WindowHandles).ToList();
            var whThen = ((IReadOnlyCollection<object>)vars["WindowHandles"]).ToList();
            if (whNow.Count > whThen.Count)
            {
                return whNow.Except(whThen).First().ToString();
            }
            else
            {
                return whNow.First().ToString();
            }
        }

        public async Task ApiRequest()
        {
            var handler = new HttpClientHandler();
            handler.AutomaticDecompression = ~DecompressionMethods.None;


            using (var httpClient = new HttpClient(handler))
            {

                using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://api-v2.staging.curogram.com/practices/63d295fe2046a186b99b2537/staff"))
                {
                    request.Headers.TryAddWithoutValidation("Accept", "application/json, text/plain, */*");
                    request.Headers.TryAddWithoutValidation("Accept-Language", "en-US,en;q=0.9,fil;q=0.8,es;q=0.7");
                    request.Headers.TryAddWithoutValidation("Authorization", "Basic eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCJ9.eyJkZXZpY2VUeXBlIjoid2ViIiwiaXNzdWVyIjoibG9naW5BcyIsImFjY291bnRJZCI6IjYzZTM2ZmExYWNhMjEwNTRjNmMzYzhkNyIsImNyZWF0ZWRBdCI6MTY3NTg2MDM4ODI4MywiYnVzaW5lc3NJZCI6IjYzZDI5NWZlMjA0NmExODZiOTliMjUzNyIsImlhdCI6MTY3NTg2MDM4OCwiZXhwIjoxNjc4NDUyMzg4LCJpc3MiOiJsb2dpbkFzIn0.p2DpDRQR7ALT23M2t9bHVFR142YnuFYSlfHhTOaWj7uQybOoPodd_QEyNKa4Zn1rYG5FnyUj1IeiQSFJCLDXOKAuvRRuSzbu9qTZZbrMptIFFH3353Ty7m2oLQopbnciotpUoYhobqQp-6NfEBuH_UWem-O8xotUra9txH_WGs4-kTwKSz7vrbQA6IjwAlbITNdwX4Oi4sE3vZbLysOOqvgwGwx9pE9Rilc_dRqWpDyF_2gyhDEX_Nq-5wTCQUK5J12IdrsKYGAoeosdnvbmQQqFOW3BGW6Dozlreu2oyeW_I9fN_2MauG1b3pB1PomaSOvrAdiBd7L0BBrcokuKYQ");
                    request.Headers.TryAddWithoutValidation("Connection", "keep-alive");
                    request.Headers.TryAddWithoutValidation("Origin", "https://app.staging.curogram.com");
                    request.Headers.TryAddWithoutValidation("Referer", "https://app.staging.curogram.com/");
                    request.Headers.TryAddWithoutValidation("Sec-Fetch-Dest", "empty");
                    request.Headers.TryAddWithoutValidation("Sec-Fetch-Mode", "cors");
                    request.Headers.TryAddWithoutValidation("Sec-Fetch-Site", "same-site");
                    request.Headers.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/109.0.0.0 Safari/537.36");
                    request.Headers.TryAddWithoutValidation("sec-ch-ua", "\"Not_A Brand\";v=\"99\", \"Google Chrome\";v=\"109\", \"Chromium\";v=\"109\"");
                    request.Headers.TryAddWithoutValidation("sec-ch-ua-mobile", "?0");
                    request.Headers.TryAddWithoutValidation("sec-ch-ua-platform", "\"Windows\"");
                    request.Content = new StringContent("{\"role\":\"admin\",\"staffType\":\"staff\",\"lowRateNotificationEnabled\":false,\"incomingDocumentEmailEnabled\":false,\"screeningResultsEnabled\":false,\"appointmentRequestNotificationEnabled\":false,\"preferredLocationIds\":null,\"firstName\":\"" + ResetProviderPassword.FirstName + "\",\"lastName\":\"" + ResetProviderPassword.LastName + "\",\"prefix\":null,\"suffix\":null,\"email\":\"" + ResetProviderPassword.Email+"@mailsac.com" + "\"}");
                    request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
                    var response = await httpClient.SendAsync(request);
                    if (response.IsSuccessStatusCode)
                    {
                        var responseContent = await response.Content.ReadAsStringAsync();
                        //Console.WriteLine(responseContent);
                    }
                    else
                    {
                        Console.WriteLine($"Request failed with status code: {response.StatusCode}");
                    }
                }

            }
        }



        [Test]
        public void RestUserPassword()
        {
            ModifyVars();
            ApiRequest();
            driver = new FirefoxDriver();
            js = (IJavaScriptExecutor)driver;
            vars = new Dictionary<string, object>();

            try
            {
                Console.WriteLine("Testing: Reset provider password");
                //open yopmail website
                vars["WindowHandles"] = driver.WindowHandles;
                vars["MailSacWindow"] = driver.CurrentWindowHandle;
                var siteTimeout = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
                siteTimeout.Until(webDriver =>
                {
                    driver.Navigate().GoToUrl("https://mailsac.com/login");
                    return true;
                });
                driver.FindElement(By.XPath("//input[@name='username']")).Click();
                driver.FindElement(By.XPath("//input[@name='username']")).SendKeys("marnel.abrenica@curogram.com");
                driver.FindElement(By.XPath("//input[@name='password']")).Click();
                driver.FindElement(By.XPath("//input[@name='password']")).SendKeys("G3h_amping123");
                driver.FindElement(By.XPath("//button[@type='submit']")).Click();
                Thread.Sleep(3000);



                //register generated email in mailsac
                IWebElement emailInputField = driver.FindElement(By.XPath("//input[@type='text'][1]"));
                js.ExecuteScript("arguments[0].value = '" + ResetProviderPassword.Email + "';", emailInputField);
                driver.FindElement(By.XPath("//input[@type='text'][1]")).Click();
                driver.FindElement(By.XPath("//input[@type='text'][1]")).SendKeys(" ");
                driver.FindElement(By.XPath("//input[@type='text'][1]")).SendKeys(Keys.Backspace);
                driver.FindElement(By.XPath("//button[contains(text(),'Check the mail!')]")).Click(); 


                //Start New Window
                driver.SwitchTo().NewWindow(WindowType.Window);
                vars["CurogramWindow"] = driver.CurrentWindowHandle;


                //Open Curogram Site
                siteTimeout.Until(webDriver =>
                {
                    driver.Navigate().GoToUrl("https://staging.curogram.com");
                    return true;
                });
                driver.Navigate().Refresh();
                driver.Manage().Window.Maximize();
                try
                {
                    Thread.Sleep(5000);
                }
                catch (Exception e)
                {
                    Console.WriteLine("{0} Exception caught.", e);
                }


                //click Sign in
                driver.FindElement(By.XPath("//a[@href='/login?hsLang=en']")).Click();
                {
                    WebDriverWait wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(40));
                    wait.Until(driver => driver.FindElements(By.XPath("//div[@class='login-header']")).Count > 0);
                }
                //Click Forgot Password
                driver.FindElement(By.XPath("//button[@class='login-form__label login-form__label--grey bg-transparent border-0 mt-3 mx-auto d-block']")).Click();
                Thread.Sleep(1000);
                driver.FindElement(By.XPath("//input[@name='email']")).Click();

                //Enter generated email
                IWebElement emailResetInputField = driver.FindElement(By.XPath("//input[@name='email']"));
                js.ExecuteScript("arguments[0].value = '" + "" + ResetProviderPassword.Email +"@mailsac.com" + "" + "';", emailResetInputField);
                driver.FindElement(By.XPath("//input[@name='email']")).SendKeys(" ");
                driver.FindElement(By.XPath("//input[@name='email']")).SendKeys(Keys.Backspace);
                Thread.Sleep(1000);
                driver.FindElement(By.XPath("//button[@_ngcontent-curogram-public-c97=''][2]")).Click();
                Thread.Sleep(4000);
                Assert.That(driver.FindElement(By.XPath("//div[@class='modal-body']")).Text, Is.EqualTo("We will send you an email with instructions to reset your password if we find an account associated with this email address"));
                driver.Close();

                //Swith to Yopmail window
                Thread.Sleep(20000);
                driver.SwitchTo().Window(vars["MailSacWindow"].ToString());
                driver.Navigate().Refresh();
                Thread.Sleep(5000);
                driver.FindElement(By.XPath("//td[contains(text(),'[Curogram] Password reset')]")).Click();
                Thread.Sleep(1000);
                driver.FindElement(By.XPath("//a[@class='btn btn-info btn-xs']")).Click();
                vars["win9623"] = waitForWindow(2000);
                driver.SwitchTo().Window(vars["win9623"].ToString());
                Thread.Sleep(3000);
                driver.FindElement(By.XPath("//a[contains(text(),'Your Password')]")).Click();
                Thread.Sleep(7000);
                driver.FindElement(By.XPath("//input[@type='password']")).Click();


                IWebElement ResetPasswordInputField = driver.FindElement(By.XPath("//input[@type='password']"));
                js.ExecuteScript("arguments[0].value = '" + "" + ResetProviderPassword.Password + "" + "';", ResetPasswordInputField);
                driver.FindElement(By.XPath("//input[@type='password']")).SendKeys(" ");
                driver.FindElement(By.XPath("//input[@type='password']")).SendKeys(Keys.Backspace);

                driver.FindElement(By.XPath("//button[contains(text(),'Reset password')]")).Click();
                Thread.Sleep(30000);
                Assert.That(driver.FindElement(By.XPath("//div[contains(text(),'Quick Actions')]")).Text, Is.EqualTo("Quick Actions"));
                driver.Close();
                driver.SwitchTo().Window(vars["MailSacWindow"].ToString());
                driver.Close();
                Console.WriteLine("Reset Provider Login: Pass");
            }
            catch (Exception e)
            {
                Console.WriteLine("Reset Provider Password: Fail - - " + e.Message);
                var result = e.Message;
                driver.Quit();
                Assert.That(result, Is.EqualTo("Pass"));
            }
        }



    }




}

