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
    public partial class FormFeedback : Form
    {
        private MainForm Form;
        private Transaction Transaction;
        private int CountStars;
        /* TO HANDLE THE SSL CERTIFICATE ISSUE WITH THE API, WILL REMOVE UPON DEPLOYING THE REST API */
        private HttpClientHandler Handler;
        private HttpClient Client;
        public FormFeedback(MainForm form, Transaction transaction)
        {
            InitializeComponent();
            this.Transaction = transaction;
            this.Form = form;
        }
        private void btn1_Click(object sender, EventArgs e)
        {
            this.CountStars = 1;
            Proceed();
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            this.CountStars = 2;
            Proceed();
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            this.CountStars = 3;
            Proceed();
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            this.CountStars = 4;
            Proceed();
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            this.CountStars = 5;
            Proceed();
        }
        
        private void Proceed()
        {
            this.Handler = new HttpClientHandler()
            {
                ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
            };

            this.Client = new HttpClient(this.Handler);
            this.Client.BaseAddress = new Uri(Endpoints.BaseUrl);

            IDictionary<string, string> MyFeedback = new Dictionary<string, string>();
            MyFeedback.Add("Transaction",  this.Transaction.ID.ToString());
            MyFeedback.Add("Stars", this.CountStars.ToString());

            //var response = this.Client.PostAsJsonAsync(Endpoints.FeedbackUrl, MyFeedback).Result;
            //JObject json = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            //if (json["status"].ToString() == "1")
            //{
            //    this.Form.OpenForm(new FormStartScreen(this.Form));
            //}
        }

       
    }
}
