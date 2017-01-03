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

        string dataSource, initialCatalog, integratedSecurity;
        int connectionTimeout;
        string instance, userid, password;

        bool isfirstrun = true;
        bool requireuserinfo = false;

        public ConfigForm()
        {
            InitializeComponent();
            this.Height = 71;
            dataSource = initialCatalog = integratedSecurity = instance = userid = password = string.Empty;
            connectionTimeout = 0;
            lblwarning.Text = string.Empty;
            txtuserid.Text = txtpassword.Text = "#";
        }

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
                catch
                {
                    MessageBox.Show("No SQL Server Instances was found!", "Information",
                        MessageBoxButtons.OK, MessageBoxIcon.Information,
                        MessageBoxDefaultButton.Button1, 0, false);
                }
            }

        }

        // index don't know why index create this function but it looks 
        // like index was thinking of creating another managment studio! 
        /* 
        private void GetDatabaseList(ComboBox c)
        {
            // TODO: get databases from an instance
            // 

            List<string> list = new List<string>();

            string conString = "server=(local);uid=sa;pwd=0000; database=northwind";

            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();
                string insertquery = "SELECT name FROM sys.databases" +
                    " WHERE name NOT IN ('master', 'tempdb', 'model', 'msdb')" +
                    " AND name NOT LIKE  'ReportServer%'";

                using (SqlCommand command = new SqlCommand(insertquery, con))
                {
                    using (IDataReader dr = command.ExecuteReader()) { while (dr.Read()) list.Add(dr[0].ToString()); }
                }

                con.Close();
            }

            foreach (var item in list) c.Items.Add(item);
            c.Text = c.Items[0].ToString();
        }
        */
        public void ConnectionSetup(SqlConnection connection)
        {
            string str;

            if (userid == "#" && password == "#") str = "";
            else str = string.Format("uid={0};pwd={1};", userid, password);

            connection.ConnectionString = string.Format("server={0};" + str + " database={1}; integrated security = {2}",
                dataSource, initialCatalog, integratedSecurity);
        }
        #endregion

        #region Form methods
        private void ConfigForm_Load(object sender, EventArgs e)
        {
            #region Initialisation
            txtconntime.Text = "0";
            txtconntime.Enabled = false;
            rdefault.Checked = true; // default is checked by default 
            #endregion

            // TODO: index have to figure out how to show an information 
            //       window while the instances are loading...
            //

            //Message msg = new Message("Loading local SQL Server instances\nThis may take a while");
            //msg.ShowDialog();
            
            MessageBox.Show("Loading the instances may take a while...", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1, 0, false);

            try { LoadInstances(comboSQLInst);   /* get local instances */ }
            catch { MessageBox.Show("Can't fitch"); }

            dataSource = initialCatalog = integratedSecurity = string.Empty;
            connectionTimeout = 0;

            isfirstrun = false;
        }

        private void ConfigForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // TODO: index don't know what to do...
            //

            /*
            if (e.CloseReason == CloseReason.UserClosing) // User clicked 'X' button
            {
                if (dataSource != string.Empty || initialCatalog != string.Empty
                    || integratedSecurity != string.Empty || txtconntime.Text != string.Empty)
                    e.Cancel = true; // Disable Form closing
            }
             */
        }
        #endregion

        #region Radiobuttons
        private void rcustom_CheckedChanged(object sender, EventArgs e)
        {
            comboWinAuthn.Enabled = true;
            txtconntime.Enabled = true;
        }

        private void rdefault_CheckedChanged(object sender, EventArgs e)
        {
            comboWinAuthn.Text = comboWinAuthn.Items[0].ToString();
            txtconntime.Text = Convert.ToString(15);
            comboWinAuthn.Enabled = false;
            txtconntime.Enabled = false;

            this.Height = 169;
        }
        #endregion

        
        private void btnconfirm_Click(object sender, EventArgs e)
        {
            bool valide = true;
            // TODO: pass the connection string to the `MainFrom`
            // done!

            dataSource = comboSQLInst.Text;
            initialCatalog = "Northwind";
            integratedSecurity = comboWinAuthn.Text;
            connectionTimeout = int.Parse(txtconntime.Text);
            userid = txtuserid.Text;
            password = txtpassword.Text;

            if (txtconntime.Text.Trim().CompareTo(string.Empty) != 0 && connectionTimeout > 0)
            {
                if (requireuserinfo) // SSPI is NO
                {
                    if (userid.Trim().CompareTo(string.Empty) == 0 || password.Trim().CompareTo(string.Empty) == 0)
                    {
                        valide = false;
                        lblwarning.Text = "the username (and/or the password) is empty.";
                    }
                }
                // Solved!

                MessageBox.Show(dataSource + " " + initialCatalog + " " + integratedSecurity + " " + txtconntime.Text);
                if (valide) this.Hide();
            }
        }
       

        private void comboSQLInst_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (comboSQLInst.Items[0] == null)
            //    MessageBox.Show("No SQL Server instances was found!\n(Check if the MSSQL Server Service is running)");
            //

            if (!isfirstrun) this.Height = 169;

        }

        private void comboWinAuthn_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isfirstrun)
            {
                if (comboWinAuthn.Text == comboWinAuthn.Items[0].ToString())
                {
                    this.Height = 169;
                    requireuserinfo = false;
                }
                else if (comboWinAuthn.Text == comboWinAuthn.Items[1].ToString())
                {
                    this.Height = 226;
                    txtpassword.Text = "";
                    txtuserid.Text = "";
                    requireuserinfo = true;
                }

            }
        }

        //END OF CLASS
    }
}
