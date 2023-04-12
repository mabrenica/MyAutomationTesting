using System.Configuration;
using Curogram_Automation_Testing.CurogramApi.Provider;


namespace SettingsModal

{
    public partial class SettingsForm : Form
    {
        public static string MaxParallel;
        public static string ExecutionEnv;
        public static string ProviderEmailStaging;
        public static string ProviderPasswordStaging;
        public static string ProviderAuthStaging;
        public SettingsForm()
        {
            InitializeComponent();
        }



        private async void SettingsForm_Load(object sender, EventArgs e)
        {
            GetConfig();
            maxParallelBox.Text = MaxParallel;
            environmentsBox.Text = ExecutionEnv;
            textBoxUserEmail.Text = ProviderEmailStaging;
            textBoxPassword.Text= ProviderPasswordStaging;
            await CheckCredentials();

        }


        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void GetConfig()
        {

            string maxParallel = ConfigurationManager.AppSettings["maxParallel"];
            string executionEnv = ConfigurationManager.AppSettings["executionEnv"];
            string providerEmailStaging = ConfigurationManager.AppSettings["providerEmailStaging"];
            string providerPasswordStaging = ConfigurationManager.AppSettings["providerPasswordStaging"];
            MaxParallel = maxParallel;
            ExecutionEnv = executionEnv;
            ProviderEmailStaging = providerEmailStaging;
            ProviderPasswordStaging = providerPasswordStaging;
        }


        private void buttonSave_Click(object sender, EventArgs e)
        {
            string boxvalue = maxParallelBox.Text;
            string environment = environmentsBox.Text;
            string providerEmailStaging = textBoxUserEmail.Text;
            string providerPasswordStaging = textBoxPassword.Text;




            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["maxParallel"].Value = boxvalue;
            config.AppSettings.Settings["executionEnv"].Value = environment;
            config.AppSettings.Settings["providerEmailStaging"].Value = providerEmailStaging;
            config.AppSettings.Settings["providerPasswordStaging"].Value = providerPasswordStaging;
            config.AppSettings.Settings["providerAuthTokenStaging"].Value = ProviderAuthStaging;


            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
            this.Close();
        }

        private void buttonDefault1_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure you want to reset the settings?", "Reset Settings", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string defaultMaxParallel = "4";
                string defaultExecutionEnv = "Staging";


                maxParallelBox.Text = defaultMaxParallel;
                environmentsBox.Text = defaultExecutionEnv;





                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings["maxParallel"].Value = defaultMaxParallel;
                config.AppSettings.Settings["executionEnv"].Value = defaultExecutionEnv;
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            };
        }

        public async Task CheckCredentials()
        {

            string providerEmailStaging = textBoxUserEmail.Text;
            string providerPasswordStaging = textBoxPassword.Text;
            ProviderLoginApi a = new();
            await a.GetToken(providerEmailStaging, providerPasswordStaging);
            string result = a.ReturnString();
            
            if (result == null) 
            {

                labelCheckCredentials.ForeColor = Color.Red;
                labelCheckCredentials.Text = "Invalid Credentials";
            }
            else
            {
                labelCheckCredentials.ForeColor = Color.Green;
                labelCheckCredentials.Text = "Valid Credentials";
                ProviderAuthStaging= result;
            }
        }

        public async void button1_Click(object sender, EventArgs e)
        {
            labelCheckCredentials.ForeColor = Color.Gray;
            labelCheckCredentials.Text = "Checking . . .";
            await CheckCredentials();

        }

        private void buttonResetStaging_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to reset the settings?", "Reset Settings", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                textBoxPassword.Text = "password1";
                textBoxUserEmail.Text = "testrigorcpuser@curogram.com";
            }
        }
    }
}