using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Northwind
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Form2 config = new Form2();

        SqlConnection connection;
        string connstring = "data source = (local); initial catalog = Northwind ; integrated security = yes";

        bool isonline; // indicate the connection state

        //enum connectionstate { online = 0, offline }
        //connectionstate g = connectionstate.online;

        /* when the program starts for the first time, `firstrun` is initialized as true.
         * this routine is used to avoid missing with the initial setup (which is done by 
         * calling `Form_Load()`)
         */
        bool firstrun = true;

        SqlCommand command;
        SqlDataReader reader;

        DataSet categoriesDS;
        //DataTable dt;
        //DataColumn dc;

        SqlDataAdapter adapter;

        string query;

        private void Form1_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(connstring);
            categoriesDS = new DataSet("Northwind");

            // init
            // ronline.Checked = true;
            // roffline.Checked = true;
            // ronline.Enabled = false;
            isonline = true;

            // tini

            tbdesc.Text = tbname.Text = "";
            //

            SetupDataGridViewColumns(mainDataGrid);

            // dc = new DataColumn("CategoryName");

            RefreshView();

            // end of load
            firstrun = false;
        }

        /*
         */
        private void RefreshView()
        {
            query = "SELECT * FROM Categories";

            if (firstrun)
            {
                adapter = new SqlDataAdapter(query, connection);
                adapter.Fill(categoriesDS, "tCategories");
            }

            if (isonline)
            {
                try
                {
                    connection.Open();

                    command = new SqlCommand(query, connection);
                    reader = command.ExecuteReader();

                    // TODO: a datagridview should be here!
                    // done!

                    ClearDataGridView(mainDataGrid);

                    while (reader.Read())
                    {
                        mainDataGrid.Rows.Add(reader["CategoryID"], reader["CategoryName"],
                        reader["Description"], reader["Picture"],
                        reader["LastEditDate"], reader["CreationDate"]);
                    }

                }
                catch { MessageBox.Show("error while load online"); }
                finally { connection.Close(); }

            }
            else
            {

                try
                {
                    // I DO NOT KNOW!
                    // UPDATE: NOW I KNOW...

                    ClearDataGridView(mainDataGrid);

                    mainDataGrid.DataSource = categoriesDS.Tables["tCategories"];
                    //mainDataGrid.DataSource = null;
                }
                catch { MessageBox.Show("error while load offline"); }

            }
        }


        private void SetupDataGridViewColumns(DataGridView source)
        {

            DataGridViewImageColumn imgcolumn = new DataGridViewImageColumn();
            imgcolumn.HeaderText = "Picture";
            imgcolumn.Name = "pic";

            source.Columns.Add("CategID", "Category ID");
            source.Columns.Add("CategName", "Category Name");
            source.Columns.Add("Desc", "Description");
            source.Columns.Add(imgcolumn);
            source.Columns.Add("LastEdit", "Last Edit Date");
            source.Columns.Add("Creation", "Creation Date");
        }

        private void ClearDataGridView(DataGridView source)
        {
            if (!firstrun)
            {
                //foo.DataSource = null;
                // ClearDataGridViewRows(source);
                source.DataSource = null;
                if (isonline)
                {
                    ClearDataGridViewRows(source);
                    ClearDataGridViewColumns(source);
                    SetupDataGridViewColumns(source);
                }
                else
                {
                    //source.DataSource = null;
                    ClearDataGridViewColumns(source);
                }

                //SetupDataGridViewColumns(foo);
            }

        }

        private void ClearDataGridViewRows(DataGridView foo)
        {
            try { foo.Rows.Clear(); }
            catch { MessageBox.Show("cannot clear rows"); }
        }

        private void ClearDataGridViewColumns(DataGridView foo)
        {
            try { foo.Columns.Clear(); }
            catch { MessageBox.Show("cannot clear columns"); }

        }

        private void ClearTextboxes()
        {
            tbname.Text = "";
            tbdesc.Text = "";
            tbid.Text = "";
        }

        private void roffline_CheckedChanged(object sender, EventArgs e)
        {
            if (!firstrun)
            {
                isonline = false;

                // roffline.Enabled = false;
                // ronline.Enabled = true;

                // ClearDataGridView(mainDataGrid);

                RefreshView();
            }
        }

        private void ronline_CheckedChanged(object sender, EventArgs e)
        {
            if (!firstrun)
            {
                isonline = true;

                //roffline.Enabled = true;
                //ronline.Enabled = false;

                //ClearDataGridView(mainDataGrid);

                RefreshView();
            }
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            if (isonline)
            {
                query = "INSERT INTO Categories(CategoryName, Description)" +
                    "VALUES('" + tbname.Text + "','" + tbdesc.Text + "')";

                if (tbname.Text != "" || tbdesc.Text != "")
                {
                    try
                    {
                        command = new SqlCommand(query, connection);
                        connection.Open();

                        command.ExecuteNonQuery();
                        RefreshView();
                        ClearTextboxes();
                    }
                    catch { MessageBox.Show("error while  ajouter online"); }
                    finally { connection.Close(); }
                }
                else
                {
                    MessageBox.Show("Insert values first!");
                }
            }
            else
            {
                query = "";

            }
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            if (isonline)
            {

                query = "SELECT * FROM Categories WHERE CategoryID = " + tbid.Text;

                if (tbid.Text != null)
                {
                    try
                    {
                        connection.Open();

                        //CategoryName, Description
                        command = new SqlCommand(query, connection);

                        reader = command.ExecuteReader();
                        reader.Read();
                        //Description
                        tbname.Text = reader["CategoryName"].ToString();
                        tbdesc.Text = reader["Description"].ToString();
                    }
                    catch { MessageBox.Show("rechercher online"); }
                    finally
                    {
                        reader.Close();
                        connection.Close();
                    }
                }
            }
            else
            {

            }
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {

            query = "UPDATE Categories SET CategoryName = '" + tbname.Text + "', Description = '" + tbdesc.Text +
                   "WHERE CategoryID = " + tbid.Text;

            if (isonline)
            {
                if (tbname.Text != "" || tbdesc.Text != "" || tbid.Text != "")
                {
                    try
                    {
                        connection.Open();

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

                        command = new SqlCommand(query, connection);

                        // cmd.Parameters = param;
                        command.ExecuteNonQuery();

                        RefreshView();
                        ClearTextboxes();
                    }
                    catch { MessageBox.Show("Test"); }
                    finally { connection.Close(); }
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

        private void btndelete_Click(object sender, EventArgs e)
        {
            query = "DELETE Categories WHERE CategoryID = " + tbid.Text;

            if (isonline)
            {
                // online
                try
                {
                    connection.Open();
                    command = new SqlCommand(query, connection);

                    command.ExecuteNonQuery();
                    RefreshView();
                    ClearTextboxes();
                }
                catch { MessageBox.Show("Test"); }
                finally { connection.Close(); }
            }
            else // offline
            {

            }
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            // this is a temporary button
            // UPDATE: it looks like it's effecient for UX

            /* dedicated to all the feelings i have to programming:
             * 
             * what i really love about programming is that it gives you the ability to control
             * a rang of low-level details. This is, for me at least, the ultimate power!
             */

            ClearTextboxes();
        }

        private void btnconnsetings_Click(object sender, EventArgs e)
        {

            config.Show();

            // BUG: How to get changes from a form?

            /* the while-trick is not working as expected!
             * 
             * what shall i do now! i miss C...
             * while (config.Flag) ;
             */

            //conn.Connect
            //    conn.ConnectionString = string.Format("data source = {0}; initial catalog = {1}; integrated security = {2}", 
            //        config.DataSource,
            //        config.InitialCatalog,
            //        config.IntegratedSecurity);
            //

            // MessageBox.Show(config.DataSource + " " + config.InitialCatalog + " " + config.IntegratedSecurity);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // load();
        }

    }
}
