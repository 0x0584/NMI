using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql; // SqlDataSourceEnumerator
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


        #region Propre methods
        private void LoadInstances(ComboBox c)
        {
            string myServer = Environment.MachineName;
            DataTable servers = SqlDataSourceEnumerator.Instance.GetDataSources();

            for (int i = 0; i < servers.Rows.Count; i++)
            {
                // used to get the servers in the local machine
                if (myServer == servers.Rows[i]["ServerName"].ToString())
                {
                    if ((servers.Rows[i]["InstanceName"] as string) != null)
                        c.Items.Add(servers.Rows[i]["ServerName"] + "\\" + servers.Rows[i]["InstanceName"]);
                    else
                        c.Items.Add(servers.Rows[i]["ServerName"]);
                }

                try { c.Text = c.Items[0].ToString(); }
                catch {    }
            }

        }
        private void GetDatabaseList(ComboBox c)
        {
            // TODO: get databases from an instance
            //

            List<string> list = new List<string>();

            string conString = "server=(local);uid=sa;pwd=0000; database=northwind";

            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();
                string query = "SELECT name FROM sys.databases" +
                    " WHERE name NOT IN ('master', 'tempdb', 'model', 'msdb')" +
                    " AND name NOT LIKE  'ReportServer%'";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (IDataReader dr = cmd.ExecuteReader()) { while (dr.Read()) list.Add(dr[0].ToString()); }
                }

                con.Close();
            }

            foreach (var item in list) c.Items.Add(item);
            c.Text = combodatasrc.Items[0].ToString();
        }
        public void ConnectionSetup(SqlConnection connection)
        {
            connection.ConnectionString = string.Format("data source = {0}; initial catalog = {1}; integrated security = {2}",
                dataSource, initialCatalog, integratedSecurity);
        }
        #endregion

        #region Form methods
        private void ConfigForm_Load(object sender, EventArgs e)
        {
            dataSource = initialCatalog = integratedSecurity = string.Empty;

            #region Initialisation
            txtinit.Text = "(local)";
            txtinteg.Text = "YES";
            txtconntime.Text = "0";
           
            txtinit.Enabled = txtconntime.Enabled = txtinteg.Enabled = false;

            rdefault.Checked = true; // default by default XD
            #endregion

            MessageBox.Show("Loading local SQL Server instances\nThis may take a while");

            try
            {
                // get local instances
                LoadInstances(comboSQLInst);
                // get databases on (local)
                GetDatabaseList(combodatasrc);
            }
            catch { MessageBox.Show("Can't fitch"); }

            // combodatasrc.Items.Add("Northwind");

            dataSource = initialCatalog = integratedSecurity = string.Empty;
            connectionTimeout = 0;

            isfullform = true;

            btnshowdetails.Hide(); // [+]        
        }

        private void ConfigForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing) // User clicked 'X' button
            {
                if (dataSource != string.Empty || initialCatalog != string.Empty
                    || integratedSecurity != string.Empty || txtconntime.Text != string.Empty)
                    e.Cancel = true; // Disable Form closing
            }
        }
        #endregion

        #region Radiobuttons
        private void rcustom_CheckedChanged(object sender, EventArgs e)
        {
            txtinit.Text = txtinteg.Text = string.Empty;
            txtconntime.Text = "0";
            //
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
        #endregion

        #region Buttons: Confirm, ShowDetails and Dimiss
        private void btnconfirm_Click(object sender, EventArgs e)
        {
            // TODO: pass the connection string to the `MainFrom`
            // done!

            dataSource = txtinit.Text;
            initialCatalog = combodatasrc.Text;
            integratedSecurity = txtinteg.Text;
            connectionTimeout = int.Parse(txtconntime.Text);

            if (dataSource != string.Empty
                || initialCatalog != string.Empty
                || integratedSecurity != string.Empty
                || txtconntime.Text != string.Empty)
            {

                MessageBox.Show(dataSource + " " + initialCatalog + " " + integratedSecurity + " " + txtconntime.Text);
                // Solved!
                this.Hide();
            }
            else MessageBox.Show("fill all the fields or leave it to default");
        }

        private void btnshowdetails_Click(object sender, EventArgs e)
        {
            if (isfullform) { this.Height = 270; btnshowdetails.Text = "-"; isfullform = false; }
            else { this.Height = 218; btnshowdetails.Text = "+"; isfullform = true; }
        }

        private void btndimiss_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        #endregion

        //END OF CLASS
    }
}
