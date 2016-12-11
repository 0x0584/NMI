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
                List<string> temp = GetDatabaseList();
                foreach(var item in temp) combdatasrc.Items.Add(item);
                combdatasrc.Text = combdatasrc.Items[0].ToString();
            }
            catch { MessageBox.Show("Can't fitch"); }

           // combdatasrc.Items.Add("Northwind");
            
            dataSource = initialCatalog = integratedSecurity = string.Empty;
            connectionTimeout = 0;

            isfullform = true;

            btnshowdetails.Hide(); // [+]        
        }

        private void rcustom_CheckedChanged(object sender, EventArgs e)
        {
            txtinit.Text = txtinteg.Text = string.Empty;
            txtconntime.Text = "0";
            txtinit.Enabled = txtconntime.Enabled = txtinteg.Enabled = true;

            btnshowdetails.Show(); // [-]
        }

        private void rdefault_CheckedChanged(object sender, EventArgs e)
        {
            txtinit.Text = "(local)";
            txtinteg.Text = "YES";
            txtconntime.Text = "0";

            txtinit.Enabled = txtconntime.Enabled = txtinteg.Enabled = false;
            
            btnshowdetails.Hide(); // [+]
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // TODO: pass the connection string to the `MainFrom`
            // done!

            dataSource = txtinit.Text;
            initialCatalog = combdatasrc.Text;
            integratedSecurity = txtinteg.Text;
            connectionTimeout = int.Parse(txtconntime.Text);

            
            MessageBox.Show(dataSource + " " + initialCatalog + " " + integratedSecurity + " " + txtconntime.Text);
            // Solved!

            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (isfullform) { this.Height = 270; btnshowdetails.Text = "-"; isfullform = false; }
            else { this.Height = 218; btnshowdetails.Text = "+"; isfullform = true; }
        }

        public void ConnectionSetup(SqlConnection connection)
        {
            connection.ConnectionString = string.Format("data source = {0}; initial catalog = {1}; integrated security = {2}",
                dataSource, initialCatalog, integratedSecurity); 
        }

        private List<string> GetDatabaseList()
        {
            List<string> list = new List<string>();

            // Open connection to the database
            string conString = "server=(local);uid=sa;pwd=0000; database=northwind";
            
            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();
                
                // Set up a command with the given query and associate
                // this with the current connection.
                using (SqlCommand cmd = new SqlCommand("SELECT name from sys.databases", con))
                {
                    using (IDataReader dr = cmd.ExecuteReader()) { while (dr.Read()) list.Add(dr[0].ToString()); }
                }

                con.Close();
            }
            return list;
        }
        //END OF CLASS
    }
}
