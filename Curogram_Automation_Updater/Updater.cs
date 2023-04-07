using System.Net;
using System.IO;
using System.Diagnostics;
using System.IO.Compression;
using UI_V2;

namespace Curogram_Automation_Updater
{
    public partial class Updater : Form
    {
        public static string AvailableVersion;
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
                try
                {
                    string capturedVersion = webclient.DownloadString("https://pastebin.com/raw/20irZKm8");
                    AvailableVersion = capturedVersion;

                }
                catch { }

                try
                {
                    client.DownloadFile($"http://qa-curogram.6te.net/Curogram/{AvailableVersion}.zip", $"{AvailableVersion}.zip");
                }
                catch 
                {

                    MessageBox.Show("Error in downloading update.", "Curogram Automation Updater", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Process.Start("Curogram_Automation_UI.exe");
                    this.Close();

                }
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


                string zipPath = $@".\{AvailableVersion}.zip";
                string extractPath = @".\";
                ZipFile.ExtractToDirectory(zipPath, extractPath);
                File.Delete($@".\{AvailableVersion}.zip");

                MessageBox.Show("Successfully updated", "Curogram Automation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Process.Start(@".\Curogram_Automation_UI.exe");
                this.Close();
                

            }
            catch (Exception ex) 
            {

                MessageBox.Show(ex.ToString(), "Curogram Automation Updater", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Process.Start("Curogram_Automation_UI.exe");
                this.Close();
            } 
        }
    }
}