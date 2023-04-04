using Curogram_Automation_Testing.AutomationTestScripts.CurogramWebApp.ProviderLoginPage;
using Curogram_Automation_Testing.AutomationTestScripts.CurogramWebApp.AddUsers;
using Curogram_Automation_Testing.AutomationTestScripts.CurogramWebApp.Users.ResetProviderPassword;
using Curogram_Automation_Testing.AutomationTestScripts.CurogramWebApp.Telemedicine;
using Curogram_Automation_Testing.AutomationTestScripts.CurogramAdmin;
using Curogram_Automation_Testing.appManager;
using System.Diagnostics;
using Curogram_Automation_Testing.AutomationTestScripts.CurogramWebApp.FormStack;

namespace UI
{
    public partial class Form1 : Form
    {
        Dictionary<int, Tuple<Action, string, string>> testMethods = new();
        public CancellationTokenSource cancellationTokenSource;


        public Form1()
        {
            InitializeComponent();


        }




        private void Form1_Load(object sender, EventArgs e)
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


            //Add Test cases to the list
            testMethods.Add(1, Tuple.Create(new Action(t1.ProviderLoginTest), "Provider Login Test", "CuroWeb"));
            testMethods.Add(2, Tuple.Create(new Action(t2.addUser), "Add User Test", "CuroWeb"));
            testMethods.Add(3, Tuple.Create(new Action(t3.ResetUserPassword), "Reset User Password Test", "CuroWeb"));
            testMethods.Add(4, Tuple.Create(new Action(t4.CpAdminLogin), "CP Admin Login Test", "Cp"));
            testMethods.Add(5, Tuple.Create(new Action(t5.Telemed), "Instant Telemedicine Test", "CuroWeb"));
            testMethods.Add(6, Tuple.Create(new Action(t6.TelePubReg), "Telemedicine Public Registration", "CuroWeb"));
            testMethods.Add(7, Tuple.Create(new Action(t7.DemoTest), "Demo Test - Pass Test", "Demo"));
            testMethods.Add(8, Tuple.Create(new Action(t8.DemoTest), "Demo Test 2 - Fail Test", "Demo"));
            testMethods.Add(9, Tuple.Create(new Action(t9.PatientForm), "Patient Form Test", "CuroWeb"));


            //Display test cases list

            runButtonEnabled.Visible = false;
            stopButtonEnabled.Visible = false;
            welcomeTextBox.Visible = true;
            logsDisplayBox.Visible = false;



            TestCasesTreeView.Nodes.Add("Curogram Web");
            TestCasesTreeView.Nodes.Add("Cp");
            TestCasesTreeView.Nodes.Add("Demo");
            foreach (var item in testMethods)
            {
                if (item.Value.Item3 == "CuroWeb")
                {
                    string displayText = $"{item.Value.Item2}";
                    TestCasesTreeView.Nodes[0].Nodes.Add(displayText);
                }
                if (item.Value.Item3 == "Cp")
                {
                    string displayText = $"{item.Value.Item2}";
                    TestCasesTreeView.Nodes[1].Nodes.Add(displayText);
                }
                if (item.Value.Item3 == "Demo")
                {
                    string displayText = $"{item.Value.Item2}";
                    TestCasesTreeView.Nodes[2].Nodes.Add(displayText);
                }
            }

        }






        private async void button1_Click(object sender, EventArgs e)
        {
            cancellationTokenSource = new CancellationTokenSource();

            StartProcess();

            //Add checked items to execution list
            List<Action> selectedTests = new List<Action>();
            selectedTests.Clear();
            int maxParallelTasks = 4;

            foreach (TreeNode node in TestCasesTreeView.Nodes)
            {
                foreach (TreeNode childNode in node.Nodes)
                {

                    if (childNode.Checked)
                    {
                        string searchValue = childNode.Text;
                        int key = testMethods.FirstOrDefault(x => x.Value.Item2 == searchValue).Key;
                        Action testMethod = testMethods[key].Item1;
                        selectedTests.Add(testMethod);
                    }
                }
            }



            //Execute checked items in execution list            
            try
            {
                logsDisplayBox.Text = "TEST EXECUTION IN PROGRESS . . .";
                StartDisplayingLogs();
                await Task.Run(() => Parallel.ForEach(selectedTests, new ParallelOptions { MaxDegreeOfParallelism = maxParallelTasks, CancellationToken = cancellationTokenSource.Token }, testMethod =>

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
                stopButtonEnabled.Visible = false;
                TestLogger.eventLogs.Clear();
                selectAll.Checked = false;
                foreach (TreeNode node in TestCasesTreeView.Nodes)
                {
                    node.Checked = false;

                    foreach (TreeNode childNode in node.Nodes)
                    {
                        childNode.Checked = false;
                    }
                }
            }



            //wrap up after test execution
            logsDisplayBox.Clear();
            logsDisplayBox.Text = "TEST EXECUTION COMPLETED";


            //Uncheck all test case items after text execution

            foreach (TreeNode node in TestCasesTreeView.Nodes)
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
                    logsDisplayBox.Text = log.ToString();
                }
                logsDisplayBox.AppendText(Environment.NewLine + log.ToString());
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
            logsDisplayBox.AppendText(Environment.NewLine + "-----------------------------------------------");
            logsDisplayBox.AppendText(Environment.NewLine + $"Total Tests: {passCount + failCount}");
            logsDisplayBox.AppendText(Environment.NewLine + $"Passed Tests: {passCount}");
            logsDisplayBox.AppendText(Environment.NewLine + $"Failed Tests: {failCount}");
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

            foreach (TreeNode node in TestCasesTreeView.Nodes)
            {
                foreach (TreeNode childNode in node.Nodes)
                {
                    if (childNode.Checked)
                    {
                        hasCheckedNode = true;
                        break;
                    }
                }

                if (hasCheckedNode)
                {
                    break;
                }
            }

            if (hasCheckedNode)
            {
                welcomeTextBox.Visible = false;
                logsDisplayBox.Visible = true;
                stopButtonEnabled.Visible = true;
                TestLogger.logMessages.Clear();
                TestLogger.eventLogs.Clear();
                logsDisplayBox.Clear();
                runButtonEnabled.Visible = false;
                selectAll.Enabled = false;
                TestCasesTreeView.Enabled = false;

            }
            else
            {
                welcomeTextBox.Visible = true;
                logsDisplayBox.Visible = false;
                stopButtonEnabled.Visible = false;
                runButtonEnabled.Visible = false;
                TestLogger.logMessages.Clear();
                TestLogger.eventLogs.Clear();
                welcomeTextBox.Clear();
                welcomeTextBox.Text = "No test case selected";
                welcomeTextBox.AppendText(Environment.NewLine + " ");
                welcomeTextBox.AppendText(Environment.NewLine + "Select a test case. . .");
            }
        }






        public void StopProcess()
        {
            stopButtonEnabled.Visible = false;
            cancellationTokenSource?.Cancel();
            selectAll.Checked = false;

            Process[] chromeDriverProcesses = Process.GetProcessesByName("chromedriver");
            foreach (Process process in chromeDriverProcesses)
            {
                process.Kill();
            }

            Thread.Sleep(5000);
            runButtonEnabled.Cursor = Cursors.Default;
            TestCasesTreeView.Enabled = true;
            selectAll.Enabled = true;
            welcomeTextBox.Visible = true;
            logsDisplayBox.Visible = false;
            welcomeTextBox.Clear();
            welcomeTextBox.Text = "Select a test case. . .";
            runButtonEnabled.Enabled = true;
            foreach (TreeNode node in TestCasesTreeView.Nodes)
            {
                node.Checked = false;

                foreach (TreeNode childNode in node.Nodes)
                {
                    childNode.Checked = false;
                }
            }
        }







        public void EndOfProcess()
        {
            //Stop all chromedrivers
            Process[] chromeDriverProcesses = Process.GetProcessesByName("chromedriver");
            foreach (Process process in chromeDriverProcesses)
            {
                process.Kill();
            }
            runButtonEnabled.Enabled = true;
            selectAll.Enabled = true;
            selectAll.Checked = false;
            stopButtonEnabled.Visible = false;
            TestCasesTreeView.Enabled = true;
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
                        logsDisplayBox.AppendText(Environment.NewLine + logMessage.ToString());
                    }
                    else
                    {
                        Thread.Sleep(100);
                    }
                }
            });
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


        //Log text box to show scroll bars when text exceeds the box height
        private void logsDisplayBox_TextChanged(object sender, EventArgs e)
        {
            if (logsDisplayBox.TextLength > logsDisplayBox.ClientSize.Height)
            {

                logsDisplayBox.ScrollBars = ScrollBars.Vertical;
            }
            else
            {
                logsDisplayBox.ScrollBars = ScrollBars.None;
            }
        }





        //select all check box to check all items in the list
        private void selectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (selectAll.Checked)
            {
                runButtonEnabled.Visible = true;
            }
            else
            {
                runButtonEnabled.Visible = false;
            }

            if (selectAll.Checked)
            {
                foreach (TreeNode node in TestCasesTreeView.Nodes)
                {
                    node.Checked = true;

                    foreach (TreeNode childNode in node.Nodes)
                    {
                        childNode.Checked = true;
                    }
                }
            }
            else
            {
                foreach (TreeNode node in TestCasesTreeView.Nodes)
                {
                    node.Checked = false;

                    foreach (TreeNode childNode in node.Nodes)
                    {
                        childNode.Checked = false;
                    }
                }
            }

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
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
            else
            {
                DialogResult noProcess = MessageBox.Show("Do you want to exit the application?", "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (noProcess == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else
                {

                }
            }
        }


        public void TestCasesTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //Run Button to appear when there is at least 1 child node selected
            bool hasCheckedNode = false;

            foreach (TreeNode node in TestCasesTreeView.Nodes)
            {
                foreach (TreeNode childNode in node.Nodes)
                {
                    if (childNode.Checked)
                    {
                        hasCheckedNode = true;
                        break;
                    }
                }

                if (hasCheckedNode)
                {
                    break;
                }
            }

            if (hasCheckedNode)
            {
                runButtonEnabled.Visible = true;
            }
            else
            {
                runButtonEnabled.Visible = false;
            }

            //checks all parent node if all child node are checked and check all childnode if parent node is checked
            if (e.Action != TreeViewAction.Unknown)
            {
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

                    
                }

                
            }

           

        }

    }
}
