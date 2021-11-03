
namespace KioskQMS
{
    partial class FormCustomerType
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblSelect = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnPriority = new FontAwesome.Sharp.IconButton();
            this.btnRegular = new FontAwesome.Sharp.IconButton();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1386, 223);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(939, 223);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(447, 565);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 223);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(447, 565);
            this.panel3.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Transparent;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(447, 553);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(492, 235);
            this.panel4.TabIndex = 1;
            // 
            // lblSelect
            // 
            this.lblSelect.AutoSize = true;
            this.lblSelect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelect.ForeColor = System.Drawing.Color.Black;
            this.lblSelect.Location = new System.Drawing.Point(3, 0);
            this.lblSelect.Name = "lblSelect";
            this.lblSelect.Size = new System.Drawing.Size(486, 167);
            this.lblSelect.TabIndex = 1;
            this.lblSelect.Text = "Select Customer Type";
            this.lblSelect.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.lblSelect, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(447, 223);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(492, 167);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // btnPriority
            // 
            this.btnPriority.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(132)))), ((int)(((byte)(227)))));
            this.btnPriority.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPriority.FlatAppearance.BorderSize = 0;
            this.btnPriority.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPriority.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPriority.ForeColor = System.Drawing.Color.White;
            this.btnPriority.IconChar = FontAwesome.Sharp.IconChar.Wheelchair;
            this.btnPriority.IconColor = System.Drawing.Color.White;
            this.btnPriority.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnPriority.Location = new System.Drawing.Point(3, 3);
            this.btnPriority.Name = "btnPriority";
            this.btnPriority.Size = new System.Drawing.Size(240, 157);
            this.btnPriority.TabIndex = 2;
            this.btnPriority.Text = "Priority Customer";
            this.btnPriority.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPriority.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnPriority.UseVisualStyleBackColor = false;
            this.btnPriority.Click += new System.EventHandler(this.btnPriority_Click);
            // 
            // btnRegular
            // 
            this.btnRegular.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(185)))), ((int)(((byte)(255)))));
            this.btnRegular.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRegular.FlatAppearance.BorderSize = 0;
            this.btnRegular.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegular.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegular.ForeColor = System.Drawing.Color.White;
            this.btnRegular.IconChar = FontAwesome.Sharp.IconChar.Male;
            this.btnRegular.IconColor = System.Drawing.Color.White;
            this.btnRegular.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnRegular.Location = new System.Drawing.Point(249, 3);
            this.btnRegular.Name = "btnRegular";
            this.btnRegular.Size = new System.Drawing.Size(240, 157);
            this.btnRegular.TabIndex = 3;
            this.btnRegular.Text = "Regular Customer";
            this.btnRegular.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRegular.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnRegular.UseVisualStyleBackColor = false;
            this.btnRegular.Click += new System.EventHandler(this.btnRegular_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.btnRegular, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnPriority, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(447, 390);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(492, 163);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // FormCustomerType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1386, 788);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormCustomerType";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormServices";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblSelect;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private FontAwesome.Sharp.IconButton btnPriority;
        private FontAwesome.Sharp.IconButton btnRegular;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    }
}