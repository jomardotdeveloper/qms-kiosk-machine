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
    public partial class FormSMS : Form
    {
        private Transaction Transaction;
        private MainForm Form;
        public FormSMS(Transaction transaction, MainForm form)
        {
            InitializeComponent();
            this.Form = form;
            this.Transaction = transaction;
        }

        private void btnNo_Click_1(object sender, EventArgs e)
        {
            this.Transaction.MobileNumber = null;
            this.Form.OpenForm(new FormTicket(this.Form, this.Transaction));
        }

        private void btnYes_Click_1(object sender, EventArgs e)
        {
            this.Form.OpenForm(new FormSMSNumber(this.Transaction, this.Form));
        }
    }
}
