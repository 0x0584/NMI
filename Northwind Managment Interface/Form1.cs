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
        SqlCommand command;
        SqlDataReader reader;
        SqlDataAdapter adapter;
        string connstring = "data source = (local); initial catalog = Northwind ; integrated security = yes";
        string query;

        DataSet Northwind;

        /* when the program starts for the first time, `firstrun` is initialized as true.
         * this routine is used to avoid missing with the initial setup (which is done by 
         * calling `Form_Load()`). 
         */
        bool firstrun = true;

        // `isonline`, is a bool which indicates the connection state.
        bool isonline;

        /* this routine is used to avoid the creation of multiple versions of table 
         * in `Northwind`. 
         */
        bool[] iscreated = new bool[10];


        string currenttable;

        private void Form1_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(connstring);
            Northwind = new DataSet("Northwind");

            // init
            connection.Open();
            isonline = true;
            ronline.Checked = true;
            ronline.Enabled = false;

            // tini

            tbdesc.Text = tbname.Text = "";
            //

            SetupComboBox(comboBox1);

            for (int i = 0; i < 10; i++) iscreated[i] = false;

            SetupDataGridViewColumns(mainDataGrid);

            RefreshView(currenttable);

            firstrun = false;  // end of the `firstrun`.

        }

        private int getindex(string table)
        {
            if (table == "Categories") return 0;
            else if (table == "Customers") return 1;
            else if (table == "Employees") return 2;
            else if (table == "[Order Details]") return 3;
            else if (table == "Orders") return 4;
            else if (table == "Products") return 5;
            else if (table == "Region") return 6;
            else if (table == "Shippers") return 7;
            else if (table == "Suppliers") return 8;
            else if (table == "Territories") return 9;
            else return -1;
        }

        private void RefreshView(string table)
        {
            int index = getindex(table);

            if (index != (-1))
            {
                query = "SELECT * FROM " + table;

                if (firstrun || !(iscreated[index]))
                {
                    iscreated[index] = true;
                    adapter = new SqlDataAdapter(query, connection);
                    adapter.Fill(Northwind, "t" + table);
                }

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
                        
                    }
                    catch { MessageBox.Show("error while load online"); }
                    finally { reader.Close(); }
                }
                else
                {
                    try
                    {
                        // I DO NOT KNOW!
                        // UPDATE: NOW I KNOW...

                        ClearDataGridView(mainDataGrid);

                        mainDataGrid.DataSource = Northwind.Tables["tCategories"];
                    }
                    catch { MessageBox.Show("error while load offline"); }
                }
            }
        }

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
            comboBox1.Text = currenttable = comboBox1.Items[0].ToString();
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

            #region [Order Details]
            if (currenttable == "[Order Details]")
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
                while (reader.Read()) source.Rows.Add(reader[0], reader[1], reader[2]);
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

            #region [Order Details]
            if (currenttable == "[Order Details]")
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

        private void ClearTextboxes() { tbname.Text = tbdesc.Text = tbid.Text = ""; }

        #endregion

        #region Handle the RadioButtons
        private void roffline_CheckedChanged(object sender, EventArgs e)
        {
            if (!firstrun)
            {
                if (connection.State != ConnectionState.Closed) connection.Close();
                isonline = false;

                roffline.Enabled = false;
                ronline.Enabled = true;

                RefreshView(currenttable);
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

                RefreshView(currenttable);
            }
        }
        #endregion

        private void btnadd_Click(object sender, EventArgs e)
        {
            query = "INSERT INTO Categories(CategoryName, Description, Creation Date, LastEditDate)" +
                    "VALUES('" + tbname.Text + "','" + tbdesc.Text + "')";

            if (isonline)
            {
                if (tbname.Text != "" || tbdesc.Text != "")
                {
                    try
                    {
                        command = new SqlCommand(query, connection);

                        command.ExecuteNonQuery();
                        RefreshView(currenttable);
                        ClearTextboxes();
                    }
                    catch { MessageBox.Show("error while  ajouter online"); }
                }
                else { MessageBox.Show("Insert values first!"); }
            }
            else
            {

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
                        // connection.Open();

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

                        //for (int i = 0; i < listp.Count; i++) cmd.Parameters.Add(listp[i]);

                        #endregion

                        command = new SqlCommand(query, connection);

                        // cmd.Parameters = param;
                        command.ExecuteNonQuery();

                        RefreshView(currenttable);
                        ClearTextboxes();
                    }
                    catch { MessageBox.Show("Test"); }
                    // finally { connection.Close(); }
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
                    RefreshView(currenttable);
                    ClearTextboxes();
                }
                catch { MessageBox.Show("Test"); }
                //finally { connection.Close(); }
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


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text.Contains(' ')) currenttable = comboBox1.Text;

            MessageBox.Show(currenttable);
        }
    }
}
