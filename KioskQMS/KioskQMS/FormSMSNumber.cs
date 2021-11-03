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
    public partial class FormSMSNumber : Form
    {
        private Transaction Transaction;
        private MainForm Form;
        private Control _focusedControl;

        /* TO HANDLE THE SSL CERTIFICATE ISSUE WITH THE API, WILL REMOVE UPON DEPLOYING THE REST API */
        private HttpClientHandler Handler;
        private HttpClient Client;

        public FormSMSNumber(Transaction transaction, MainForm form)
        {
            InitializeComponent();
            this.Transaction = transaction;
            this.Form = form;
            this.txtContactNumber.GotFocus += TextBox_GotFocus;
        }

        private void TextBox_GotFocus(object sender, EventArgs e)
        {
            this._focusedControl = (Control)sender;
        }


        private void EnterNumber(string number)
        {
            if (this._focusedControl != null)
            {
                if (this._focusedControl.Name == this.txtContactNumber.Name)
                {
                    if (this._focusedControl.Text.Length != 13)
                    {
                        this._focusedControl.Text += number;
                    }
                }
            }
        }

        private void FormSMSNumber_Load(object sender, EventArgs e)
        {

        }

        private void btnBack_Click_1(object sender, EventArgs e)
        {
            this.Form.OpenForm(new FormSMS(this.Transaction, this.Form));
        }


        private void btnNext_Click_1(object sender, EventArgs e)
        {
            if(this.txtContactNumber.Text.Length != 13)
            {
                MessageBox.Show("Your mobile number is invalid!");
            }
            else
            {
                this.Transaction.MobileNumber = this.txtContactNumber.Text.Replace("+63", "");
                this.Transaction = TCreator.CreateTransaction(this.Transaction);
                this.Form.OpenForm(new FormTicket(this.Form, this.Transaction));
            }
        }

        private void btnClear_Click_1(object sender, EventArgs e)
        {
            if (this._focusedControl != null)
            {
                this._focusedControl.Text = "+63";
            }
        }

        private void btnErase_Click_1(object sender, EventArgs e)
        {
            if (this._focusedControl != null && !String.IsNullOrWhiteSpace(this._focusedControl.Text) && this._focusedControl.Text.Length > 3)
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

        private void txtContactNumber_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
