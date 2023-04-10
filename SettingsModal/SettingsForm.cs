using System.Configuration;



namespace SettingsModal

{
    public partial class SettingsForm : Form
    {
        public static string MaxParallel;
        public static string ExecutionEnv;
        public SettingsForm()
        {
            InitializeComponent();
        }



        private void SettingsForm_Load(object sender, EventArgs e)
        {
            GetConfig();
            maxParallelBox.Text = MaxParallel;
            environmentsBox.Text = ExecutionEnv;
        }


        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void GetConfig()
        {

            string maxParallel = ConfigurationManager.AppSettings["maxParallel"];
            string executionEnv = ConfigurationManager.AppSettings["executionEnv"];
            MaxParallel = maxParallel;
            ExecutionEnv = executionEnv;
        }


        private void buttonSave_Click(object sender, EventArgs e)
        {
            string boxvalue = maxParallelBox.Text;
            string environment = environmentsBox.Text;




            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["maxParallel"].Value = boxvalue;
            config.AppSettings.Settings["executionEnv"].Value = environment;


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
    }
}