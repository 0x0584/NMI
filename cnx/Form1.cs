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

        SqlConnection cnx;
        SqlCommand cmd;
        SqlDataReader rd;

        DataSet ds;
        SqlDataAdapter daprod;

        string req;
        /// <summary>
        /// L'etat du connection:
        /// 
        ///    + (true online)
        ///    + (false offline)
        /// </summary>
        bool connted;

        private void Form1_Load(object sender, EventArgs e)
        {
            ronline.Checked = true;
            ronline.Enabled = false;
            tb2.Text = tb1.Text = "";
            connted = true;
            //

            cnx = new SqlConnection("data source=.\\; initial catalog=Northwind ; integrated security=yes");
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
                    cnx.Open();

                    req = "SELECT * FROM Products";
                    cmd = new SqlCommand(req, cnx);
                    rd = cmd.ExecuteReader();

                    while (rd.Read()) lbox.Items.Add(rd["ProductName"]);
                    //
                }
                catch { MessageBox.Show("Test"); }
                finally { cnx.Close(); }

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

                        cmd = new SqlCommand(req, cnx);
                        cnx.Open();
                        cmd.ExecuteNonQuery();

                    }
                    catch { MessageBox.Show("Test"); }
                    finally
                    {
                        cnx.Close();
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
                        cnx.Open();
                        req = "SELECT * FROM Products WHERE ProductID =" + tbrechercher.Text + "";
                        cmd = new SqlCommand(req, cnx);

                        rd = cmd.ExecuteReader();
                        rd.Read();
                        tb1.Text = rd["ProductName"].ToString();
                        tb2.Text = rd["Description"].ToString();
                    }
                    catch { MessageBox.Show("Test"); }
                    finally
                    {
                        rd.Close();
                        cnx.Close();
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
                        cnx.Open();
                        req = "UPDATE Categories SET CategoryName = '" + tb1.Text + "'," +
                            " Description = '" + tb2.Text + "'" +
                            " WHERE CategoryID =" + tbrechercher.Text + "";

                        cmd = new SqlCommand(req, cnx);
                        cmd.ExecuteNonQuery();
                    }
                    catch { MessageBox.Show("Test"); }
                    finally { cnx.Close(); }
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
                    cnx.Open();
                    req = "DELETE Categories WHERE CategoryID=" + tbrechercher.Text + "";
                    cmd = new SqlCommand(req, cnx);
                    cmd.ExecuteNonQuery();
                }
                catch { MessageBox.Show("Test"); }
                finally { cnx.Close(); }
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

    }
}
