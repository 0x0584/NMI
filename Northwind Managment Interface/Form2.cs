using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.SqlServer.Server;

namespace cnx
{
    public partial class Form2 : Form
    {
        public Form2() { InitializeComponent(); }

        //
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

        int connectionTimeout;
        public int ConnectionTimeout
        {
            get { return connectionTimeout; }
            set { connectionTimeout = value; }
        }
        //

        bool flag;
        public bool Flag
        {
            get { return flag; }
            set { flag = value; }
        }
        //

        bool tst;

        private void Form2_Load(object sender, EventArgs e)
        {
            textBox1.Text = "(local)";
            textBox1.Enabled = false;

            textBox3.Text = "YES";
            textBox3.Enabled = false;

            textBox2.Text = "-1";
            textBox2.Enabled = false;

            radioButton1.Checked = true;

            try
            {
                SqlConnection cnnmaster = new SqlConnection("data source = (local); initial catalog = sys ; integrated security = yes");
                string req = "SELECT DATABASE_NAME   = db_name(s_mf.database_id)" + 
                    "FROM sys.master_files s_mf" +
                    "WHERE s_mf.state = 0 AND -- ONLINE" +
                    "		has_dbaccess(db_name(s_mf.database_id)) = 1 AND" +
                    "		db_name(s_mf.database_id) NOT IN ('master', 'tempdb', 'model', 'msdb') AND " +
                    "		db_name(s_mf.database_id) NOT LIKE 'ReportServer%'" +
                    "GROUP BY s_mf.database_id" +
                    "ORDER BY 1";

                SqlCommand cmd = new SqlCommand(req, cnnmaster);
                SqlDataReader rd = cmd.ExecuteReader();

                while (rd.Read()) comboBox1.Items.Add(rd["Name"]);
                comboBox1.Text = comboBox1.Items[0].ToString();
            }
            catch
            {
                MessageBox.Show("Test");
            }
            //comboBox1.Items.Add("Northwind");


            dataSource = "";
            initialCatalog = "";
            integratedSecurity = "";
            connectionTimeout = -1;

            flag = true;
            tst = true;

            button2.Hide();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox1.Enabled = true;

            textBox3.Text = "";
            textBox3.Enabled = true;

            textBox2.Text = "";
            textBox2.Enabled = true;

            button2.Show();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Text = "(local)";
            textBox1.Enabled = false;

            textBox3.Text = "YES";
            textBox3.Enabled = false;

            textBox2.Text = "-1";
            textBox2.Enabled = false;

            button2.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            flag = false;
            dataSource = textBox1.Text;
            initialCatalog = comboBox1.Text;
            integratedSecurity = textBox3.Text;
            connectionTimeout = int.Parse(textBox2.Text);
            this.Close();
            // MessageBox.Show(DataSource + " " + InitialCatalog + " " + IntegratedSecurity);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (tst)
            {
                this.Height = 270;
                button2.Text = "-";
                tst = false;
            }
            else
            {
                this.Height = 218;
                button2.Text = "+";
                tst = true;
            }
        }

        //END OF CLASS
    }
}
