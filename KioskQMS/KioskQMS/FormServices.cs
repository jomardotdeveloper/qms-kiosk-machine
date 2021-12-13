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
            this.Transaction.ServiceID = 6;
            LoadWindow();
        }

        private void btnCheckEncashment_Click_1(object sender, EventArgs e)
        {
            this.Transaction.ServiceID = 3;
            LoadWindow();
        }

        private void btnBill_Click_1(object sender, EventArgs e)
        {
            this.Transaction.ServiceID = 4;
            LoadWindow();
        }

        private void btnLoan_Click_1(object sender, EventArgs e)
        {
            this.Transaction.ServiceID = 5;
            LoadWindow();
        }

        private void btnBack_Click_1(object sender, EventArgs e)
        {
            this.Form.OpenForm(new FormStartScreen(this.Form));
        }

        private void LoadWindow()
        {
            if (this.Transaction.ServiceID == 1)
            {
                this.Transaction.Loan = null;
                this.Transaction.Bill = null;
                this.Form.OpenForm(new FormDeposit(this.Transaction, this.Form));
            }
            else if(this.Transaction.ServiceID == 4)
            {
                this.Transaction.Amount = null;
                this.Transaction.Loan = null;
                this.Form.OpenForm(new FormBillsPayment(this.Transaction, this.Form));
            }else if(this.Transaction.ServiceID == 5)
            {
                this.Transaction.Amount = null;
                this.Transaction.Bill = null;
                this.Form.OpenForm(new FormLoans(this.Transaction, this.Form));
            }else if(this.Transaction.ServiceID == 6)
            {
                this.Transaction.Amount = null;
                this.Transaction.Loan = null;
                this.Transaction.Bill = null;
                this.Transaction.AccountNumber = null;
                this.Form.OpenForm(new FormSMS(this.Transaction, this.Form));
            }
            else
            {
                this.Transaction.Amount = null;
                this.Transaction.Loan = null;
                this.Transaction.Bill = null;
                this.Form.OpenForm(new FormAccountNo(this.Transaction, this.Form, "SERVICES"));
            }

        }
    }
}
