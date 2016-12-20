namespace Northwind
{
    partial class ConfigForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.rdefault = new System.Windows.Forms.RadioButton();
            this.rcustom = new System.Windows.Forms.RadioButton();
            this.btnconfirm = new System.Windows.Forms.Button();
            this.txtconntime = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboSQLInst = new System.Windows.Forms.ComboBox();
            this.txtuserid = new System.Windows.Forms.TextBox();
            this.txtpassword = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.comboWinAuthn = new System.Windows.Forms.ComboBox();
            this.lblwarning = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(199, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Data Source";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(184, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Integrated Security";
            // 
            // rdefault
            // 
            this.rdefault.AutoSize = true;
            this.rdefault.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.rdefault.Location = new System.Drawing.Point(14, 54);
            this.rdefault.Name = "rdefault";
            this.rdefault.Size = new System.Drawing.Size(58, 17);
            this.rdefault.TabIndex = 2;
            this.rdefault.TabStop = true;
            this.rdefault.Text = "Default";
            this.rdefault.UseVisualStyleBackColor = true;
            this.rdefault.CheckedChanged += new System.EventHandler(this.rdefault_CheckedChanged);
            // 
            // rcustom
            // 
            this.rcustom.AutoSize = true;
            this.rcustom.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.rcustom.Location = new System.Drawing.Point(121, 54);
            this.rcustom.Name = "rcustom";
            this.rcustom.Size = new System.Drawing.Size(59, 17);
            this.rcustom.TabIndex = 3;
            this.rcustom.TabStop = true;
            this.rcustom.Text = "Custom";
            this.rcustom.UseVisualStyleBackColor = true;
            this.rcustom.CheckedChanged += new System.EventHandler(this.rcustom_CheckedChanged);
            // 
            // btnconfirm
            // 
            this.btnconfirm.Location = new System.Drawing.Point(209, 40);
            this.btnconfirm.Name = "btnconfirm";
            this.btnconfirm.Size = new System.Drawing.Size(73, 31);
            this.btnconfirm.TabIndex = 5;
            this.btnconfirm.Text = "Confirmer";
            this.btnconfirm.UseVisualStyleBackColor = true;
            this.btnconfirm.Click += new System.EventHandler(this.btnconfirm_Click);
            // 
            // txtconntime
            // 
            this.txtconntime.Location = new System.Drawing.Point(12, 83);
            this.txtconntime.Name = "txtconntime";
            this.txtconntime.Size = new System.Drawing.Size(167, 20);
            this.txtconntime.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(210, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Timeout";
            // 
            // comboSQLInst
            // 
            this.comboSQLInst.FormattingEnabled = true;
            this.comboSQLInst.Location = new System.Drawing.Point(11, 6);
            this.comboSQLInst.Name = "comboSQLInst";
            this.comboSQLInst.Size = new System.Drawing.Size(169, 21);
            this.comboSQLInst.TabIndex = 10;
            this.comboSQLInst.SelectedIndexChanged += new System.EventHandler(this.comboSQLInst_SelectedIndexChanged);
            // 
            // txtuserid
            // 
            this.txtuserid.Location = new System.Drawing.Point(11, 142);
            this.txtuserid.Name = "txtuserid";
            this.txtuserid.Size = new System.Drawing.Size(169, 20);
            this.txtuserid.TabIndex = 12;
            // 
            // txtpassword
            // 
            this.txtpassword.Location = new System.Drawing.Point(11, 172);
            this.txtpassword.Name = "txtpassword";
            this.txtpassword.Size = new System.Drawing.Size(169, 20);
            this.txtpassword.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(211, 149);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "User ID";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(206, 175);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Password";
            // 
            // comboWinAuthn
            // 
            this.comboWinAuthn.FormattingEnabled = true;
            this.comboWinAuthn.Items.AddRange(new object[] {
            "Yes",
            "No"});
            this.comboWinAuthn.Location = new System.Drawing.Point(11, 115);
            this.comboWinAuthn.Name = "comboWinAuthn";
            this.comboWinAuthn.Size = new System.Drawing.Size(169, 21);
            this.comboWinAuthn.TabIndex = 14;
            this.comboWinAuthn.SelectedIndexChanged += new System.EventHandler(this.comboWinAuthn_SelectedIndexChanged);
            // 
            // lblwarning
            // 
            this.lblwarning.AutoSize = true;
            this.lblwarning.ForeColor = System.Drawing.Color.Maroon;
            this.lblwarning.Location = new System.Drawing.Point(12, 30);
            this.lblwarning.Name = "lblwarning";
            this.lblwarning.Size = new System.Drawing.Size(24, 13);
            this.lblwarning.TabIndex = 15;
            this.lblwarning.Text = "test";
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(291, 199);
            this.Controls.Add(this.lblwarning);
            this.Controls.Add(this.comboWinAuthn);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtpassword);
            this.Controls.Add(this.txtuserid);
            this.Controls.Add(this.comboSQLInst);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtconntime);
            this.Controls.Add(this.btnconfirm);
            this.Controls.Add(this.rcustom);
            this.Controls.Add(this.rdefault);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "ConfigForm";
            this.Text = "Configure The Connection";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ConfigForm_FormClosing);
            this.Load += new System.EventHandler(this.ConfigForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rdefault;
        private System.Windows.Forms.RadioButton rcustom;
        private System.Windows.Forms.Button btnconfirm;
        private System.Windows.Forms.TextBox txtconntime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboSQLInst;
        private System.Windows.Forms.TextBox txtuserid;
        private System.Windows.Forms.TextBox txtpassword;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboWinAuthn;
        private System.Windows.Forms.Label lblwarning;
    }
}