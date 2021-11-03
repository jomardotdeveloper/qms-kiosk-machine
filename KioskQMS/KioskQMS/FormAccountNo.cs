using KioskQMS.Kiosk;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Formatting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Windows.Forms;

namespace KioskQMS
{
    public partial class FormAccountNo : Form
    {
        private Transaction Transaction;
        private Control _focusedControl;
        private MainForm Form;
        /* TO HANDLE THE SSL CERTIFICATE ISSUE WITH THE API, WILL REMOVE UPON DEPLOYING THE REST API */
        private HttpClientHandler Handler;
        private HttpClient Client;


        public FormAccountNo(Transaction transaction, MainForm form)
        {
            InitializeComponent();
            this.Transaction = transaction;
            this.txtAccountNumber.GotFocus += TextBox_GotFocus;
            this.Form = form;
        }
        private void btnBack_Click_1(object sender, EventArgs e)
        {
            this.Form.OpenForm(new FormStartScreen(this.Form));
        }

        private void btnNext_Click_1(object sender, EventArgs e)
        {
            Validation();
        }

        private void btnClear_Click_1(object sender, EventArgs e)
        {
            if (this._focusedControl != null)
            {
                this._focusedControl.Text = "";
            }
        }

        private void btnErase_Click_1(object sender, EventArgs e)
        {
            if (this._focusedControl != null && !String.IsNullOrWhiteSpace(this._focusedControl.Text))
            {
                this._focusedControl.Text = this._focusedControl.Text.Remove(this._focusedControl.Text.Length - 1);
            }
        }

        private void btn0_Click_1(object sender, EventArgs e)
        {
            EnterNumber("0");
        }

        private void btn1_Click_1(object sender, EventArgs e)
        {
            EnterNumber("1");

        }

        private void btn2_Click_1(object sender, EventArgs e)
        {
            EnterNumber("2");
        }

        private void btn3_Click_1(object sender, EventArgs e)
        {
            EnterNumber("3");
        }

        private void btn4_Click_1(object sender, EventArgs e)
        {
            EnterNumber("4");
        }

        private void btn5_Click_1(object sender, EventArgs e)
        {
            EnterNumber("5");
        }

        private void btn6_Click_1(object sender, EventArgs e)
        {
            EnterNumber("6");
        }

        private void btn7_Click_1(object sender, EventArgs e)
        {
            EnterNumber("7");
        }

        private void btn8_Click_1(object sender, EventArgs e)
        {
            EnterNumber("8");
        }

        private void btn9_Click_1(object sender, EventArgs e)
        {
            EnterNumber("9");
        }

        private void txtAccountNumber_TextChanged(object sender, EventArgs e)
        {

        }
        private void TextBox_GotFocus(object sender, EventArgs e)
        {
            this._focusedControl = (Control)sender;
        }

        private void EnterNumber(string number)
        {
            if (this._focusedControl != null)
            {
                if (this._focusedControl.Name == this.txtAccountNumber.Name)
                {
                    if (this._focusedControl.Text.Length != 20)
                    {
                        if (this._focusedControl.Text.Length == 4 || this._focusedControl.Text.Length == 8 || this._focusedControl.Text.Length == 11 || this._focusedControl.Text.Length == 18)
                            this._focusedControl.Text += "-" + number;
                        else
                            this._focusedControl.Text += number;
                    }
                }
            }
        }
        private void Validation()
        {
            if (String.IsNullOrWhiteSpace(this.txtAccountNumber.Text))
            {
                MessageBox.Show("Fill out all the required fields!");
            }
            else
            {
                if (!AccountNumberFormatIsValid())
                {
                    MessageBox.Show("Wrong format of account number!");
                    this.txtAccountNumber.Text = "";
                }
                else
                {
                    if (this.AccountNumberExists())
                    {
                        this.Form.OpenForm(new FormServices(this.Transaction, this.Form));
                    }
                    else
                    {
                        MessageBox.Show("Account number doesn't exists.");
                    }

                }
            }
        }

        private bool AccountNumberExists()
        {
            try
            {
                this.Handler = new HttpClientHandler()
                {
                    ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
                };

                this.Client = new HttpClient(this.Handler);
                this.Client.BaseAddress = new Uri(Endpoints.BaseUrl);

                string param = this.txtAccountNumber.Text + "/" + this.Transaction.BranchID.ToString();
                var response = this.Client.GetAsync(Endpoints.AccountUrl + param).Result;
                JObject json = JObject.Parse(response.Content.ReadAsStringAsync().Result);

                if (json["success"].ToString() == "1")
                {
                    if (json["data"]["customer_type"].ToString() == "priority")
                    {
                        this.Transaction.IsPriority = true;
                    }
                    else
                    {
                        this.Transaction.IsPriority = false;
                    }

                    this.Transaction.AccountNumber = this.txtAccountNumber.Text;

                    return true;
                }
            }
            catch(Exception e)
            {
                MessageBox.Show("There is a problem with the server.");
            }
           

            return false;
        }

        private bool AccountNumberFormatIsValid()
        {
            string[] splitted_acc_number = this.txtAccountNumber.Text.Split('-');

            return splitted_acc_number.Length == 5 && splitted_acc_number[0].Length == 4 && splitted_acc_number[1].Length == 3
                && splitted_acc_number[2].Length == 2 && splitted_acc_number[3].Length == 6 && splitted_acc_number[4].Length == 1;
        }

      
    }
}
