﻿using KioskQMS.Kiosk;
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
    public partial class FormDeposit : Form
    {
        private Transaction Transaction;
        private Control _focusedControl;
        private MainForm Form;

        public FormDeposit(Transaction transaction, MainForm form)
        {
            InitializeComponent();
            this.Transaction = transaction;
            this.txtAmount.GotFocus += TextBox_GotFocus;
            this.Form = form;
        }

        private void btnBack_Click_1(object sender, EventArgs e)
        {
            this.Form.OpenForm(new FormServices(this.Transaction, this.Form));
        }

        private void btnNext_Click_1(object sender, EventArgs e)
        {
            Validation();
        }

        private void txtAmount_TextChanged(object sender, EventArgs e)
        {

        }


        private void btnClear_Click(object sender, EventArgs e)
        {
            if (this._focusedControl != null)
            {
                this._focusedControl.Text = "";
            }
        }

        private void btnErase_Click(object sender, EventArgs e)
        {
            if (this._focusedControl != null && !String.IsNullOrWhiteSpace(this._focusedControl.Text))
            {
                this._focusedControl.Text = this._focusedControl.Text.Remove(this._focusedControl.Text.Length - 1);
            }
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            EnterNumber("0");
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            EnterNumber("1");
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            EnterNumber("2");
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            EnterNumber("3");
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            EnterNumber("4");
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            EnterNumber("5");
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            EnterNumber("6");
        }
        private void btn7_Click(object sender, EventArgs e)
        {
            EnterNumber("7");
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            EnterNumber("8");
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            EnterNumber("9");
        }

        private void EnterNumber(string number)
        {
            if (this._focusedControl != null)
            {
                if (this._focusedControl.Text.Length <= 11)
                {
                    this._focusedControl.Text += number;
                }
            }
        }

        private void TextBox_GotFocus(object sender, EventArgs e)
        {
            this._focusedControl = (Control)sender;
        }

        private void Validation()
        {
            if (String.IsNullOrWhiteSpace(this.txtAmount.Text))
            {
                MessageBox.Show("Fill out all the required fields!");
            }
            else
            {
                this.Transaction.Amount = this.txtAmount.Text;
                this.Form.OpenForm(new FormSMS(this.Transaction, this.Form));
            }
        }

        private void txtAccountNumber_TextChanged(object sender, EventArgs e)
        {

        }
    }
}