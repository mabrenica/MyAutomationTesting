using Curogram_Automation_Testing.AutomationTestScripts.CurogramWebApp.ProviderLoginPage;
using Curogram_Automation_Testing.AutomationTestScripts.CurogramWebApp.AddUsers;
using Curogram_Automation_Testing.AutomationTestScripts.CurogramWebApp.Users.ResetProviderPassword;
using Curogram_Automation_Testing.AutomationTestScripts.CurogramWebApp.Telemedicine;
using Curogram_Automation_Testing.AutomationTestScripts.CurogramAdmin;
using Curogram_Automation_Testing.appManager;
using System.Diagnostics;
using Curogram_Automation_Testing.AutomationTestScripts.CurogramWebApp.FormStack;
using OpenQA.Selenium.DevTools.V107.DOM;
using System.Net;
using System.Diagnostics;
using System.Configuration;
using SettingsModal;


namespace UI_V2
{
    public partial class MainPage : Form
    {
        Dictionary<int, Tuple<Action, string, string,string>> testMethods = new();
        public CancellationTokenSource cancellationTokenSource;
        public static string Version = "1.0.6";
        public static string AvailableVersion = "";
        public static int MaxParallel;
        public MainPage()
        {
            InitializeComponent();
            //Custom();


            WebClient webclient = new();
            

            try
            {
                string availableVerison = webclient.DownloadString("https://pastebin.com/raw/20irZKm8");
                AvailableVersion= availableVerison;

                if (!availableVerison.Contains(Version))
                {
                    if (MessageBox.Show($"Version {AvailableVersion} is available. Do you want to download it?", "Curogram Automation", MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
                    {
                        try
                        {
                            Process.Start("Curogram_Automation_Updater.exe");
                            this.Close();
                        }
                        catch 
                        {
                            
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Error encountered while updating.", "Curogram Automation", MessageBoxButtons.OK);
            }
        }

        private void UI_V2_Load(object sender, EventArgs e)
        {

            ProviderLogin t1 = new();
            AddUserTest t2 = new();
            ResetProviderPassword t3 = new();
            CpAdminLoginTest t4 = new();
            Telemed1 t5 = new();
            TelemedPublicReg t6 = new();
            Demo t7 = new();
            Demo2 t8 = new();
            FormStack t9 = new();
            PatientPortalLogin t10 = new();






            //Add Test cases to the list    
            testMethods.Add(1, Tuple.Create(new Action(t1.ProviderLoginTest),   "Provider Login Test",                  "CuroWeb",          "User"));
            testMethods.Add(2, Tuple.Create(new Action(t2.addUser),             "Add User Test",                        "CuroWeb",          "User"));
            testMethods.Add(3, Tuple.Create(new Action(t3.ResetUserPassword),   "Reset User Password Test",             "CuroWeb",          "User"));
            testMethods.Add(4, Tuple.Create(new Action(t4.CpAdminLogin),        "CP Admin Login Test",                  "Cp",               "Cp Login"));
            testMethods.Add(5, Tuple.Create(new Action(t5.Telemed),             "Instant Telemedicine Test",            "CuroWeb",          "Telemedicine"));
            testMethods.Add(6, Tuple.Create(new Action(t6.TelePubReg),          "Telemedicine Public Registration",     "CuroWeb",          "Telemedicine"));
            testMethods.Add(7, Tuple.Create(new Action(t7.DemoTest),            "Demo Test - Pass Test",                "Demo",             "Demo"));
            testMethods.Add(8, Tuple.Create(new Action(t8.DemoTest),            "Demo Test 2 - Fail Test",              "Demo",             "Demo"));
            testMethods.Add(9, Tuple.Create(new Action(t9.PatientForm),         "Patient Form Test",                    "CuroWeb",          "Patient Form"));
            testMethods.Add(10, Tuple.Create(new Action(t10.ForgotPassword),    "Patient Portal Login",                 "PatientPortal",    "Patient Login"));


            //Display test cases list
            buttonSelectAllDisabled.Visible = false;
            buttonDeselectAllEnabled.Visible = false;
            buttonStartEnabled.Visible = false;
            buttonStop.Visible = false;
            textBoxSummary.Visible = true;
            textBoxLogs.Visible = false;
            buttonDeselectAllDisabled.Visible = false;

            treeViewTestCases.Nodes.Add("Curogram Web");
            treeViewTestCases.Nodes[0].Nodes.Add("User");
            treeViewTestCases.Nodes[0].Nodes.Add("Telemedicine");
            treeViewTestCases.Nodes[0].Nodes.Add("Patient Form");


            treeViewTestCases.Nodes.Add("Cp");
            treeViewTestCases.Nodes[1].Nodes.Add("Cp Login");


            treeViewTestCases.Nodes.Add("Patient Portal");
            treeViewTestCases.Nodes[2].Nodes.Add("Patient Login");

            treeViewTestCases.Nodes.Add("Demo");
            treeViewTestCases.Nodes[3].Nodes.Add("Demo");

            foreach (var item in testMethods)
            {
                if (item.Value.Item4 == "User")
                {
                    string displayText = $"{item.Value.Item2}";
                    treeViewTestCases.Nodes[0].Nodes[0].Nodes.Add(displayText);
                }
                if (item.Value.Item4 == "Telemedicine")
                {
                    string displayText = $"{item.Value.Item2}";
                    treeViewTestCases.Nodes[0].Nodes[1].Nodes.Add(displayText);
                }
                if (item.Value.Item4 == "Patient Form")
                {
                    string displayText = $"{item.Value.Item2}";
                    treeViewTestCases.Nodes[0].Nodes[2].Nodes.Add(displayText);
                }


                if (item.Value.Item4 == "Cp Login")
                {
                    string displayText = $"{item.Value.Item2}";
                    treeViewTestCases.Nodes[1].Nodes[0].Nodes.Add(displayText);
                }




                if (item.Value.Item4 == "Patient Login")
                {
                    string displayText = $"{item.Value.Item2}";
                    treeViewTestCases.Nodes[2].Nodes[0].Nodes.Add(displayText);
                }


                if (item.Value.Item4 == "Demo")
                {
                    string displayText = $"{item.Value.Item2}";
                    treeViewTestCases.Nodes[3].Nodes[0].Nodes.Add(displayText);
                }

            }
        }

        private async void buttonStartEnabled_Click(object sender, EventArgs e)
        {
            GetConfig();

            StartProcess();

            //Add checked items to execution list
            List<Action> selectedTests = new List<Action>();
            selectedTests.Clear();

            foreach (TreeNode node in treeViewTestCases.Nodes)
            {
                foreach (TreeNode childNode in node.Nodes)
                {


                        foreach(TreeNode grandChild in childNode.Nodes)
                        {
                            if (grandChild.Checked)
                            {
                            string searchValue = grandChild.Text;
                            int key = testMethods.FirstOrDefault(x => x.Value.Item2 == searchValue).Key;
                            Action testMethod = testMethods[key].Item1;
                            selectedTests.Add(testMethod);
                            }
                        }
   
                    
                }
            }



            //Execute checked items in execution list            
            try
            {
                textBoxLogs.Text = "TEST EXECUTION IN PROGRESS . . .";
                StartDisplayingLogs();
                await Task.Run(() => Parallel.ForEach(selectedTests, new ParallelOptions { MaxDegreeOfParallelism = MaxParallel, CancellationToken = cancellationTokenSource.Token }, testMethod =>

                {
                    if (cancellationTokenSource.IsCancellationRequested)
                    {
                        return;
                    }
                    testMethod();
                }));
            }
            catch (Exception ex)
            {
                var message = "Error encountered in test execution";
                TestLogger.Logger(message);
                buttonStop.Visible = false;
                TestLogger.eventLogs.Clear();
                buttonSelectAllEnabled.Visible = false;
                foreach (TreeNode node in treeViewTestCases.Nodes)
                {
                    node.Checked = false;

                    foreach (TreeNode childNode in node.Nodes)
                    {
                        childNode.Checked = false;
                    }
                }
            }


            //wrap up after test execution
            textBoxLogs.Clear();
            textBoxLogs.Text = "TEST EXECUTION COMPLETED";


            //Uncheck all test case items after text execution

            foreach (TreeNode node in treeViewTestCases.Nodes)
            {
                node.Checked = false;

                foreach (TreeNode childNode in node.Nodes)
                {
                    childNode.Checked = false;
                }
            }



            //Display logs as summary after text execution
            foreach (var log in TestLogger.logMessages)
            {

                    if (TestLogger.logMessages.Count < 1)
                    {
                        textBoxLogs.Text = log.ToString();
                    }

                    textBoxLogs.AppendText(Environment.NewLine + log.ToString());
                
            }


            //Count Pass and Fail tests
            int passCount = 0;
            int failCount = 0;
            foreach (string logMessage in TestLogger.logMessages)
            {
                if (logMessage.Contains("Pass:"))
                {
                    passCount++;
                }
                else if (logMessage.Contains("Fail:"))
                {
                    failCount++;
                }
            }

            // Display pass and fail test count
            textBoxLogs.AppendText(Environment.NewLine + "-----------------------------------------------");
            textBoxLogs.AppendText(Environment.NewLine + $"Total Tests: {passCount + failCount}");
            textBoxLogs.AppendText(Environment.NewLine + $"Passed Tests: {passCount}");
            textBoxLogs.AppendText(Environment.NewLine + $"Failed Tests: {failCount}");
            TestLogger.eventLogs.Clear();

            EndOfProcess();
        }

        //Stop button
        private void stopButton_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show("Do you want to stop the test execution?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                StopProcess();
            }
            else
            {

            }
        }


        /*
         * *********************************************METHODS HERE*****************************************************
         */


        public void StartProcess()
        {
            bool hasCheckedNode = false;

            foreach (TreeNode node in treeViewTestCases.Nodes)
            {
                foreach (TreeNode childNode in node.Nodes)
                {
                    foreach (TreeNode grandchild in childNode.Nodes)
                    {
                        if (grandchild.Checked)
                        {
                            hasCheckedNode = true;
                            break;
                        }
                    }
                }

                if (hasCheckedNode)
                {
                    break;
                }
            }

            if (hasCheckedNode)
            {
                textBoxSummary.Visible = false;
                textBoxLogs.Visible = true;
                buttonStop.Visible = true;
                TestLogger.logMessages.Clear();
                TestLogger.eventLogs.Clear();
                textBoxLogs.Clear();
                buttonStartEnabled.Visible = false;
                treeViewTestCases.Enabled = false;

                if (buttonSelectAllEnabled.Visible)
                {
                    buttonSelectAllDisabled.Visible = true;
                    buttonSelectAllEnabled.Visible = false;
                }
                if (buttonDeselectAllEnabled.Visible)
                {
                    buttonDeselectAllDisabled.Visible = true;
                    buttonDeselectAllEnabled.Visible = false;
                }

            }
            else
            {
                textBoxSummary.Visible = true;
                textBoxLogs.Visible = false;
                buttonStop.Visible = false;
                buttonStartEnabled.Visible = false;
                TestLogger.logMessages.Clear();
                TestLogger.eventLogs.Clear();
                textBoxSummary.Clear();
                textBoxSummary.Text = "No test case selected";
                textBoxSummary.AppendText(Environment.NewLine + " ");
                textBoxSummary.AppendText(Environment.NewLine + "Select a test case. . .");
            }
        }


        //task to display event logs in real time
        public void StartDisplayingLogs()
        {
            Task.Run(() =>
            {
                while (true)
                {
                    if (TestLogger.eventLogs.TryDequeue(out var logMessage))
                    {
                        textBoxLogs.AppendText(Environment.NewLine + logMessage.ToString());
                    }
                    else
                    {
                        Thread.Sleep(100);
                    }
                }
            });
        }


        public void EndOfProcess()
        {
            //Stop all chromedrivers
            Process[] chromeDriverProcesses = Process.GetProcessesByName("chromedriver");
            foreach (Process process in chromeDriverProcesses)
            {
                process.Kill();
            }

            buttonStartEnabled.Visible = false;
            buttonStartDisabled.Visible = true;
            buttonStop.Visible = false;
            treeViewTestCases.Enabled = true;
            buttonSelectAllEnabled.Visible = true;
            buttonSelectAllDisabled.Visible = false;
            buttonDeselectAllDisabled.Visible = false;
            buttonDeselectAllEnabled.Visible = false;



        }

        public void StopProcess()
        {
            buttonStop.Visible = false;
            buttonStartDisabled.Visible = true;
            cancellationTokenSource?.Cancel();



            Process[] chromeDriverProcesses = Process.GetProcessesByName("chromedriver");
            foreach (Process process in chromeDriverProcesses)
            {
                process.Kill();
            }

            Thread.Sleep(5000);
            buttonStartEnabled.Cursor = Cursors.Default;
            treeViewTestCases.Enabled = true;
            textBoxSummary.Visible = true;
            textBoxLogs.Visible = false;
            textBoxSummary.Clear();
            textBoxSummary.Text = "Select a test case. . .";
            foreach (TreeNode node in treeViewTestCases.Nodes)
            {
                node.Checked = false;

                foreach (TreeNode childNode in node.Nodes)
                {
                    childNode.Checked = false;
                }
            }
            buttonSelectAllEnabled.Visible = true;
            buttonSelectAllDisabled.Visible = false;
            buttonDeselectAllDisabled.Visible = false;
            buttonDeselectAllEnabled.Visible = false;
        }

        public bool IsRunningProcess()
        {
            Process[] processes = Process.GetProcesses();

            foreach (Process process in processes)
            {
                if (process.ProcessName == "chromedriver")
                {
                    return true;
                }
            }

            return false;
        }

/*
* *******************************FRONTEND METHODS*********************************************
*/
        private void textBoxLogs_TextChanged(object sender, EventArgs e)
        {
            if (textBoxLogs.TextLength > textBoxLogs.ClientSize.Height)
            {

                textBoxLogs.ScrollBars = ScrollBars.Vertical;
            }
            else
            {
                textBoxLogs.ScrollBars = ScrollBars.None;
            }
        }


        private async void treeViewTestCases_AfterSelect(object sender, TreeViewEventArgs e)
        {


            bool hasCheckedNode = false;

            foreach (TreeNode node in treeViewTestCases.Nodes)
            {
                foreach (TreeNode childNode in node.Nodes)
                {
                    foreach (TreeNode grandChildNode in childNode.Nodes)
                    {

                        if (grandChildNode.Checked)
                        {
                            hasCheckedNode = true;
                            break;
                        }

                    }

                }
                if (hasCheckedNode)
                {
                    break;
                }

            }

            if (hasCheckedNode)
            {
                buttonStartEnabled.Visible = true;
                buttonStartDisabled.Visible = false;
            }
            else
            {
                buttonStartEnabled.Visible = false;
                buttonStartDisabled.Visible = true;
            }
             

            //checks all parent node if all child node are checked and check all childnode if parent node is checked
            if (e.Action != TreeViewAction.Unknown)
            {
                int siblingCount = 0;
                int siblingChecked = 0;
                Stack<TreeNode> stack = new Stack<TreeNode>();
                stack.Push(e.Node);
                while (stack.Count > 0)
                {
                    TreeNode node = stack.Pop();

                    if (node.Nodes.Count > 0)
                    {
                        foreach (TreeNode childNode in node.Nodes)
                        {
                            childNode.Checked = node.Checked;
                            stack.Push(childNode);
                           
                        }

                    }

                   

                    if (node.Parent != null)
                    {
                        bool allChecked = true;
                        
                        foreach (TreeNode siblingNode in node.Parent.Nodes)
                        {
                                if (!siblingNode.Checked)
                                {
                                    allChecked = false;
                                    break;
                                }    
                                 
                        }
                        node.Parent.Checked = allChecked;

                    }   
                    ;
                }

                int parentCount = 0;
                int checkCount = 0;


                foreach(TreeNode nodes in treeViewTestCases.Nodes)
                {
                    
                    foreach(TreeNode childNode in nodes.Nodes)
                    {
                        siblingCount++;
                        if (childNode.Checked)
                        {
                            siblingChecked++;
                        }
                    }
                    if(siblingChecked == siblingCount)
                    {
                        nodes.Checked = true;
                    }
                    else
                    {
                        nodes.Checked = false;
                    }
                    siblingChecked = 0;
                    siblingCount = 0;
                }


                // If the node is checked, increment the count
                foreach (TreeNode parentNode in treeViewTestCases.Nodes)
                {
                    parentCount++;

                    if (parentNode.Checked)
                    {
                        checkCount++;
                    }

                }





                if (parentCount == checkCount)
                {
                    buttonSelectAllEnabled.Visible = false;
                    buttonDeselectAllEnabled.Visible = true;
                }
                else
                {
                    buttonSelectAllEnabled.Visible = true;
                    buttonDeselectAllEnabled.Visible = false;
                }
            }
           
        }

        private void MainPage_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (IsRunningProcess())
            {
                DialogResult hasProcess = MessageBox.Show("Do you want to stop the test execution and exit?", "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (hasProcess == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else
                {
                    StopProcess();
                }
            }

        }

        private void buttonSelectAllEnabled_Click(object sender, EventArgs e)
        {
            buttonSelectAllEnabled.Visible = false;
            buttonDeselectAllEnabled.Visible = true;


                foreach (TreeNode node in treeViewTestCases.Nodes)
                {
                    node.Checked = true;

                    foreach (TreeNode childNode in node.Nodes)
                    {
                        childNode.Checked = true;
                        foreach (TreeNode grandChildNode in childNode.Nodes)
                        {
                            grandChildNode.Checked = true;
                        }

                    }
                }

        }

        private void buttonSelectAllDisabled_Click(object sender, EventArgs e)
        {
           
        }

        private void buttonDeselectAllEnabled_Click(object sender, EventArgs e)
        {
            buttonSelectAllEnabled.Visible = true;
            buttonDeselectAllEnabled.Visible = false;

            foreach (TreeNode node in treeViewTestCases.Nodes)
            {
                node.Checked = false;

                foreach (TreeNode childNode in node.Nodes)
                {
                    childNode.Checked = false;
                    foreach(TreeNode grandChildNode in childNode.Nodes)
                    {
                        grandChildNode.Checked = false;
                    }
                    
                }
            }
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to stop the test execution?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                StopProcess();
            }
            else
            {

            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            SettingsForm showSettings = new();
            showSettings.ShowDialog();

        }

        public void GetConfig()
        {
            cancellationTokenSource = new CancellationTokenSource();
            string maxParallel = ConfigurationManager.AppSettings["maxParallel"];
            MaxParallel = Convert.ToInt32(maxParallel);
        }
    }
}