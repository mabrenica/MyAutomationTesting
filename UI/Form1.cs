using Curogram_Automation_Testing.AutomationTestScripts.CurogramWebApp.ProviderLoginPage;
using Curogram_Automation_Testing.AutomationTestScripts.CurogramWebApp.AddUsers;
using Curogram_Automation_Testing.AutomationTestScripts.CurogramWebApp.Users.ResetProviderPassword;
using Curogram_Automation_Testing.AutomationTestScripts.CurogramWebApp.Telemedicine;
using Curogram_Automation_Testing.AutomationTestScripts.CurogramAdmin;
using Curogram_Automation_Testing.appManager;
using System.Windows.Forms;

namespace UI
{
    public partial class Form1 : Form
    {
        Dictionary<int, Tuple<Action, string>> testMethods = new();

        public Form1()
        {
            InitializeComponent();
        }
        public void PlaceHolder()
        {
        }
        private void Form1_Load(object sender, EventArgs e)
        {



            ProviderLogin t1 = new();
            AddUserTest t2 = new();
            ResetProviderPassword t3 = new();
            CpAdminLoginTest t4 = new();
            Telemed1 t5 = new();
            TelemedPublicReg t6 = new();



            testMethods.Add(1, Tuple.Create(new Action(t1.ProviderLoginTest), "Provider Login Test"));
            testMethods.Add(2, Tuple.Create(new Action(t2.addUser), "Add User Test"));
            testMethods.Add(3, Tuple.Create(new Action(t3.ResetUserPassword), "Reset User Password Test"));
            testMethods.Add(4, Tuple.Create(new Action(t4.CpAdminLogin), "CP Admin Login Test"));
            testMethods.Add(5, Tuple.Create(new Action(t5.Telemed), "Instant Telemedicine Test"));
            testMethods.Add(6, Tuple.Create(new Action(t6.TelePubReg), "Telemedicine Public Registration"));





            testCasesList.Items.Clear();
            foreach (var item in testMethods)
            {
                string displayText = $"{item.Key}: {item.Value.Item2}";
                testCasesList.Items.Add(displayText);
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            List<string> logList = new();



            logsDisplay.Clear();
            runButton.Enabled = false;
            testCasesList.Enabled = false;
            selectAll.Enabled = false;



            List<Action> selectedTests = new List<Action>();
            int maxParallelTasks = 4;
            foreach (var item in testCasesList.Items)
            {
                if (testCasesList.GetItemChecked(testCasesList.Items.IndexOf(item)))
                {
                    int key = int.Parse(item.ToString().Split(':')[0]);
                    Action testMethod = testMethods[key].Item1;
                    selectedTests.Add(testMethod);
                }
            }
            try
            {
                await Task.Run(() => Parallel.ForEach(selectedTests, new ParallelOptions { MaxDegreeOfParallelism = maxParallelTasks }, testMethod => testMethod()));
            }
            catch (Exception ex)
            {
                var message = "Error encountered in test execution";
                TestLogger.Logger(message);
            }
            runButton.Enabled = true;
            testCasesList.Enabled = true;
            selectAll.Enabled = true;
            selectAll.Checked = false;

            for (int i = 0; i < testCasesList.Items.Count; i++)
            {
                testCasesList.SetItemChecked(i, false);
            }



            foreach (var log in TestLogger.logMessages)
            {
                if (TestLogger.logMessages.Count < 1)
                {
                    logsDisplay.Text = log.ToString();
                }
                logsDisplay.AppendText(Environment.NewLine + log.ToString());
            }


            int passCount = 0;
            int failCount = 0;

            foreach (string logMessage in TestLogger.logMessages)
            {
                if (logMessage.Contains("Pass"))
                {
                    passCount++;
                }
                else if (logMessage.Contains("Fail"))
                {
                    failCount++;
                }
            }

            logsDisplay.AppendText(Environment.NewLine + "---------------- TEST SUMMARY --------------------");
            logsDisplay.AppendText(Environment.NewLine + $"Total Tests: {passCount + failCount}");
            logsDisplay.AppendText(Environment.NewLine + $"Passed Tests: {passCount}");
            logsDisplay.AppendText(Environment.NewLine + $"Failed Tests: {failCount}");

        }

        private void selectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (selectAll.Checked)
            {
                // Check all the items in the CheckedListBox
                for (int i = 0; i < testCasesList.Items.Count; i++)
                {
                    testCasesList.SetItemChecked(i, true);
                }
            }
            else
            {
                // Uncheck all the items in the CheckedListBox
                for (int i = 0; i < testCasesList.Items.Count; i++)
                {
                    testCasesList.SetItemChecked(i, false);
                }
            }
        }

        private void testCasesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (testMethods.Count == testCasesList.CheckedItems.Count)
            {
                selectAll.Checked = true;
            }
            else
            {
                selectAll.Checked = false;
            }
        }
    }

}