using KioskQMS.Kiosk;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Formatting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebSocketSharp;

namespace KioskQMS
{
    public partial class FormStartScreen : Form
    {
        private Transaction Transaction;
        private MainForm Form;
        /* TO HANDLE THE SSL CERTIFICATE ISSUE WITH THE API, WILL REMOVE UPON DEPLOYING THE REST API */
        private HttpClientHandler Handler;
        private HttpClient Client;
        public FormStartScreen(MainForm form)
        {
            InitializeComponent();
            this.Transaction = new Transaction();
            this.Transaction.BranchID = GetBranchID();
            this.Form = form;
            Global.Reset();
            this.Handler = new HttpClientHandler()
            {
                ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
            };

            this.Client = new HttpClient(this.Handler);
            this.Client.BaseAddress = new Uri(Endpoints.BaseUrl);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            IsCutOff();
            
            
        }

        private int GetBranchID()
        {
            var projectPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string FilePath = Path.Combine(projectPath, "Resources");

            String line;
            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader(FilePath + @"\config.txt");
                //Read the first line of text
                line = sr.ReadLine();

                string[] branch_id = line.Split('=');

                return Convert.ToInt32(branch_id[1]);
                //close the file
                sr.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Exception: " + e.Message);
            }
            return 0;
        }

        private bool IsCutOff()
        {
            try
            {
                string param = this.Transaction.BranchID.ToString();
                var response = this.Client.GetAsync(Endpoints.CutoffUrl + param).Result;
                JObject json = JObject.Parse(response.Content.ReadAsStringAsync().Result);
                DateTime dateNow = DateTime.Now;


                if (json["data"]["is_cutoff"].ToString() == "1")
                {
                    return true;
                }


                if (dateNow.DayOfWeek == DayOfWeek.Monday)
                {
                    if (String.IsNullOrWhiteSpace(json["data"]["m"].ToString()))
                    {
                        return false;
                    }
                    else
                    {
                        return TimeIsGreaterThan(json["data"]["m"].ToString());
                    }
                }
                else if (dateNow.DayOfWeek == DayOfWeek.Tuesday)
                {
                    if (String.IsNullOrWhiteSpace(json["data"]["t"].ToString()))
                    {
                        return false;
                    }
                    else
                    {
                        return TimeIsGreaterThan(json["data"]["t"].ToString());
                    }
                }
                else if (dateNow.DayOfWeek == DayOfWeek.Wednesday)
                {
                    if (String.IsNullOrWhiteSpace(json["data"]["w"].ToString()))
                    {
                        return false;
                    }
                    else
                    {
                        return TimeIsGreaterThan(json["data"]["w"].ToString());
                    }
                }
                else if (dateNow.DayOfWeek == DayOfWeek.Thursday)
                {
                    if (String.IsNullOrWhiteSpace(json["data"]["th"].ToString()))
                    {
                        return false;
                    }
                    else
                    {
                        return TimeIsGreaterThan(json["data"]["th"].ToString());
                    }
                }
                else if (dateNow.DayOfWeek == DayOfWeek.Friday)
                {
                    if (String.IsNullOrWhiteSpace(json["data"]["f"].ToString()))
                    {
                        return false;
                    }
                    else
                    {
                        return TimeIsGreaterThan(json["data"]["f"].ToString());
                    }
                }
                else if (dateNow.DayOfWeek == DayOfWeek.Saturday)
                {
                    if (String.IsNullOrWhiteSpace(json["data"]["s"].ToString()))
                    {
                        return false;
                    }
                    else
                    {
                        return TimeIsGreaterThan(json["data"]["s"].ToString());
                    }
                }
                else if (dateNow.DayOfWeek == DayOfWeek.Sunday)
                {
                    if (String.IsNullOrWhiteSpace(json["data"]["sd"].ToString()))
                    {
                        return false;
                    }
                    else
                    {
                        return TimeIsGreaterThan(json["data"]["sd"].ToString());
                    }
                }
            }catch(Exception e)
            {
                MessageBox.Show("There is a problem with the server.");
            }
            


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


            if (now.Hour > hour)
            {
                return true;
            }
            else if (now.Hour == hour)
            {
                if (now.Minute > minute)
                {
                    return true;
                }
            }


            return false;
        }

        private void btnStart_Click_1(object sender, EventArgs e)
        {
            if (IsCutOff())
            {
                MessageBox.Show("Operation failed: The system is not accepting new token. ");
            }
            else
            {
                this.Form.OpenForm(new FormAccountNo(this.Transaction, this.Form));
            }

        }
    }
}
