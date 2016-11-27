namespace cnx
{
    partial class Form1
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
            this.lbox = new System.Windows.Forms.ListBox();
            this.btnajouter = new System.Windows.Forms.Button();
            this.tbname = new System.Windows.Forms.TextBox();
            this.tbdesc = new System.Windows.Forms.TextBox();
            this.btnrechercher = new System.Windows.Forms.Button();
            this.tbid = new System.Windows.Forms.TextBox();
            this.btnmod = new System.Windows.Forms.Button();
            this.btnsupp = new System.Windows.Forms.Button();
            this.btnvider = new System.Windows.Forms.Button();
            this.roffline = new System.Windows.Forms.RadioButton();
            this.ronline = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbox
            // 
            this.lbox.FormattingEnabled = true;
            this.lbox.Location = new System.Drawing.Point(12, 5);
            this.lbox.Name = "lbox";
            this.lbox.Size = new System.Drawing.Size(214, 212);
            this.lbox.TabIndex = 1;
            // 
            // btnajouter
            // 
            this.btnajouter.Location = new System.Drawing.Point(436, 41);
            this.btnajouter.Name = "btnajouter";
            this.btnajouter.Size = new System.Drawing.Size(75, 23);
            this.btnajouter.TabIndex = 2;
            this.btnajouter.Text = "ajouter";
            this.btnajouter.UseVisualStyleBackColor = true;
            this.btnajouter.Click += new System.EventHandler(this.btnajouter_Click);
            // 
            // tbname
            // 
            this.tbname.Location = new System.Drawing.Point(283, 44);
            this.tbname.Name = "tbname";
            this.tbname.Size = new System.Drawing.Size(146, 20);
            this.tbname.TabIndex = 3;
            // 
            // tbdesc
            // 
            this.tbdesc.Location = new System.Drawing.Point(283, 79);
            this.tbdesc.Name = "tbdesc";
            this.tbdesc.Size = new System.Drawing.Size(146, 20);
            this.tbdesc.TabIndex = 4;
            // 
            // btnrechercher
            // 
            this.btnrechercher.Location = new System.Drawing.Point(436, 12);
            this.btnrechercher.Name = "btnrechercher";
            this.btnrechercher.Size = new System.Drawing.Size(75, 23);
            this.btnrechercher.TabIndex = 5;
            this.btnrechercher.Text = "rechercher";
            this.btnrechercher.UseVisualStyleBackColor = true;
            this.btnrechercher.Click += new System.EventHandler(this.btnrechercher_Click);
            // 
            // tbid
            // 
            this.tbid.Location = new System.Drawing.Point(283, 12);
            this.tbid.Name = "tbid";
            this.tbid.Size = new System.Drawing.Size(146, 20);
            this.tbid.TabIndex = 6;
            // 
            // btnmod
            // 
            this.btnmod.Location = new System.Drawing.Point(436, 70);
            this.btnmod.Name = "btnmod";
            this.btnmod.Size = new System.Drawing.Size(75, 23);
            this.btnmod.TabIndex = 7;
            this.btnmod.Text = "modifier";
            this.btnmod.UseVisualStyleBackColor = true;
            this.btnmod.Click += new System.EventHandler(this.btnmod_Click);
            // 
            // btnsupp
            // 
            this.btnsupp.Location = new System.Drawing.Point(436, 99);
            this.btnsupp.Name = "btnsupp";
            this.btnsupp.Size = new System.Drawing.Size(75, 23);
            this.btnsupp.TabIndex = 8;
            this.btnsupp.Text = "supprimer";
            this.btnsupp.UseVisualStyleBackColor = true;
            this.btnsupp.Click += new System.EventHandler(this.btnsupp_Click);
            // 
            // btnvider
            // 
            this.btnvider.Location = new System.Drawing.Point(354, 167);
            this.btnvider.Name = "btnvider";
            this.btnvider.Size = new System.Drawing.Size(75, 23);
            this.btnvider.TabIndex = 9;
            this.btnvider.Text = "vider";
            this.btnvider.UseVisualStyleBackColor = true;
            this.btnvider.Click += new System.EventHandler(this.btnvider_Click);
            // 
            // roffline
            // 
            this.roffline.AutoSize = true;
            this.roffline.Location = new System.Drawing.Point(445, 196);
            this.roffline.Name = "roffline";
            this.roffline.Size = new System.Drawing.Size(55, 17);
            this.roffline.TabIndex = 10;
            this.roffline.TabStop = true;
            this.roffline.Text = "Offline";
            this.roffline.UseVisualStyleBackColor = true;
            this.roffline.CheckedChanged += new System.EventHandler(this.roffline_CheckedChanged);
            // 
            // ronline
            // 
            this.ronline.AutoSize = true;
            this.ronline.Location = new System.Drawing.Point(445, 173);
            this.ronline.Name = "ronline";
            this.ronline.Size = new System.Drawing.Size(55, 17);
            this.ronline.TabIndex = 10;
            this.ronline.TabStop = true;
            this.ronline.Text = "Online";
            this.ronline.UseVisualStyleBackColor = true;
            this.ronline.CheckedChanged += new System.EventHandler(this.ronline_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(241, 163);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 36);
            this.button1.TabIndex = 11;
            this.button1.Text = "configure the connection";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(283, 115);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(146, 21);
            this.comboBox1.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(233, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "id";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(233, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(233, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Desc";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(233, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(523, 226);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ronline);
            this.Controls.Add(this.roffline);
            this.Controls.Add(this.btnvider);
            this.Controls.Add(this.btnsupp);
            this.Controls.Add(this.btnmod);
            this.Controls.Add(this.tbid);
            this.Controls.Add(this.btnrechercher);
            this.Controls.Add(this.tbdesc);
            this.Controls.Add(this.tbname);
            this.Controls.Add(this.btnajouter);
            this.Controls.Add(this.lbox);
            this.MaximumSize = new System.Drawing.Size(531, 290);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbox;
        private System.Windows.Forms.Button btnajouter;
        private System.Windows.Forms.TextBox tbname;
        private System.Windows.Forms.TextBox tbdesc;
        private System.Windows.Forms.Button btnrechercher;
        private System.Windows.Forms.TextBox tbid;
        private System.Windows.Forms.Button btnmod;
        private System.Windows.Forms.Button btnsupp;
        private System.Windows.Forms.Button btnvider;
        private System.Windows.Forms.RadioButton roffline;
        private System.Windows.Forms.RadioButton ronline;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

