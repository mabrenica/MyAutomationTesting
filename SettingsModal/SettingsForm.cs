using System.Configuration;



namespace SettingsModal

{
    public partial class SettingsForm : Form
    {
        public static string MaxParallel;
        public SettingsForm()
        {
            InitializeComponent();
        }



        private void SettingsForm_Load(object sender, EventArgs e)
        {
            GetConfig();
            maxParallelBox.Text = MaxParallel;
        }


        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void GetConfig()
        {

            string maxParallel = ConfigurationManager.AppSettings["maxParallel"];
            MaxParallel = maxParallel;
        }


        private void buttonSave_Click(object sender, EventArgs e)
        {
            string boxvalue = maxParallelBox.Text;
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["maxParallel"].Value = boxvalue;
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
            this.Close();
        }
    }
}