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
        bool connected;

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
            tbdesc.Text = tbname.Text = "";
            connected = true;
            //

            conn = new SqlConnection("data source = (local); initial catalog = Northwind ; integrated security = yes");
        }

        private void roffline_CheckedChanged(object sender, EventArgs e)
        {
            connected = false; // online
            roffline.Enabled = false;
            ronline.Enabled = true;
        }

        private void ronline_CheckedChanged(object sender, EventArgs e)
        {
            connected = true; // offline
            roffline.Enabled = true;
            ronline.Enabled = false;
        }


        private void btncharger_Click(object sender, EventArgs e)
        {
            if (connected) // online
            {
                try
                {
                    conn.Open();

                    req = "SELECT * FROM Categories";

                    cmd = new SqlCommand(req, conn);
                    rd = cmd.ExecuteReader();

                    // a datagridview should be here!
                    while (rd.Read()) lbox.Items.Add(rd["CategoryName"]);
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
            if (connected)
            {
                if (tbname.Text != "" || tbdesc.Text != "")
                {
                    // online
                    try
                    {
                        req = "INSERT INTO Categories(CategoryName, Description)" +
                            "VALUES('" + tbname.Text + "','" + tbdesc.Text + "')";

                        cmd = new SqlCommand(req, conn);
                        conn.Open();

                        cmd.ExecuteNonQuery();

                    }
                    catch { MessageBox.Show("Test"); }
                    finally
                    {
                        conn.Close();
                        tbname.Text = "";
                        tbdesc.Text = "";
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
            if (connected) // online
            {
                if (tbid.Text != null)
                {
                    try
                    {
                        conn.Open();

                        //CategoryName, Description
                        req = "SELECT * FROM Categories WHERE CategoryID = " + tbid.Text;

                        cmd = new SqlCommand(req, conn);

                        rd = cmd.ExecuteReader();
                        rd.Read();
                        //Description
                        tbname.Text = rd["CategoryName"].ToString();
                        tbdesc.Text = rd["Description"].ToString();
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
            if (connected) // online
            {
                if (tbname.Text != "" || tbdesc.Text != "" || tbid.Text != "")
                {
                    try
                    {
                        conn.Open();

                        //
                        //List<SqlParameter> listp = new List<SqlParameter>();

                        //listp[0] = new SqlParameter("@prodname", SqlDbType.VarChar);
                        //listp[0].Value = tbname.Text;

                        //listp[1] = new SqlParameter("@unit", SqlDbType.VarChar);
                        //listp[1].Value = tbname.Text;

                        //listp[2] = new SqlParameter("@prodid", SqlDbType.Int);
                        //listp[2].Value = tbname.Text;
                        ////

                        //req = "UPDATE Products SET ProductName = @prodname, UnitsInStock = @unit " +
                        //    "WHERE ProductID = @prodid";

                        //for (int i = 0; i < listp.Count; i++) cmd.Parameters.Add(listp[i]);


                        req = "UPDATE Categories SET CategoryName = '" + tbname.Text +"', Description = '" + tbdesc.Text +
                               "WHERE CategoryID = " + tbid.Text;

                        cmd = new SqlCommand(req, conn);

                        // cmd.Parameters = param;
                        cmd.ExecuteNonQuery();
                    }
                    catch { MessageBox.Show("Test"); }
                    finally { conn.Close(); }
                }
                else // no input from the user
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
            if (connected)
            {
                // online
                try
                {
                    conn.Open();
                    req = "DELETE Categories WHERE CategoryID = " + tbid.Text;
                    cmd = new SqlCommand(req, conn);
                    cmd.ExecuteNonQuery();
                }
                catch { MessageBox.Show("Test"); }
                finally { conn.Close(); }
            }
            else // offline
            {

            }
        }

        private void btnvider_Click(object sender, EventArgs e)
        {
            // this is a temporary button
            //
            // dedicated to all the feelings i have to clang:
            // what i really love about programming is that it gives you the ability to control
            // a rang of low-level of detaills. This is, for me at least, the ultimate power!

            if (connected)
            {
                // online
                tbname.Text = "";
                tbdesc.Text = "";
                tbid.Text = "";
            }
            else
            {
                // offline
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            config.Show();

            // BUG: How to get changes from a form?
            //the while-trick is not working as expected!
            // what shall I do now! I miss C...
            // while (config.Flag) ;
            //conn.Connect
            //    conn.ConnectionString = string.Format("data source = {0}; initial catalog = {1}; integrated security = {2}", 
            //        config.DataSource,
            //        config.InitialCatalog,
            //        config.IntegratedSecurity);
            //

            // MessageBox.Show(config.DataSource + " " + config.InitialCatalog + " " + config.IntegratedSecurity);
        }

    }
}
