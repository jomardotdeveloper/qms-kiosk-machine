using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Formatting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using KioskQMS.Kiosk;

namespace KioskQMS
{
    public partial class FormKey : Form
    {
        /* TO HANDLE THE SSL CERTIFICATE ISSUE WITH THE API, WILL REMOVE UPON DEPLOYING THE REST API */
        private HttpClientHandler Handler;
        private HttpClient Client;
        string FilePath;

        public FormKey()
        {
            InitializeComponent();

            var projectPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            this.FilePath = Path.Combine(projectPath, "Resources");

            if (!File.Exists(this.FilePath + @"\config.txt"))
            {
                FileStream fs = File.Create(this.FilePath + @"\config.txt");
            }

        }

        public bool IsInstalled()
        {
            return new FileInfo(this.FilePath + @"\config.txt").Length != 0;
        }

        private void WriteFile()
        {
            this.Handler = new HttpClientHandler()
            {
                ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
            };

            this.Client = new HttpClient(this.Handler);
            this.Client.BaseAddress = new Uri(Endpoints.BaseUrl);
            try
            {
                string param = this.txtProductKey.Text;
                var response = this.Client.GetAsync(Endpoints.BranchUrl + param).Result;
                JObject json = JObject.Parse(response.Content.ReadAsStringAsync().Result);

                if (Convert.ToInt32(json["success"]) != 1)
                {
                    MessageBox.Show(json["message"].ToString());
                }
                else
                {
                    String line = "branch_id=" + json["id"].ToString();

                    StreamWriter sw = new StreamWriter(this.FilePath + @"\config.txt");
                    sw.WriteLine(line);
                    MessageBox.Show("Your kiosk has been succesfuly installed.");
                    sw.Close();
                    var mainForm = new MainForm();
                    mainForm.Show();
                    this.Hide();
                }
            }
            catch(Exception e)
            {
                MessageBox.Show("There is a problem with the server.");
            }
            

        }

        private void btnInstall_Click(object sender, EventArgs e)
        {
            WriteFile();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        
    }
}
