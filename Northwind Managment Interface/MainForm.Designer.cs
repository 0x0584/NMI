namespace Northwind
{
    partial class MainForm
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnadd = new System.Windows.Forms.Button();
            this.tbname = new System.Windows.Forms.TextBox();
            this.tbdesc = new System.Windows.Forms.TextBox();
            this.btnsearch = new System.Windows.Forms.Button();
            this.tbid = new System.Windows.Forms.TextBox();
            this.btnupdate = new System.Windows.Forms.Button();
            this.btndelete = new System.Windows.Forms.Button();
            this.btnclear = new System.Windows.Forms.Button();
            this.roffline = new System.Windows.Forms.RadioButton();
            this.ronline = new System.Windows.Forms.RadioButton();
            this.btnconnsetings = new System.Windows.Forms.Button();
            this.combotables = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.mainDataGrid = new System.Windows.Forms.DataGridView();
            this.lblrecords = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnfillform = new System.Windows.Forms.Button();
            this.btnsend = new System.Windows.Forms.Button();
            this.btntest = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.mainDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // btnadd
            // 
            this.btnadd.Location = new System.Drawing.Point(2, 76);
            this.btnadd.Name = "btnadd";
            this.btnadd.Size = new System.Drawing.Size(75, 23);
            this.btnadd.TabIndex = 2;
            this.btnadd.Text = "add";
            this.btnadd.UseVisualStyleBackColor = true;
            this.btnadd.Click += new System.EventHandler(this.btnadd_Click);
            // 
            // tbname
            // 
            this.tbname.Location = new System.Drawing.Point(59, 10);
            this.tbname.Name = "tbname";
            this.tbname.Size = new System.Drawing.Size(146, 20);
            this.tbname.TabIndex = 3;
            // 
            // tbdesc
            // 
            this.tbdesc.Location = new System.Drawing.Point(59, 45);
            this.tbdesc.Name = "tbdesc";
            this.tbdesc.Size = new System.Drawing.Size(146, 20);
            this.tbdesc.TabIndex = 4;
            // 
            // btnsearch
            // 
            this.btnsearch.Location = new System.Drawing.Point(609, 12);
            this.btnsearch.Name = "btnsearch";
            this.btnsearch.Size = new System.Drawing.Size(75, 23);
            this.btnsearch.TabIndex = 5;
            this.btnsearch.Text = "search";
            this.btnsearch.UseVisualStyleBackColor = true;
            this.btnsearch.Click += new System.EventHandler(this.btnsearch_Click);
            // 
            // tbid
            // 
            this.tbid.Location = new System.Drawing.Point(446, 14);
            this.tbid.Name = "tbid";
            this.tbid.Size = new System.Drawing.Size(146, 20);
            this.tbid.TabIndex = 6;
            // 
            // btnupdate
            // 
            this.btnupdate.Location = new System.Drawing.Point(192, 76);
            this.btnupdate.Name = "btnupdate";
            this.btnupdate.Size = new System.Drawing.Size(75, 23);
            this.btnupdate.TabIndex = 7;
            this.btnupdate.Text = "update";
            this.btnupdate.UseVisualStyleBackColor = true;
            this.btnupdate.Click += new System.EventHandler(this.btnupdate_Click);
            // 
            // btndelete
            // 
            this.btndelete.Location = new System.Drawing.Point(94, 76);
            this.btndelete.Name = "btndelete";
            this.btndelete.Size = new System.Drawing.Size(75, 23);
            this.btndelete.TabIndex = 8;
            this.btndelete.Text = "delete";
            this.btndelete.UseVisualStyleBackColor = true;
            this.btndelete.Click += new System.EventHandler(this.btndelete_Click);
            // 
            // btnclear
            // 
            this.btnclear.Location = new System.Drawing.Point(527, 100);
            this.btnclear.Name = "btnclear";
            this.btnclear.Size = new System.Drawing.Size(75, 23);
            this.btnclear.TabIndex = 9;
            this.btnclear.Text = "clear interface";
            this.btnclear.UseVisualStyleBackColor = true;
            this.btnclear.Click += new System.EventHandler(this.btnclear_Click);
            // 
            // roffline
            // 
            this.roffline.AutoSize = true;
            this.roffline.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.roffline.Location = new System.Drawing.Point(307, 72);
            this.roffline.Name = "roffline";
            this.roffline.Size = new System.Drawing.Size(54, 17);
            this.roffline.TabIndex = 10;
            this.roffline.TabStop = true;
            this.roffline.Text = "Offline";
            this.roffline.UseVisualStyleBackColor = true;
            this.roffline.CheckedChanged += new System.EventHandler(this.roffline_CheckedChanged);
            // 
            // ronline
            // 
            this.ronline.AutoSize = true;
            this.ronline.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ronline.Location = new System.Drawing.Point(307, 51);
            this.ronline.Name = "ronline";
            this.ronline.Size = new System.Drawing.Size(54, 17);
            this.ronline.TabIndex = 10;
            this.ronline.TabStop = true;
            this.ronline.Text = "Online";
            this.ronline.UseVisualStyleBackColor = true;
            this.ronline.CheckedChanged += new System.EventHandler(this.ronline_CheckedChanged);
            // 
            // btnconnsetings
            // 
            this.btnconnsetings.Location = new System.Drawing.Point(393, 53);
            this.btnconnsetings.Name = "btnconnsetings";
            this.btnconnsetings.Size = new System.Drawing.Size(91, 36);
            this.btnconnsetings.TabIndex = 11;
            this.btnconnsetings.Text = "connection settings";
            this.btnconnsetings.UseVisualStyleBackColor = true;
            this.btnconnsetings.Click += new System.EventHandler(this.btnconnsetings_Click);
            // 
            // combotables
            // 
            this.combotables.FormattingEnabled = true;
            this.combotables.Location = new System.Drawing.Point(257, 105);
            this.combotables.Name = "combotables";
            this.combotables.Size = new System.Drawing.Size(193, 21);
            this.combotables.TabIndex = 12;
            this.combotables.SelectedIndexChanged += new System.EventHandler(this.combotables_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(425, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "id";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Desc";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(583, 402);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "# Records";
            // 
            // mainDataGrid
            // 
            this.mainDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mainDataGrid.Location = new System.Drawing.Point(12, 137);
            this.mainDataGrid.Name = "mainDataGrid";
            this.mainDataGrid.Size = new System.Drawing.Size(672, 252);
            this.mainDataGrid.TabIndex = 14;
            this.mainDataGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.mainDataGrid_CellClick);
            // 
            // lblrecords
            // 
            this.lblrecords.AutoSize = true;
            this.lblrecords.Location = new System.Drawing.Point(646, 402);
            this.lblrecords.Name = "lblrecords";
            this.lblrecords.Size = new System.Drawing.Size(0, 13);
            this.lblrecords.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DarkGreen;
            this.label5.Location = new System.Drawing.Point(537, 398);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(16, 17);
            this.label5.TabIndex = 17;
            this.label5.Text = "+";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Maroon;
            this.label6.Location = new System.Drawing.Point(503, 398);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(13, 17);
            this.label6.TabIndex = 17;
            this.label6.Text = "-";
            // 
            // btnfillform
            // 
            this.btnfillform.Location = new System.Drawing.Point(253, 7);
            this.btnfillform.Name = "btnfillform";
            this.btnfillform.Size = new System.Drawing.Size(75, 23);
            this.btnfillform.TabIndex = 18;
            this.btnfillform.Text = "add using form";
            this.btnfillform.UseVisualStyleBackColor = true;
            this.btnfillform.Click += new System.EventHandler(this.btnfillform_Click);
            // 
            // btnsend
            // 
            this.btnsend.Location = new System.Drawing.Point(609, 40);
            this.btnsend.Name = "btnsend";
            this.btnsend.Size = new System.Drawing.Size(75, 40);
            this.btnsend.TabIndex = 16;
            this.btnsend.Text = "Send to the server";
            this.btnsend.UseVisualStyleBackColor = true;
            this.btnsend.Click += new System.EventHandler(this.btnsend_Click);
            // 
            // btntest
            // 
            this.btntest.Location = new System.Drawing.Point(344, 14);
            this.btntest.Name = "btntest";
            this.btntest.Size = new System.Drawing.Size(75, 23);
            this.btntest.TabIndex = 19;
            this.btntest.Text = "Test";
            this.btntest.UseVisualStyleBackColor = true;
            this.btntest.Click += new System.EventHandler(this.btntest_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(696, 424);
            this.Controls.Add(this.btntest);
            this.Controls.Add(this.btnfillform);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnsend);
            this.Controls.Add(this.lblrecords);
            this.Controls.Add(this.mainDataGrid);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.combotables);
            this.Controls.Add(this.btnconnsetings);
            this.Controls.Add(this.ronline);
            this.Controls.Add(this.roffline);
            this.Controls.Add(this.btnclear);
            this.Controls.Add(this.btndelete);
            this.Controls.Add(this.btnupdate);
            this.Controls.Add(this.tbid);
            this.Controls.Add(this.btnsearch);
            this.Controls.Add(this.tbdesc);
            this.Controls.Add(this.tbname);
            this.Controls.Add(this.btnadd);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mainDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnadd;
        private System.Windows.Forms.TextBox tbname;
        private System.Windows.Forms.TextBox tbdesc;
        private System.Windows.Forms.Button btnsearch;
        private System.Windows.Forms.TextBox tbid;
        private System.Windows.Forms.Button btnupdate;
        private System.Windows.Forms.Button btndelete;
        private System.Windows.Forms.Button btnclear;
        private System.Windows.Forms.RadioButton roffline;
        private System.Windows.Forms.RadioButton ronline;
        private System.Windows.Forms.Button btnconnsetings;
        private System.Windows.Forms.ComboBox combotables;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView mainDataGrid;
        //private NorthwindDataSet northwindDataSet;
        private System.Windows.Forms.Label lblrecords;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnfillform;
        private System.Windows.Forms.Button btnsend;
        private System.Windows.Forms.Button btntest;
    }
}

