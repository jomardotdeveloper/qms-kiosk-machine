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
    public partial class MainForm : Form
    {
        private Form prevForm; 
        private Form currentChildForm;
        public MainForm()
        {
            InitializeComponent();
            OpenForm(new FormStartScreen(this));
        }

        public Form PrevForm()
        {
            return this.prevForm;
        }

        public void OpenForm(Form form)
        {
            if(currentChildForm != null)
            {
                prevForm = currentChildForm;
                currentChildForm.Close();
            }

            currentChildForm = form;
            form.WindowState = FormWindowState.Normal;
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            this.mainPanel.Controls.Add(form);
            form.Show();
        }


    }
}
