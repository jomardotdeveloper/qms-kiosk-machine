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

namespace KioskQMS
{
    public partial class FormBillsPayment : Form
    {
        private Transaction Transaction;
        private MainForm Form;
        public FormBillsPayment(Transaction transaction, MainForm form)
        {
            InitializeComponent();
            this.Transaction = transaction;
            this.Form = form;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnDeposit_Click(object sender, EventArgs e)
        {
            this.Transaction.Bill = "1";
            this.Form.OpenForm(new FormAccountNo(this.Transaction, this.Form, "BILL"));
            //1
        }

        private void btnWithdraw_Click(object sender, EventArgs e)
        {
            this.Transaction.Bill = "2";
            this.Form.OpenForm(new FormAccountNo(this.Transaction, this.Form, "BILL"));
            //2
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            this.Transaction.Bill = "4";
            this.Form.OpenForm(new FormAccountNo(this.Transaction, this.Form, "BILL"));
            //4
        }

        private void btnCheckEncashment_Click(object sender, EventArgs e)
        {
            this.Transaction.Bill = "3";
            this.Form.OpenForm(new FormAccountNo(this.Transaction, this.Form, "BILL"));
            //3
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Transaction.Bill = "7";
            this.Form.OpenForm(new FormAccountNo(this.Transaction, this.Form, "BILL"));
            //7
        }

        private void btnTime_Click(object sender, EventArgs e)
        {
            this.Transaction.Bill = "8";
            this.Form.OpenForm(new FormAccountNo(this.Transaction, this.Form, "BILL"));
            //8
        }

        private void btnBill_Click(object sender, EventArgs e)
        {
            this.Transaction.Bill = "5";
            this.Form.OpenForm(new FormAccountNo(this.Transaction, this.Form, "BILL"));
            //5
        }

        private void btnLoan_Click(object sender, EventArgs e)
        {
            this.Transaction.Bill = "6";
            this.Form.OpenForm(new FormAccountNo(this.Transaction, this.Form, "BILL"));
            //6
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Transaction.Bill = "9";
            this.Form.OpenForm(new FormAccountNo(this.Transaction, this.Form, "BILL"));
            //9
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            this.Form.OpenForm(new FormServices(this.Transaction, this.Form));
        }
    }
}
