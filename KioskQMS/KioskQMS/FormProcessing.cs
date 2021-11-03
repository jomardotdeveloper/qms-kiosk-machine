using KioskQMS.Kiosk;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Formatting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Threading;

namespace KioskQMS
{
    public partial class FormProcessing : Form
    {
        private Transaction Transaction;
        private MainForm Form;
        /* TO HANDLE THE SSL CERTIFICATE ISSUE WITH THE API, WILL REMOVE UPON DEPLOYING THE REST API */
        private HttpClientHandler Handler;
        private HttpClient Client;
        private Thread MyThread;
        private bool Flag = true;
        private bool IsSuccess;
        private JArray Arr;
        private bool IsDone = false;

        public FormProcessing(Transaction transaction, MainForm form)
        {
            InitializeComponent();
            this.Transaction = transaction;
            this.Form = form;
            timer1.Enabled = true;
            timer1.Start();
            timer1.Interval = 1000;
            progressBar1.Maximum = 10;
            timer1.Tick += new EventHandler(timer1_Tick);
            this.MyThread = new Thread(CreateToken);
            this.IsSuccess = false;
            this.IsDone = false;
            this.MyThread.Start();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value != 10)
            {
                progressBar1.Value+=2;
            }
            else
            {
                if (Global.IsSuccess)
                {
                    //this.Form.OpenForm(new FormTicket(this.Form, this.Transaction, this.Arr));
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Operation failed:There is a problem creating new token. Please contact your system administrator.");
                    this.Hide();
                }
                Global.Reset();
                timer1.Stop();
            }
        }

        private void CreateToken()
        {
            this.Handler = new HttpClientHandler()
            {
                ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
            };

            this.Client = new HttpClient(this.Handler);
            this.Client.BaseAddress = new Uri(Endpoints.BaseUrl);

            var response = this.Client.PostAsJsonAsync(Endpoints.TransactionUrl, this.Transaction).Result;
            JObject json = JObject.Parse(response.Content.ReadAsStringAsync().Result);

            if (json["status"].ToString() == "1")
            {
                Global.IsSuccess = true;
                JArray tokenData = JArray.FromObject(json["Token"]);
                this.Arr = tokenData;   
            }
            else
            {
                Global.IsSuccess = false;
            }

            Global.IsDone = true;
        }


    }
}
