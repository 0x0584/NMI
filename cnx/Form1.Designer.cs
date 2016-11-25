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
            this.btncharger = new System.Windows.Forms.Button();
            this.lbox = new System.Windows.Forms.ListBox();
            this.btnajouter = new System.Windows.Forms.Button();
            this.tb1 = new System.Windows.Forms.TextBox();
            this.tb2 = new System.Windows.Forms.TextBox();
            this.btnrechercher = new System.Windows.Forms.Button();
            this.tbrechercher = new System.Windows.Forms.TextBox();
            this.btnmod = new System.Windows.Forms.Button();
            this.btnsupp = new System.Windows.Forms.Button();
            this.btnvider = new System.Windows.Forms.Button();
            this.roffline = new System.Windows.Forms.RadioButton();
            this.ronline = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // btncharger
            // 
            this.btncharger.Location = new System.Drawing.Point(232, 12);
            this.btncharger.Name = "btncharger";
            this.btncharger.Size = new System.Drawing.Size(75, 23);
            this.btncharger.TabIndex = 0;
            this.btncharger.Text = "charger";
            this.btncharger.UseVisualStyleBackColor = true;
            this.btncharger.Click += new System.EventHandler(this.btncharger_Click);
            // 
            // lbox
            // 
            this.lbox.FormattingEnabled = true;
            this.lbox.Location = new System.Drawing.Point(12, 5);
            this.lbox.Name = "lbox";
            this.lbox.Size = new System.Drawing.Size(214, 251);
            this.lbox.TabIndex = 1;
            // 
            // btnajouter
            // 
            this.btnajouter.Location = new System.Drawing.Point(338, 51);
            this.btnajouter.Name = "btnajouter";
            this.btnajouter.Size = new System.Drawing.Size(75, 23);
            this.btnajouter.TabIndex = 2;
            this.btnajouter.Text = "ajouter";
            this.btnajouter.UseVisualStyleBackColor = true;
            this.btnajouter.Click += new System.EventHandler(this.btnajouter_Click);
            // 
            // tb1
            // 
            this.tb1.Location = new System.Drawing.Point(232, 53);
            this.tb1.Name = "tb1";
            this.tb1.Size = new System.Drawing.Size(100, 20);
            this.tb1.TabIndex = 3;
            // 
            // tb2
            // 
            this.tb2.Location = new System.Drawing.Point(232, 79);
            this.tb2.Name = "tb2";
            this.tb2.Size = new System.Drawing.Size(100, 20);
            this.tb2.TabIndex = 4;
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
            // tbrechercher
            // 
            this.tbrechercher.Location = new System.Drawing.Point(323, 12);
            this.tbrechercher.Name = "tbrechercher";
            this.tbrechercher.Size = new System.Drawing.Size(100, 20);
            this.tbrechercher.TabIndex = 6;
            // 
            // btnmod
            // 
            this.btnmod.Location = new System.Drawing.Point(338, 80);
            this.btnmod.Name = "btnmod";
            this.btnmod.Size = new System.Drawing.Size(75, 23);
            this.btnmod.TabIndex = 7;
            this.btnmod.Text = "modifier";
            this.btnmod.UseVisualStyleBackColor = true;
            this.btnmod.Click += new System.EventHandler(this.btnmod_Click);
            // 
            // btnsupp
            // 
            this.btnsupp.Location = new System.Drawing.Point(338, 119);
            this.btnsupp.Name = "btnsupp";
            this.btnsupp.Size = new System.Drawing.Size(75, 23);
            this.btnsupp.TabIndex = 8;
            this.btnsupp.Text = "supprimer";
            this.btnsupp.UseVisualStyleBackColor = true;
            this.btnsupp.Click += new System.EventHandler(this.btnsupp_Click);
            // 
            // btnvider
            // 
            this.btnvider.Location = new System.Drawing.Point(232, 163);
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
            this.roffline.Location = new System.Drawing.Point(413, 240);
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
            this.ronline.Location = new System.Drawing.Point(413, 217);
            this.ronline.Name = "ronline";
            this.ronline.Size = new System.Drawing.Size(55, 17);
            this.ronline.TabIndex = 10;
            this.ronline.TabStop = true;
            this.ronline.Text = "Online";
            this.ronline.UseVisualStyleBackColor = true;
            this.ronline.CheckedChanged += new System.EventHandler(this.ronline_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(523, 263);
            this.Controls.Add(this.ronline);
            this.Controls.Add(this.roffline);
            this.Controls.Add(this.btnvider);
            this.Controls.Add(this.btnsupp);
            this.Controls.Add(this.btnmod);
            this.Controls.Add(this.tbrechercher);
            this.Controls.Add(this.btnrechercher);
            this.Controls.Add(this.tb2);
            this.Controls.Add(this.tb1);
            this.Controls.Add(this.btnajouter);
            this.Controls.Add(this.lbox);
            this.Controls.Add(this.btncharger);
            this.MaximumSize = new System.Drawing.Size(531, 290);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btncharger;
        private System.Windows.Forms.ListBox lbox;
        private System.Windows.Forms.Button btnajouter;
        private System.Windows.Forms.TextBox tb1;
        private System.Windows.Forms.TextBox tb2;
        private System.Windows.Forms.Button btnrechercher;
        private System.Windows.Forms.TextBox tbrechercher;
        private System.Windows.Forms.Button btnmod;
        private System.Windows.Forms.Button btnsupp;
        private System.Windows.Forms.Button btnvider;
        private System.Windows.Forms.RadioButton roffline;
        private System.Windows.Forms.RadioButton ronline;
    }
}

