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

namespace Northwind
{
    public partial class ConfigForm : Form
    {
        public ConfigForm() { InitializeComponent(); }

        //
        string dataSource, initialCatalog, integratedSecurity;
        int connectionTimeout;
        //

        bool isfullform;

        private void ConfigForm_Load(object sender, EventArgs e)
        {
            dataSource = initialCatalog = integratedSecurity = string.Empty;

            txtinit.Text = "(local)";
            txtinteg.Text = "YES";
            txtconntime.Text = "0";

            txtinit.Enabled = txtconntime.Enabled = txtinteg.Enabled = false;

            rdefault.Checked = true;

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

                SqlCommand command = new SqlCommand(req, cnnmaster);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read()) combdatasrc.Items.Add(reader["Name"]);
                combdatasrc.Text = combdatasrc.Items[0].ToString();
            }
            catch { MessageBox.Show("Can't fitch"); }

            combdatasrc.Items.Add("Northwind");
            
            dataSource = initialCatalog = integratedSecurity = string.Empty;
            connectionTimeout = 0;

            isfullform = true;

            btnshowdetails.Hide();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            txtinit.Text = txtinteg.Text = string.Empty;
            txtconntime.Text = "0";
            txtinit.Enabled = txtconntime.Enabled = txtinteg.Enabled = true;

            btnshowdetails.Show();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            txtinit.Text = "(local)";
            txtinteg.Text = "YES";
            txtconntime.Text = "0";

            txtinit.Enabled = txtconntime.Enabled = txtinteg.Enabled = false;
            
            btnshowdetails.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // TODO: pass the connection string to the `MainFrom`
            //

            dataSource = txtinit.Text;
            initialCatalog = combdatasrc.Text;
            integratedSecurity = txtinteg.Text;
            connectionTimeout = int.Parse(txtconntime.Text);

            
            MessageBox.Show(dataSource + " " + initialCatalog + " " + integratedSecurity);
            
            // ConnectionSetup(); // <--- the MainForm connection should be here somehow...
            // Solved!



            //this.Close();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (isfullform)
            {
                this.Height = 270;
                btnshowdetails.Text = "-";
                isfullform = false;
            }
            else
            {
                this.Height = 218;
                btnshowdetails.Text = "+";
                isfullform = true;
            }
        }

        public void ConnectionSetup(SqlConnection connection)
        {
            connection.ConnectionString = string.Format("data source = {0}; initial catalog = {1}; integrated security = {2}",
                dataSource, initialCatalog, integratedSecurity); 
        }
        //END OF CLASS
    }
}
