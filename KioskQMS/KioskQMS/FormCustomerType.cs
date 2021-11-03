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
    public partial class FormCustomerType : Form
    {
        private Transaction Transaction;
        private MainForm Form;
        public FormCustomerType(Transaction transaction, MainForm form)
        {
            InitializeComponent();
            this.Transaction = transaction;
            this.Form = form;
        }

        private void btnPriority_Click(object sender, EventArgs e)
        {
            //this.Transaction.CustomerType = 2;
            //this.Form.OpenForm(new FormServices(this.Transaction, this.Form));
        }

        private void btnRegular_Click(object sender, EventArgs e)
        {
            //this.Transaction.CustomerType = 1;
            //this.Form.OpenForm(new FormServices(this.Transaction, this.Form));
        }
    }
}
