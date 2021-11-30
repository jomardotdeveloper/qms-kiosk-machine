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
using WebSocketSharp;

namespace KioskQMS
{
    public partial class FormTicket : Form
    {
        private MainForm Form;
        private Transaction Transaction;
        /* TO HANDLE THE SSL CERTIFICATE ISSUE WITH THE API, WILL REMOVE UPON DEPLOYING THE REST API */
        private HttpClientHandler Handler;
        private HttpClient Client;
        private string ID;
        private JArray Arr;
        //WEB SOCKET
        private WebSocket WbClient;
        const string host = "ws://74.63.204.84:8090";


        public FormTicket(MainForm form, Transaction transaction)
        {
            InitializeComponent();
            lblNumber.Visible = false;
            this.Form = form;
            this.Transaction = transaction;
            this.WbClient = new WebSocket(host);
            this.WbClient.Connect();
            LoadToken();
        }
        private void btnProceed_Click_1(object sender, EventArgs e)
        {
            TokenPrinter Printer = new TokenPrinter(this.lblToken.Text, this.lblService.Text, this.lblNumber.Text, this.ID, this.lblDate.Text);
            Printer.Print();
            this.Form.OpenForm(new FormStartScreen(this.Form));
            //this.Form.OpenForm(new FormFeedback(this.Form, this.Transaction));
        }
    

        private void LoadToken()
        {

            this.lblToken.Text = this.Transaction.Token;
            this.lblService.Text = GetServiceName(this.Transaction.ServiceID);
            this.lblId.Text = "ref. no: " + this.Transaction.ID.ToString();
            this.lblDate.Text = this.Transaction.Date;
            this.ID = this.Transaction.ID.ToString();

            if (this.WbClient.IsAlive)
            {
                IDictionary<string, string> dict = new Dictionary<string, string>();
                dict.Add("message", "newCustomer");

                string message = JsonConvert.SerializeObject(dict).ToString();
                this.WbClient.Send(message);
            }
        }

        private void Exit()
        {
            this.Form.OpenForm(new FormStartScreen(this.Form));
        }

        private string GetServiceName(int id)
        {
            string name = "";
            switch (id)
            {
                case 1:
                    // code block
                    name = "Cash Deposit";
                    break;
                case 2:
                    // code block
                    name = "Cash Withdrawal";
                    break;
                case 3:
                    // code block
                    name = "Checkout";
                    break;
                case 4:
                    // code block
                    name = "Cash Encashment";
                    break;
                case 5:
                    name = "Bills Payment";
                    // code block
                    break;
                case 6:
                    name = "Loan Transaction / Application / Inquiry";
                    // code block
                    break;
                case 7:
                    name = "Time Deposit Transaction";
                    // code block
                    break;
            }
            return name;
        }

        private bool IsCutOff()
        {
            //////string param = "?id=" + this.Transaction.Branch.ToString();
            ////var response = this.Client.GetAsync(Endpoints.CutoffUrl + param).Result;
            ////JObject json = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            ////DateTime dateNow = DateTime.Now;

            //if (json["is_cut_off"].ToString() == "1")
            //{
            //    return true;
            //}

            //if (dateNow.DayOfWeek == DayOfWeek.Monday)
            //{
            //    if (String.IsNullOrWhiteSpace(json["monday"].ToString()))
            //    {
            //        return false;
            //    }
            //    else
            //    {
            //        return TimeIsGreaterThan(json["monday"].ToString());
            //    }
            //}
            //else if(dateNow.DayOfWeek == DayOfWeek.Tuesday)
            //{
            //    if (String.IsNullOrWhiteSpace(json["tuesday"].ToString()))
            //    {
            //        return false;
            //    }
            //    else
            //    {
            //        return TimeIsGreaterThan(json["tuesday"].ToString());
            //    }
            //}
            //else if (dateNow.DayOfWeek == DayOfWeek.Wednesday)
            //{
            //    if (String.IsNullOrWhiteSpace(json["wednesday"].ToString()))
            //    {
            //        return false;
            //    }
            //    else
            //    {
            //        return TimeIsGreaterThan(json["wednesday"].ToString());
            //    }
            //}
            //else if (dateNow.DayOfWeek == DayOfWeek.Thursday)
            //{
            //    if (String.IsNullOrWhiteSpace(json["thursday"].ToString()))
            //    {
            //        return false;
            //    }
            //    else
            //    {
            //        return TimeIsGreaterThan(json["thursday"].ToString());
            //    }
            //}
            //else if (dateNow.DayOfWeek == DayOfWeek.Friday)
            //{
            //    if (String.IsNullOrWhiteSpace(json["friday"].ToString()))
            //    {
            //        return false;
            //    }
            //    else
            //    {
            //        return TimeIsGreaterThan(json["friday"].ToString());
            //    }
            //}
            //else if (dateNow.DayOfWeek == DayOfWeek.Saturday)
            //{
            //    if (String.IsNullOrWhiteSpace(json["saturday"].ToString()))
            //    {
            //        return false;
            //    }
            //    else
            //    {
            //        return TimeIsGreaterThan(json["saturday"].ToString());
            //    }
            //}
            //else if (dateNow.DayOfWeek == DayOfWeek.Sunday)
            //{
            //    if (String.IsNullOrWhiteSpace(json["sunday"].ToString()))
            //    {
            //        return false;
            //    }
            //    else
            //    {
            //        return TimeIsGreaterThan(json["sunday"].ToString());
            //    }
            //}

            
            return false;
            
        }

        private bool TimeIsGreaterThan(string time)
        {
            if (!time.Contains(":"))
                return false;

            string[] splitted_time = time.Split(':');
            int hour = Convert.ToInt32(splitted_time[0]);
            int minute = Convert.ToInt32(splitted_time[1]);


            DateTime now = DateTime.Now;


            if(now.Hour > hour)
            {
                return true;
            }else if(now.Hour == hour)
            {
                if(now.Minute > minute)
                {
                    return true;
                }
            }
            

            return false;
        }

        private int GetAvailableWindow()
        {
            //string param = "?branch_id=" + this.Transaction.Branch.ToString() + "&&service_id=" + this.Transaction.Service.ToString();
            //var response = this.Client.GetAsync(Endpoints.WindowUrl + param).Result;
            //JObject json = JObject.Parse(response.Content.ReadAsStringAsync().Result);

            //if (json["count"].ToString() == "-1")
            //    return -1;

            //return Convert.ToInt32(json["windows_id"]);
            return 0;
        }

        private int GetServiceProvider(int windows)
        {
            //string param = "?id=" + windows.ToString();
            //var response = this.Client.GetAsync(Endpoints.ServiceProviderUrl + param).Result;
            //JObject json = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            //return Convert.ToInt32(json["service_provider_id"]);
            return 0;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void lblDate_Click(object sender, EventArgs e)
        {

        }

        private void lblId_Click(object sender, EventArgs e)
        {

        }

        private void lblNumber_Click(object sender, EventArgs e)
        {

        }

        private void lblService_Click(object sender, EventArgs e)
        {

        }

        private void lblToken_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblNumber_Click_1(object sender, EventArgs e)
        {

        }
    }
}
