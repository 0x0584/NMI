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
    public partial class FillForm : Form
    {
        /* FillObject is the main object in the form.
         * it's the combination of a textbox and a lable.
         */
        struct FillObject
        {
            // TODO: add also comboboxes for foreign key
            // 

            /* This routine is to indicate the status of the current element. it vary between
             * two states, SHOWN (The object is displayed on the screen) and HIDDEN (The object 
             * is *not* displayed on the screen).
             */
            public enum ObjectStatus { SHOWN = 0, HIDDEN = 1 }

            #region indicates the column type
            // `isstring` is true whether DATA_TYPE of the corsponding column
            // is: char, nchar, varchar, nvarchar, text or ntext
            private bool isstring;
            public bool IsString { get { return isstring; } set { isstring = value; } }

            // `isdecimal` is true whether DAtA_TYPE of the corsponding column 
            // is: bit, smallint, int, bigint, real or money
            private bool isdecimal;
            public bool IsDecimal { get { return isdecimal; } set { isdecimal = !IsString; } }

            // or datetime
            private bool isdatetime;
            public bool IsDateTime { get { return isdatetime; } set { isdatetime = value; } }

            // or a picture
            private bool isimage;
            public bool IsImage { get { return isimage; } set { isimage = value; } }
            #endregion

            private TextBox txt;
            public TextBox Textbox { get { return txt; } set { txt = value; } }



            private Label label;
            public Label Label { get { return label; } set { label = value; } }

            private ObjectStatus status;
            public ObjectStatus Status { get { return status; } set { status = value; } }
        };
        FillObject[] fobject;
        //

        List<Label> listlabel = new List<Label>();
        List<TextBox> listtextbox = new List<TextBox>();

        bool[] isprimary, isforiegn;

        bool validated = false;

        int usedobjects;

        public FillForm() { InitializeComponent(); }
        public FillForm(SqlConnection connection, string table)
        {
            InitializeComponent();
            lbltable.Text = table;
         
            // TODO: what is CommandBehavior any way?
            //
            SqlCommand command = new SqlCommand();
            SqlDataReader reader = null;
            string query;

            command.Connection = connection;

            if (connection.State == ConnectionState.Closed) connection.Open();

            #region set `usedobjects` to be # of columns in `table`
            query = "SELECT COUNT(*) FROM INFORMATION_SCHEMA.COLUMNS" + 
                    "WHERE TABLE_NAME = '" + table + "'";
            command.CommandText = query; 

            usedobjects = (int)command.ExecuteScalar();
            #endregion

            fobject = new FillObject[usedobjects];
            isprimary = new bool[usedobjects];
            isforiegn = new bool[usedobjects];

            // initilise all the objects
            InitObjectSetup(fobject, listtextbox, listlabel);

            #region get the name of all columns

            query = "SELECT COLUMN_NAME, DATA_TYPE, IS_NULLABLE " +
                    "FROM INFORMATION_SCHEMA.COLUMNS" +
                    "WHERE TABLE_NAME = '" + table + "'";
            command.CommandText = query;

            try
            {

                reader = command.ExecuteReader(); // here
            }
            catch (SqlException e)
            {

                MessageBox.Show(e.ToString());
            }

            // the reader still empty!! WHAT THE HECK
            while (reader.Read())
            {
                string[] stype = new string[] { "char", "nchar", "varchar", "nvarchar", "text",
                   "ntext" };
                string[] dtype = new string[] {  "bit", "smallint", "int", "float", "real", 
                   "money",};
                //
                string colname = (string)reader["COLUMN_NAME"];
                string coltype = (string)reader["DATA_TYPE"];
                //
                int i, index = 0;

                fobject[index].Label.Text = colname;
                isprimary[index] = reader["IS_NULLABLE"].ToString().Equals("YES") ? true : false;

                // all the objects are considered as decimals by default. 
                for (i = 0; i < dtype.Length; ++i)
                    // if `coltype` equals any of the decimal types (dtype)
                    if (!this.fobject[index].IsDecimal) // (is not a decimal)
                        this.fobject[index].IsDecimal = coltype.Equals(dtype[i]) ? true : false;

                this.fobject[index].IsDateTime = coltype.Equals("datetime") ? true : false;

                for (i = 0; i < stype.Length; ++i)
                    // if `coltype` equals any of the string types (stype)
                    if (!this.fobject[index].IsString) // (is not a string)
                        this.fobject[index].IsString = coltype.Equals(stype[i]) ? true : false;
                index++;
            }

            reader.Close();
            #endregion

            // put them out!
            HandleFillObject(fobject, usedobjects, FillObject.ObjectStatus.SHOWN);

            // TODO: get the number of columns
            // done.

        }

        private void FillForm_Load(object sender, EventArgs e)
        {
            // nothing else matters..
        }

        #region Setup a `FillObject` array (Using both the list of textboxes and labels)
        private void ListLabelSetup(List<Label> source)
        {
            #region Add items to `listlable`
            source.Add(label1);
            source.Add(label2);
            source.Add(label3);
            source.Add(label4);
            source.Add(label5);
            source.Add(label6);
            source.Add(label7);
            source.Add(label8);
            source.Add(label9);
            source.Add(label10);
            source.Add(label11);
            source.Add(label12);
            source.Add(label13);
            source.Add(label14);
            source.Add(label15);
            source.Add(label16);
            source.Add(label17);
            source.Add(label18);
            #endregion

            foreach (var item in source)
            {
                item.Text = string.Empty;
                item.Hide();
            }

        }
        private void ListTextBoxSetup(List<TextBox> source)
        {
            #region Add items to `listtextbox`
            source.Add(textBox1);
            source.Add(textBox2);
            source.Add(textBox3);
            source.Add(textBox4);
            source.Add(textBox5);
            source.Add(textBox6);
            source.Add(textBox7);
            source.Add(textBox8);
            source.Add(textBox9);
            source.Add(textBox10);
            source.Add(textBox11);
            source.Add(textBox12);
            source.Add(textBox13);
            source.Add(textBox14);
            source.Add(textBox15);
            source.Add(textBox16);
            source.Add(textBox17);
            source.Add(textBox18);
            #endregion

            foreach (var item in source)
            {
                item.Text = string.Empty;
                item.Hide();
            }
        }
        private void InitObjectSetup(FillObject[] objectsrc, List<TextBox> listtextboxsrc, List<Label> listlabelsrc)
        {
            ListTextBoxSetup(listtextboxsrc);
            ListLabelSetup(listlabelsrc);


            for (int i = 0; i < objectsrc.Length; ++i)
            {
                //    [X] here!
                //     |
                //     v
                objectsrc[i].IsDecimal = true; // all fields are decimals  
                objectsrc[i].IsString = objectsrc[i].IsDateTime = objectsrc[i].IsImage = false;

                #region Setup textboxes
                objectsrc[i].Textbox = listtextbox[i];
                objectsrc[i].Textbox.Text = string.Empty;
                #endregion

                #region Setup labels
                objectsrc[i].Label = listlabel[i];
                // TODO: find a way to determine the primary keys
                //       in order to set their color into red;
                // done.
                if (isprimary[i]) objectsrc[i].Label.ForeColor = System.Drawing.Color.Maroon;

                #endregion

                objectsrc[i].Status = FillObject.ObjectStatus.HIDDEN; // Hidden by default.
            }
        }
        #endregion

        #region Handle `FillObject` behavior
        private void HandleFillObject(FillObject[] source, int colnumber, FillObject.ObjectStatus status)
        {
            // Anyway, this is a comment. 
            // (just in case you did not know what this thing is)

            for (int i = 0; i < colnumber; i++)
            {
                switch ((source[i].Status = status))
                {
                    case FillObject.ObjectStatus.SHOWN:
                        source[i].Label.Show();
                        source[i].Textbox.Show();
                        break;
                    case FillObject.ObjectStatus.HIDDEN:
                        source[i].Label.Hide();
                        source[i].Textbox.Hide();
                        break;
                    default:
                        break;
                }
            }
        }
        #endregion

        private void btndimiss_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnconfirm_Click(object sender, EventArgs e)
        {
            // Just wait, you'll get better soon!
            // got it! alright then, index'll do my best..
            validated = true;
            this.Hide();
        }

        internal void SendToServer(SqlConnection connection, string table)
        {
            if (validated)
            {
                #region Prepare the insertion insertquery
                // a loop on the each loop, a value while be inserted based on its type.
                // if the specifice value is not inserted, a NULL would be 
                // passed instead. 

                // it's not neccesary to initialise this variable because 
                // inside eh for-loop there's a `continue`. but c sharp 
                // compiler looks a little bit dumb! C is masterpiece..
                string insertquery = string.Empty;

                // TODO: after determining the columns types
                //       do just normal-loop instead of loop and 1/2
                // done.

                for (int i = 0; i < usedobjects; i++)
                {
                    string t_str;

                    #region if it's the first loop of the for-loop
                    if (!Convert.ToBoolean(i))
                    {
                        // create an insert insertquery to fill all columns exept 
                        // the ID column, which is the first column usually.

                        // string temp;
                        t_str = string.Format("INSERT INTO [{0}]({1}", table, fobject[1].Label.Text);

                        // the first item is used above, so we'll start counting from 2
                        for (int j = 2; j < usedobjects; ++j)
                            t_str += string.Format(", {0}", fobject[j].Textbox.Text);
                        // ')' to close column's parentheses 
                        t_str += ")";

                        insertquery = string.Format("{0} VALUES({1}", t_str, table, fobject[1].Textbox.Text);

                        continue; // move to the next element in `fobject`
                    }
                    #endregion
                    // temporary variable to hold the  current object
                    FillObject tobject = fobject[i];

                    if (tobject.Textbox.Text.CompareTo(string.Empty) == 0)
                    {
                        // insert NULL whether the user did not fill the textbox with a value
                        t_str = "NULL";
                        insertquery += "," + t_str; // ", NULL"
                    }
                    else if (tobject.IsString) // <----[HERE]
                    {
                        // put the text value of the textbox between single
                        // quotes in order to add it to the insertquery
                        t_str = ",'" + tobject.Textbox.Text + "'";
                        insertquery += t_str;
                    }
                    else
                    {
                        // decimal values don't need anything to be added.
                        // Cheers!
                        t_str = "," + tobject.Textbox.Text;
                        insertquery += t_str;
                    }
                }

                // close the value's paretheses
                insertquery += ")";
                // MessageBox.Show(insertquery);
                #endregion

                SqlCommand cmd = new SqlCommand(insertquery, connection);

                try { cmd.ExecuteNonQuery(); }
                catch (SqlException e) { MessageBox.Show(e.ToString()); }

            }
        }

        internal void SendToDataSet(DataSet dataset, string table)
        {
            if (validated)
            {
                try
                {
                    DataRow datarow = dataset.Tables[table].NewRow();

                    for (int i = 0; i < usedobjects; ++i)
                        datarow[i] = fobject[i].Textbox.Text;

                    dataset.Tables[table].Rows.Add(datarow);
                }
                catch (SqlException e) { MessageBox.Show(e.ToString()); }

                // void foo(string t_str) { t_str = "foo"; } 
                // string s = "FOO";
                // foo(s);
                // 
                // t_str?
            }
        }
    }
}
