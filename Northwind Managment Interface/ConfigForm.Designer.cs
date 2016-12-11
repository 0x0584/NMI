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
            this.txtinit = new System.Windows.Forms.TextBox();
            this.txtinteg = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.rdefault = new System.Windows.Forms.RadioButton();
            this.rcustom = new System.Windows.Forms.RadioButton();
            this.combdatasrc = new System.Windows.Forms.ComboBox();
            this.btnconfirm = new System.Windows.Forms.Button();
            this.btnshowdetails = new System.Windows.Forms.Button();
            this.txtconntime = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtinit
            // 
            this.txtinit.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtinit.Location = new System.Drawing.Point(25, 104);
            this.txtinit.Name = "txtinit";
            this.txtinit.Size = new System.Drawing.Size(166, 20);
            this.txtinit.TabIndex = 0;
            // 
            // txtinteg
            // 
            this.txtinteg.Location = new System.Drawing.Point(26, 32);
            this.txtinteg.Name = "txtinteg";
            this.txtinteg.Size = new System.Drawing.Size(166, 20);
            this.txtinteg.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(209, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Data Source";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(206, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Initial Catalog";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(198, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Integrated Security";
            // 
            // rdefault
            // 
            this.rdefault.AutoSize = true;
            this.rdefault.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.rdefault.Location = new System.Drawing.Point(25, 3);
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
            this.rcustom.Location = new System.Drawing.Point(132, 3);
            this.rcustom.Name = "rcustom";
            this.rcustom.Size = new System.Drawing.Size(59, 17);
            this.rcustom.TabIndex = 3;
            this.rcustom.TabStop = true;
            this.rcustom.Text = "Custom";
            this.rcustom.UseVisualStyleBackColor = true;
            this.rcustom.CheckedChanged += new System.EventHandler(this.rcustom_CheckedChanged);
            // 
            // combdatasrc
            // 
            this.combdatasrc.FormattingEnabled = true;
            this.combdatasrc.Location = new System.Drawing.Point(26, 66);
            this.combdatasrc.Name = "combdatasrc";
            this.combdatasrc.Size = new System.Drawing.Size(167, 21);
            this.combdatasrc.TabIndex = 4;
            // 
            // btnconfirm
            // 
            this.btnconfirm.Location = new System.Drawing.Point(176, 139);
            this.btnconfirm.Name = "btnconfirm";
            this.btnconfirm.Size = new System.Drawing.Size(100, 31);
            this.btnconfirm.TabIndex = 5;
            this.btnconfirm.Text = "Confirmer";
            this.btnconfirm.UseVisualStyleBackColor = true;
            this.btnconfirm.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnshowdetails
            // 
            this.btnshowdetails.Location = new System.Drawing.Point(12, 147);
            this.btnshowdetails.Name = "btnshowdetails";
            this.btnshowdetails.Size = new System.Drawing.Size(31, 23);
            this.btnshowdetails.TabIndex = 6;
            this.btnshowdetails.Text = "+";
            this.btnshowdetails.UseVisualStyleBackColor = true;
            this.btnshowdetails.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtconntime
            // 
            this.txtconntime.Location = new System.Drawing.Point(26, 217);
            this.txtconntime.Name = "txtconntime";
            this.txtconntime.Size = new System.Drawing.Size(167, 20);
            this.txtconntime.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(224, 220);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Timeout";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(66, 139);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 31);
            this.button1.TabIndex = 9;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 180);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtconntime);
            this.Controls.Add(this.btnshowdetails);
            this.Controls.Add(this.btnconfirm);
            this.Controls.Add(this.combdatasrc);
            this.Controls.Add(this.rcustom);
            this.Controls.Add(this.rdefault);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtinteg);
            this.Controls.Add(this.txtinit);
            this.Name = "ConfigForm";
            this.Text = "Configure The Connection";
            this.Load += new System.EventHandler(this.ConfigForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtinit;
        private System.Windows.Forms.TextBox txtinteg;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rdefault;
        private System.Windows.Forms.RadioButton rcustom;
        private System.Windows.Forms.ComboBox combdatasrc;
        private System.Windows.Forms.Button btnconfirm;
        private System.Windows.Forms.Button btnshowdetails;
        private System.Windows.Forms.TextBox txtconntime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
    }
}