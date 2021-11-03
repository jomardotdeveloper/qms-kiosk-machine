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


namespace KioskQMS
{
    public partial class FormServices : Form
    {
        private Transaction Transaction;
        private MainForm Form;
        /* TO HANDLE THE SSL CERTIFICATE ISSUE WITH THE API, WILL REMOVE UPON DEPLOYING THE REST API */
        private HttpClientHandler Handler;
        private HttpClient Client;

        public FormServices(Transaction transaction, MainForm form)
        {
            InitializeComponent();
            this.Transaction = transaction;
            this.Form = form;
        }

        //eku balu nung nanung alako ku kening from services hahaha

        private void FormServices_Load(object sender, EventArgs e)
        {

        }

        private void btnDeposit_Click_1(object sender, EventArgs e)
        {
            this.Transaction.ServiceID = 1;
            LoadWindow();
        }

        private void btnWithdraw_Click_1(object sender, EventArgs e)
        {
            this.Transaction.ServiceID = 2;
            LoadWindow();
        }

        private void btnCheckout_Click_1(object sender, EventArgs e)
        {
            this.Transaction.ServiceID = 3;
            LoadWindow();
        }

        private void btnCheckEncashment_Click_1(object sender, EventArgs e)
        {
            this.Transaction.ServiceID = 4;
            LoadWindow();
        }

        private void btnBill_Click_1(object sender, EventArgs e)
        {
            this.Transaction.ServiceID = 5;
            LoadWindow();
        }

        private void btnLoan_Click_1(object sender, EventArgs e)
        {
            this.Transaction.ServiceID = 6;
            LoadWindow();
        }

        private void btnTime_Click_1(object sender, EventArgs e)
        {
            this.Transaction.ServiceID = 7;
            LoadWindow();
        }

        private void btnBack_Click_1(object sender, EventArgs e)
        {
            this.Form.OpenForm(new FormCustomerType(this.Transaction, this.Form));
        }

        private void LoadWindow()
        {
            this.Handler = new HttpClientHandler()
            {
                ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
            };

            this.Client = new HttpClient(this.Handler);
            this.Client.BaseAddress = new Uri(Endpoints.BaseUrl);

            try
            {
                string isPrio = this.Transaction.IsPriority ? "1" : "0";
                string param = this.Transaction.BranchID.ToString() + "/" + this.Transaction.ServiceID + "/" + isPrio;
                var response = this.Client.GetAsync(Endpoints.WindowUrl + param).Result;
                JObject json = JObject.Parse(response.Content.ReadAsStringAsync().Result);

                if(json["status"].ToString() == "1")
                {
                    this.Transaction.WindowID = Convert.ToInt32(json["window_id"]);
                    this.Transaction.ProfileID = Convert.ToInt32(json["profile_id"]);

                    if(this.Transaction.ServiceID == 1)
                    {
                        this.Form.OpenForm(new FormDeposit(this.Transaction, this.Form));
                    }
                    else
                    {
                        this.Transaction.Amount = null;
                        this.Form.OpenForm(new FormSMS(this.Transaction, this.Form));
                    }
                    
                }
                else
                {
                    MessageBox.Show(json["message"].ToString());
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("There is a problem with the server.");
            }
        }
    }
}
