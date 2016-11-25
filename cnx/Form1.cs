using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace cnx
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Form2 config = new Form2();

        SqlConnection conn;
        /// <summary>
        /// L'etat du connection:
        /// 
        ///    + (true online)
        ///    + (false offline)
        /// </summary>
        bool connted;

        SqlCommand cmd;
        SqlDataReader rd;

        DataSet ds;
        SqlDataAdapter daprod;

        string req;

        private void Form1_Load(object sender, EventArgs e)
        {
            // init
            ronline.Checked = true;
            ronline.Enabled = false;
            tb2.Text = tb1.Text = "";
            connted = true;
            //

            conn = new SqlConnection("data source = .\\; initial catalog = Northwind ; integrated security = yes");
        }

        private void roffline_CheckedChanged(object sender, EventArgs e)
        {
            connted = false; // online
            roffline.Enabled = false;
            ronline.Enabled = true;
        }

        private void ronline_CheckedChanged(object sender, EventArgs e)
        {
            connted = true; // offline
            roffline.Enabled = true;
            ronline.Enabled = false;
        }

        private void btncharger_Click(object sender, EventArgs e)
        {
            if (connted)
            { // online
                try
                {
                    conn.Open();

                    req = "SELECT * FROM Products";
                    cmd = new SqlCommand(req, conn);
                    rd = cmd.ExecuteReader();

                    while (rd.Read()) lbox.Items.Add(rd["ProductName"]);
                    //
                }
                catch { MessageBox.Show("Test"); }
                finally { conn.Close(); }

                MessageBox.Show("done!");
            }
            else
            { // offline

            }
        }

        private void btnajouter_Click(object sender, EventArgs e)
        {
            if (connted)
            {
                if (tb1.Text != "" && tb2.Text != "")
                {
                    // online
                    try
                    {
                        req = "INSERT INTO Categories(CategoryName,Description) VALUES('" +
                           tb1.Text + "','" +
                           tb2.Text + "')";

                        cmd = new SqlCommand(req, conn);
                        conn.Open();
                        cmd.ExecuteNonQuery();

                    }
                    catch { MessageBox.Show("Test"); }
                    finally
                    {
                        conn.Close();
                        tb1.Text = "";
                        tb2.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("Insert values first!");
                }
            }// flag
            else
            {
                // offline
            }
        }

        private void btnrechercher_Click(object sender, EventArgs e)
        {
            if (connted) // online
            {
                if (tbrechercher.Text != null)
                {
                    try
                    {
                        conn.Open();
                        req = "SELECT * FROM Products WHERE ProductID =" + tbrechercher.Text + "";
                        cmd = new SqlCommand(req, conn);

                        rd = cmd.ExecuteReader();
                        rd.Read();
                        tb1.Text = rd["ProductName"].ToString();
                        tb2.Text = rd["Description"].ToString();
                    }
                    catch { MessageBox.Show("Test"); }
                    finally
                    {
                        rd.Close();
                        conn.Close();
                    }
                }
            }
            else // offline
            {

            }
        }

        private void btnmod_Click(object sender, EventArgs e)
        {
            if (connted) // online
            {
                if (tb1.Text != "" && tb2.Text != "")
                {
                    try
                    {
                        conn.Open();
                        req = "UPDATE Categories SET CategoryName = '" + tb1.Text + "'," +
                            " Description = '" + tb2.Text + "'" +
                            " WHERE CategoryID =" + tbrechercher.Text + "";

                        cmd = new SqlCommand(req, conn);
                        cmd.ExecuteNonQuery();
                    }
                    catch { MessageBox.Show("Test"); }
                    finally { conn.Close(); }
                }
                else
                {
                    MessageBox.Show("Insert values first!");
                }
            }
            else // offline
            {

            }
        }

        private void btnsupp_Click(object sender, EventArgs e)
        {
            if (connted)
            {
                // online
                try
                {
                    conn.Open();
                    req = "DELETE Categories WHERE CategoryID=" + tbrechercher.Text + "";
                    cmd = new SqlCommand(req, conn);
                    cmd.ExecuteNonQuery();
                }
                catch { MessageBox.Show("Test"); }
                finally { conn.Close(); }
            }
            else
            {

            }
        }

        private void btnvider_Click(object sender, EventArgs e)
        {
            if (connted)
            {
                // online
                tb1.Text = "";
                tb2.Text = "";
                tbrechercher.Text = "";
            }
            else
            {
                // offline
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            config.Show();
            
            // BUG: How to get changes gtom form?
            // the while-trick is not working as expected!
            // what shall I do now! I miss C...
            // while (config.Flag) ;

            //    conn.ConnectionString = string.Format("data source = {0}; initial catalog = {1}; integrated security = {2}", 
            //        config.DataSource,
            //        config.InitialCatalog,
            //        config.IntegratedSecurity);
            //

            MessageBox.Show(config.DataSource + " " + config.InitialCatalog + " " + config.IntegratedSecurity);
        }

    }
}
