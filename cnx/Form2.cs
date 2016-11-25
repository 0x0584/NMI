using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace cnx
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        string dataSource = "";

        public string DataSource
        {
            get { return dataSource; }
            set { dataSource = value; }
        }
        string initialCatalog = "";

        public string InitialCatalog
        {
            get { return initialCatalog; }
            set { initialCatalog = value; }
        }
        string integratedSecurity = "";

        public string IntegratedSecurity
        {
            get { return integratedSecurity; }
            set { integratedSecurity = value; }
        }

        bool flag;

        public bool Flag
        {
            get { return flag; }
            set { flag = value; }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            textBox1.Text = "(local)";
            textBox1.Enabled = false;
            
            textBox3.Text = "YES";
            textBox3.Enabled = false;

            radioButton1.Checked = true;

            comboBox1.Items.Add("Northwind");
            comboBox1.Text = comboBox1.Items[0].ToString();

            dataSource = "";
            initialCatalog  = "";
            integratedSecurity  = "";

            flag = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox1.Enabled = true;

            textBox3.Text = "";
            textBox3.Enabled = true;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Text = "(local)";
            textBox1.Enabled = false;

            textBox3.Text = "YES";
            textBox3.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            flag = false;
            dataSource = textBox1.Text;
            initialCatalog = comboBox1.Text;
            integratedSecurity = textBox3.Text;
            this.Close();
           // MessageBox.Show(DataSource + " " + InitialCatalog + " " + IntegratedSecurity);
        }



    }
}
