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
    public partial class FormLoans : Form
    {
        private Transaction Transaction;
        private MainForm Form;
        public FormLoans(Transaction transaction, MainForm form)
        {
            InitializeComponent();
            this.Transaction = transaction;
            this.Form = form;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnBill_Click(object sender, EventArgs e)
        {
            this.Transaction.Loan = "5";
            this.Form.OpenForm(new FormAccountNo(this.Transaction, this.Form, "LOAN"));
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            this.Transaction.Loan = "3";
            this.Form.OpenForm(new FormAccountNo(this.Transaction, this.Form, "LOAN"));
        }

        private void btnCheckEncashment_Click(object sender, EventArgs e)
        {
            this.Transaction.Loan = "4";
            this.Form.OpenForm(new FormAccountNo(this.Transaction, this.Form, "LOAN"));
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnTime_Click(object sender, EventArgs e)
        {

        }

        private void btnLoan_Click(object sender, EventArgs e)
        {
            this.Form.OpenForm(new FormServices(this.Transaction, this.Form));
        }

        private void btnWithdraw_Click(object sender, EventArgs e)
        {
            this.Transaction.Loan = "2";
            this.Form.OpenForm(new FormAccountNo(this.Transaction, this.Form, "LOAN"));
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnDeposit_Click(object sender, EventArgs e)
        {
            this.Transaction.Loan = "1";
            this.Form.OpenForm(new FormAccountNo(this.Transaction, this.Form, "LOAN"));
        }

        private void btnBack_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
