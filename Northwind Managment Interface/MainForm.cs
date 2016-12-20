using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql; // SqlDataSourceEnumerator, 
using System.Data.SqlTypes;
//
//using EnumerateSQLServers;
//using Moletrator.SQLDocumentor;
//using Microsoft.SqlServer.Server;

namespace Northwind
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }


        DataSet Northwind;

        #region SQL-related variabels 
        SqlConnection connection;
        SqlCommand command;
        SqlDataReader reader;
        SqlDataAdapter adapter;
        #endregion

        string connstring = "data source = (local); initial catalog = Northwind; integrated security = yes";
        string query;

        #region Verification variables
        /* when the program starts for the first time, `firstrun` is initialized as true.
         * this routine is used to avoid missing with the initial setup (which is done by 
         * calling `Form_Load()`). 
         */
        bool firstrun = true;

        // `isonline`, is a bool which indicates the Connection state.
        bool isonline;

        /* this routine is used to avoid the creation of multiple versions of table 
         * in `Northwind`. 
         */
        bool[] iscreated = new bool[10];

        /* indicates the current in-use table */
        string currenttable;

        /* indicates whether the opertation terminates with success or failure */
        bool isvalidated = false;
        #endregion

        /* track the number of updates on then table, which are either adding data 
         or removing data */
        
        int addedrows, removedrows;

        // TODO: find a way to track also updated data
        //

        #region Propre methods
        private string ToSqlstring(string str) { return "[" + str + "]"; }

        private int getindex(string table)
        {
            if (table == "Categories") return 0;
            else if (table == "Customers") return 1;
            else if (table == "Employees") return 2;
            else if (table == "Order Details") return 3;
            else if (table == "Orders") return 4;
            else if (table == "Products") return 5;
            else if (table == "Region") return 6;
            else if (table == "Shippers") return 7;
            else if (table == "Suppliers") return 8;
            else if (table == "Territories") return 9;
            else return -1;
        }
        #endregion

        #region Form related methods
        private void Form1_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(connstring);
            Northwind = new DataSet("Northwind");

            connection.Open();

            // init 
            isonline = true;
            ronline.Checked = true;
            ronline.Enabled = false;
            // tini

            tbdesc.Text = tbname.Text = string.Empty;
            //

            SetupComboBox(combotables);

            for (int i = 0; i < 10; i++) iscreated[i] = false;

            SetupDataGridViewColumns(mainDataGrid);

            RefreshFormView(currenttable);

            // this button is to confirm changes while  offline
            btnsend.Hide();

            label5.Text = label6.Text = string.Empty;

            addedrows = removedrows = 0;

            firstrun = false;  // end of the `firstrun`.
        }
        
        private void RefreshFormView(string table)
        {
            int index;

            if ((index = getindex(table)) != (-1))
            {
                query = "SELECT * FROM " + ToSqlstring(table);

                if (isonline)
                {
                    try
                    {
                        command = new SqlCommand(query, connection);
                        reader = command.ExecuteReader();

                        // TODO: a datagridview should be here!
                        // done!

                        ClearDataGridView(mainDataGrid);

                        SetupDataGridViewRows(mainDataGrid, reader);
                        lblrecords.Text = (mainDataGrid.Rows.Count - 1).ToString();

                    }
                    catch { MessageBox.Show("error while load online"); }
                    finally { reader.Close(); }
                }
                else
                {
                    if (firstrun || !(iscreated[index]))
                    {
                        iscreated[index] = true;
                        adapter = new SqlDataAdapter(query, connection);
                        adapter.Fill(Northwind, "t" + table);
                    }

                    try
                    {
                        // I DO NOT KNOW!
                        // UPDATE: NOW I DO KNOW...

                        ClearDataGridView(mainDataGrid);

                        mainDataGrid.DataSource = Northwind.Tables["t" + table];
                        lblrecords.Text = (mainDataGrid.Rows.Count - 1).ToString();
                    }
                    catch { MessageBox.Show("error while load offline"); }
                }
            }
        }
        #endregion

        #region Setup and manipulate DataGridView, TextBoxes and ComboBoxes

        private void SetupComboBox(ComboBox source)
        {
            source.Items.Add("Categories");
            source.Items.Add("Customers");
            source.Items.Add("Employees");
            source.Items.Add("Order Details");
            source.Items.Add("Orders");
            source.Items.Add("Products");
            source.Items.Add("Region");
            source.Items.Add("Shippers");
            source.Items.Add("Suppliers");
            source.Items.Add("Territories");
            combotables.Text = currenttable = combotables.Items[0].ToString();
        }

        private void combotables_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!firstrun) RefreshFormView((currenttable = combotables.Text));
        }

        private void SetupDataGridViewRows(DataGridView source, SqlDataReader reader)
        {

            #region CustomerDemographics
            if (currenttable == "CustomerDemographics")
                while (reader.Read()) source.Rows.Add(reader[0], reader[1]);
            #endregion

            #region CustomerCustomerDemo
            if (currenttable == "CustomerCustomerDemo")
                while (reader.Read()) source.Rows.Add(reader[0], reader[1]);
            #endregion

            #region Customers
            if (currenttable == "Customers")
                while (reader.Read())
                {
                    source.Rows.Add(reader[0], reader[1], reader[2],
                        reader[3], reader[4], reader[5],
                        reader[6], reader[7], reader[8],
                        reader[9]);
                }
            #endregion

            #region Employees
            if (currenttable == "Employees")
                while (reader.Read())
                {
                    source.Rows.Add(reader[0], reader[1], reader[2],
                        reader[3], reader[4], reader[5],
                        reader[6], reader[7], reader[8],
                        reader[9], reader[10], reader[11],
                        reader[12], reader[13], reader[14],
                        reader[15], reader[16]);
                }
            #endregion

            #region Order Details
            if (currenttable == "Order Details")
                while (reader.Read())
                {
                    source.Rows.Add(reader[0], reader[1], reader[2],
                        reader[3], reader[4]);
                }
            #endregion

            #region EmployeeTerritories
            if (currenttable == "EmployeeTerritories")
                while (reader.Read()) source.Rows.Add(reader[0], reader[1]);
            #endregion

            #region Orders
            if (currenttable == "Orders")
                while (reader.Read())
                {
                    source.Rows.Add(reader[0], reader[1], reader[2],
                        reader[3], reader[4], reader[5],
                        reader[6], reader[7], reader[8],
                        reader[9], reader[10], reader[11],
                        reader[12], reader[13]);
                }
            #endregion

            #region Products
            if (currenttable == "Products")
                while (reader.Read())
                {
                    source.Rows.Add(reader[0], reader[1], reader[2],
                        reader[3], reader[4], reader[5],
                        reader[6], reader[7], reader[8],
                        reader[9]);
                }
            #endregion

            #region Region
            if (currenttable == "Region")
                while (reader.Read()) source.Rows.Add(reader[0], reader[1]);
            #endregion

            #region Shippers
            if (currenttable == "Shippers") while (reader.Read()) source.Rows.Add(reader[0], reader[1], reader[2]);
            #endregion

            #region Categories
            if (currenttable == "Categories")
                while (reader.Read()) source.Rows.Add(reader[0], reader[1], reader[2], reader[3], reader[4], reader[5]);
            #endregion

            #region Suppliers
            if (currenttable == "Suppliers")
                while (reader.Read())
                {
                    source.Rows.Add(reader[0], reader[1], reader[2],
                        reader[3], reader[4], reader[5],
                        reader[6], reader[7], reader[8],
                        reader[9], reader[10], reader[11]);
                }
            #endregion

            #region Territories
            if (currenttable == "Territories")
                while (reader.Read()) source.Rows.Add(reader[0], reader[1], reader[2]);
            #endregion

            //DataGridViewRow r = new DataGridViewRow();
            //int i = 0;
            //foreach (var item in reader) r.Cells[++i].Value = item;

            //while (reader.Read()) source.Rows.Add(r);
        }

        private void SetupDataGridViewColumns(DataGridView source)
        {
            #region CustomerDemographics
            if (currenttable == "CustomerDemographics")
            {
                source.Columns.Add("CustomerTypeID", "CustomerTypeID");
                source.Columns.Add("CustomerDesc", "CustomerDesc");
            }
            #endregion

            #region CustomerCustomerDemo
            if (currenttable == "CustomerCustomerDemo")
            {
                source.Columns.Add("CustomerID", "CustomerID");
                source.Columns.Add("CustomerTypeID", "CustomerTypeID");

            }
            #endregion

            #region Customers
            if (currenttable == "Customers")
            {
                source.Columns.Add("CompanyName", "CompanyName");
                source.Columns.Add("ContactName", "ContactName");
                source.Columns.Add("ContactTitle", "ContactTitle");
                source.Columns.Add("Address", "Address");
                source.Columns.Add("City", "City");
                source.Columns.Add("Region", "Region");
                source.Columns.Add("PostalCode", "PostalCode");
                source.Columns.Add("Country", "Country");
                source.Columns.Add("Phone", "Phone");
                source.Columns.Add("Fax", "Fax");
            }
            #endregion

            #region Employees
            if (currenttable == "Employees")
            {
                source.Columns.Add("EmployeeID", "EmployeeID");
                source.Columns.Add("LastName", "LastName");
                source.Columns.Add("FirstName", "FirstName");
                source.Columns.Add("Title", "Title");
                source.Columns.Add("TitleOfCourtesy", "TitleOfCourtesy");
                source.Columns.Add("BirthDate", "BirthDate");
                source.Columns.Add("HireDate", "HireDate");
                source.Columns.Add("Address", "Address");
                source.Columns.Add("City", "City");
                source.Columns.Add("Region", "Region");
                source.Columns.Add("PostalCode", "PostalCode");
                source.Columns.Add("Country", "Country");
                source.Columns.Add("HomePhone", "HomePhone");
                source.Columns.Add("Extension", "Extension");
                source.Columns.Add("Photo", "Photo");
                source.Columns.Add("Notes", "Notes");
                source.Columns.Add("ReportsTo", "ReportsTo");
                source.Columns.Add("PhotoPath", "PhotoPath");


            }
            #endregion

            #region Order Details
            if (currenttable == "Order Details")
            {
                source.Columns.Add("OrderID", "OrderID");
                source.Columns.Add("ProductID", "ProductID");
                source.Columns.Add("UnitPrice", "UnitPrice");
                source.Columns.Add("Quantity", "Quantity");
                source.Columns.Add("Discount", "Discount");

            }
            #endregion

            #region EmployeeTerritories
            if (currenttable == "EmployeeTerritories")
            {
                source.Columns.Add("EmployeeID", "EmployeeID");
                source.Columns.Add("TerritoryID", "TerritoryID");

            }
            #endregion

            #region Orders
            if (currenttable == "Orders")
            {
                source.Columns.Add("OrderID", "OrderID");
                source.Columns.Add("CustomerID", "CustomerID");
                source.Columns.Add("EmployeeID", "EmployeeID");
                source.Columns.Add("OrderDate", "OrderDate");
                source.Columns.Add("RequiredDate", "RequiredDate");
                source.Columns.Add("ShippedDate", "ShippedDate");
                source.Columns.Add("ShipVia", "ShipVia");
                source.Columns.Add("Freight", "Freight");
                source.Columns.Add("ShipName", "ShipName");
                source.Columns.Add("ShipAddress", "ShipAddress");
                source.Columns.Add("ShipCity", "ShipCity");
                source.Columns.Add("ShipRegion", "ShipRegion");
                source.Columns.Add("ShipPostalCode", "ShipPostalCode");
                source.Columns.Add("ShipCountry", "ShipCountry");

            }
            #endregion

            #region Products
            if (currenttable == "Products")
            {
                source.Columns.Add("ProductID", "ProductID");
                source.Columns.Add("ProductName", "ProductName");
                source.Columns.Add("SupplierID", "SupplierID");
                source.Columns.Add("CategoryID", "CategoryID");
                source.Columns.Add("QuantityPerUnit", "QuantityPerUnit");
                source.Columns.Add("UnitPrice", "UnitPrice");
                source.Columns.Add("UnitsInStock", "UnitsInStock");
                source.Columns.Add("UnitsOnOrder", "UnitsOnOrder");
                source.Columns.Add("ReorderLevel", "ReorderLevel");
                source.Columns.Add("Discontinued", "Discontinued");

            }
            #endregion

            #region Region
            if (currenttable == "Region")
            {
                source.Columns.Add("RegionID", "RegionID");
                source.Columns.Add("RegionDescription", "RegionDescription");
            }
            #endregion

            #region Shippers
            if (currenttable == "Shippers")
            {
                source.Columns.Add("ShipperID", "ShipperID");
                source.Columns.Add("CompanyName", "CompanyName");
                source.Columns.Add("Phone", "Phone");

            }
            #endregion

            #region Categories
            if (currenttable == "Categories")
            {
                source.Columns.Add("CategoryID", "CategoryID");
                source.Columns.Add("CategoryName", "CategoryName");
                source.Columns.Add("Description", "Description");
                DataGridViewImageColumn imgcolumn = new DataGridViewImageColumn();

                imgcolumn.HeaderText = "Picture";
                imgcolumn.Name = "pic";
                source.Columns.Add(imgcolumn);
                source.Columns.Add("LastEditDate", "LastEditDate");
                source.Columns.Add("CreationDate", "CreationDate");

            }
            #endregion

            #region Suppliers
            if (currenttable == "Suppliers")
            {
                source.Columns.Add("SupplierID", "SupplierID");
                source.Columns.Add("CompanyName", "CompanyName");
                source.Columns.Add("ContactName", "ContactName");
                source.Columns.Add("ContactTitle", "ContactTitle");
                source.Columns.Add("Address", "Address");
                source.Columns.Add("City", "City");
                source.Columns.Add("Region", "Region");
                source.Columns.Add("PostalCode", "PostalCode");
                source.Columns.Add("Country", "Country");
                source.Columns.Add("Phone", "Phone");
                source.Columns.Add("Fax", "Fax");
                source.Columns.Add("HomePage", "HomePage");
            }
            #endregion

            #region CustomerDemographics
            if (currenttable == "Territories")
            {
                source.Columns.Add("TerritoryID", "TerritoryID");
                source.Columns.Add("TerritoryDescription", "TerritoryDescription");
                source.Columns.Add("RegionID", "RegionID");
            }
            #endregion

        }

        private void ClearDataGridView(DataGridView source)
        {
            if (!firstrun)
            {
                source.DataSource = null;

                if (isonline)
                {
                    ClearDataGridViewRows(source);
                    ClearDataGridViewColumns(source);
                    SetupDataGridViewColumns(source);
                }
                else { ClearDataGridViewColumns(source); }
            }

        }

        private void ClearDataGridViewRows(DataGridView foo) { foo.Rows.Clear(); }

        private void ClearDataGridViewColumns(DataGridView foo) { foo.Columns.Clear(); }

        private void mainDataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // nothing else matters... 
        }

        private void ClearTextboxes() { tbname.Text = tbdesc.Text = tbid.Text = string.Empty; }

        #endregion

        /*\ This is should be selected in the login form. So this is temnporary. \*/
        #region Handle the RadioButtons
        private void roffline_CheckedChanged(object sender, EventArgs e)
        {
            if (!firstrun)
            {
                if (connection.State != ConnectionState.Closed) connection.Close();
                isonline = false;

                roffline.Enabled = false;
                ronline.Enabled = true;


                RefreshFormView(currenttable);
            }
        }

        private void ronline_CheckedChanged(object sender, EventArgs e)
        {
            if (!firstrun)
            {
                if (connection.State != ConnectionState.Open) connection.Open();
                isonline = true;

                roffline.Enabled = true;
                ronline.Enabled = false;

                RefreshFormView(currenttable);
            }
        }
        #endregion

        #region Buttons: Create Delete Update Search
        private void btnadd_Click(object sender, EventArgs e)
        {
            query = "INSERT INTO Categories(CategoryName, Description)" +
                    "VALUES('" + tbname.Text + "','" + tbdesc.Text + "')";

            if (isonline)
            {
                if (tbname.Text != string.Empty || tbdesc.Text != string.Empty)
                {
                    try
                    {
                        command = new SqlCommand(query, connection);

                        command.ExecuteNonQuery();
                        RefreshFormView(currenttable);
                        ClearTextboxes();
                        isvalidated = true;
                    }
                    catch { MessageBox.Show("error while add online"); }
                }
                else { MessageBox.Show("Insert values first!"); }
            }
            else
            {
                // (this is a bug, i don't understand why the datarow is not working)
                // TODO: this problem shall be solved as soon as possible.
                // 
                try
                {
                    DataRow dr = Northwind.Tables[currenttable].NewRow();
                    dr[0] = tbname.Text;
                    dr[1] = tbdesc.Text;
                    Northwind.Tables[currenttable].Rows.Add(dr);

                    isvalidated = true;
                }
                catch { MessageBox.Show("error while load offline"); }
            }

            if (isvalidated)
            {
                ++addedrows;
                label5.Text = "+ " + addedrows.ToString();
                isvalidated = false;
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
                    }
                }
            }
            else
            {
                //
            }
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {

            query = "UPDATE Categories SET CategoryName = '" + tbname.Text + "', Description = '" + tbdesc.Text +
                   "WHERE CategoryID = " + tbid.Text;

            if (isonline)
            {
                if (tbname.Text != string.Empty ||
                    tbdesc.Text != string.Empty ||
                    tbid.Text != string.Empty)
                {
                    try
                    {
                        // Connection.Open();

                        #region Tests SqlParameter
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

                        //for (int i = 0; i < listp.Count; i++) command.Parameters.Add(listp[i]);

                        #endregion

                        command = new SqlCommand(query, connection);

                        // command.Parameters = param;
                        command.ExecuteNonQuery();

                        RefreshFormView(currenttable);
                        ClearTextboxes();
                    }
                    catch { MessageBox.Show("Test"); }
                    // finally { Connection.Close(); }
                }
                // no input from the user
                else { MessageBox.Show("Insert values first!"); }
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

                    command = new SqlCommand(query, connection);

                    command.ExecuteNonQuery();
                    RefreshFormView(currenttable);
                    ClearTextboxes();
                    isvalidated = true;
                }
                catch { MessageBox.Show("Test"); }
                //finally { Connection.Close(); }
            }
            else // offline
            {

                isvalidated = true;
            }

            if (isvalidated)
            {
                ++removedrows;
                label6.Text = "- " + removedrows.ToString();
                isvalidated = false;
            }
        }
        #endregion

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
            ConfigForm config = new ConfigForm();

            string backup = connection.ConnectionString;

            config.ShowDialog();

            if (connection.State == ConnectionState.Open) connection.Close();

            config.ConnectionSetup(connection);

            if (connection.State == ConnectionState.Closed)
                try { connection.Open(); }
                catch
                {
                    MessageBox.Show("Make sure to fill the informations correctly.\nthe settings will be reverted to the last stalbe state"
                   , "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, 0, false);
                    connection.ConnectionString = backup;
                    connection.Open();
                }


            config.Dispose();
            config.Close();
        }

        private void btnfillform_Click(object sender, EventArgs e)
        {
            FillForm fform = new FillForm();

            fform.GetTableInformation(connection, currenttable);

            fform.ShowDialog();
            fform.Dispose();


            //f.Show();

        }

        private void btnsend_Click(object sender, EventArgs e)
        {
            // i really don't remember what i was trying to do when
            // if first think of this... 
            // UPDATE: this button is to confirm changes made while offline-mode
        }

        private void btntest_Click(object sender, EventArgs e)
        {
            // I
            //

            
        }
    }
}