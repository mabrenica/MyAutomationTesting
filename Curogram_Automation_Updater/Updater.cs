using System.Net;
using System.IO;
using System.Diagnostics;
using System.IO.Compression;

namespace Curogram_Automation_Updater
{
    public partial class Updater : Form
    {
        public Updater()
        {
            InitializeComponent();

            WebClient webclient = new();
            var client = new WebClient();

            try
            {
                System.Threading.Thread.Sleep(5000);
                string directoryPath = @".\";
                string[] files = Directory.GetFiles(directoryPath);
                string[] directories = Directory.GetDirectories(directoryPath);
                foreach (string file in files)
                {
                    if (!Path.GetFileName(file).Contains("Curogram_Automation_Updater"))
                    {
                        File.Delete(file);
                    }
                }
                foreach (string directory in directories)
                {
                    Directory.Delete(directory, true);
                }

                client.DownloadFile("http://qa-curogram.6te.net/Curogram/Curogram_Automation.zip", "Curogram_Automation.zip");
                string zipPath = @".\Curogram_Automation.zip";
                string extractPath = @".\";
                ZipFile.ExtractToDirectory(zipPath, extractPath);
                File.Delete(@".\Curogram_Automation.zip");
               

                if (MessageBox.Show("Successfully updated", "Curogram Automation", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    Process.Start(@".\UI_V2.exe");
                    this.Close();
                }

            }
            catch (Exception ex) 
            {
                Process.Start("UI_V2.exe");
                MessageBox.Show(ex.ToString(), "Curogram Automation Updater", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            } 
        }
    }
}