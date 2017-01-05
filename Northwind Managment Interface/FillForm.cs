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

            // type information
            private bool isdatetime, isimage, isprimary, isforeign, isnullable,
                // `isstring` is true whether DATA_TYPE of the corsponding column
                // is: char, nchar, varchar, nvarchar, text or ntext
                isstring,
                // `isdecimal` is true whether DAtA_TYPE of the corsponding column 
                // is: bit, smallint, int, bigint, real or money
                isdecimal;

            // fill object components
            private ObjectStatus status;
            private Label label;
            private TextBox txt;

            #region Propreties
            // type information
            public bool IsString { get { return isstring; } set { isstring = value; } }
            public bool IsDecimal { get { return isdecimal; } set { isdecimal = value; } }
            public bool IsDateTime { get { return isdatetime; } set { isdatetime = value; } }
            public bool IsImage { get { return isimage; } set { isimage = value; } }
            public bool IsNullable { get { return isnullable; } set { isnullable = value; } }
            public bool IsPrimary { get { return isprimary; } set { isprimary = value; } }
            public bool IsForeign { get { return isforeign; } set { isforeign = value; } }

            // fill object components
            public TextBox Textbox { get { return txt; } set { txt = value; } }
            public Label Label { get { return label; } set { label = value; } }
            public ObjectStatus Status { get { return status; } set { status = value; } }
            #endregion
        };

        FillObject[] fobject;
        List<Label> listlabel = new List<Label>();
        List<TextBox> listtextbox = new List<TextBox>();

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
                " WHERE TABLE_NAME = '" + table + "'";
            command.CommandText = query;

            usedobjects = (int)command.ExecuteScalar();
            #endregion

            this.fobject = new FillObject[usedobjects];

            // initilize all the objects
            InitFillObject(this.fobject, this.listtextbox, this.listlabel);

            #region get column proprietes

            query = "SELECT COLUMN_NAME, DATA_TYPE, IS_NULLABLE" +
                " FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '" + table + "'";

            command.CommandText = query;

            GetSchemaInformation((reader = command.ExecuteReader()), this.fobject);

            reader.Close();
            #endregion

            // put them out!
            HandleFillObject(fobject, usedobjects, FillObject.ObjectStatus.SHOWN);

        }

        private void FillForm_Load(object sender, EventArgs e)
        {
            // nothing else matters..
        }

        private void GetSchemaInformation(SqlDataReader reader, FillObject[] objectsrc)
        {
            // think twice before put an innitialization inside a loop!
            int index = 0;
            while (reader.Read())
            {
                string[] stype = new string[] { "char", "nchar", "varchar", "nvarchar", "text",
                   "ntext" }; // string type
                string[] dtype = new string[] {  "bit", "smallint", "int", "float", "real", 
                   "money",}; // decimal type
                //
                string colname = (string)reader["COLUMN_NAME"];
                string coltype = (string)reader["DATA_TYPE"];
                bool isnullable = reader["IS_NULLABLE"].ToString().Equals("YES") ? true : false;
                bool isdecimal, isstring, isdatetime, isimage;
                isdecimal = isstring = isdatetime = isimage = false;


                #region initialize the object proprietes
                objectsrc[index].IsString = objectsrc[index].IsDateTime = false;
                objectsrc[index].IsImage = objectsrc[index].IsDecimal = false;

                objectsrc[index].Label.Text = colname;

                // TODO: use threads instead of the while-loop 
                //

                // this while loop provides a quick type-checking. 
                // this is what i've found to solve the problem of 
                // keep looking for other types while one is true
                while (!(isdecimal || isstring || isdatetime || isimage))
                {
                    // decimal type
                    for (int i = 0; i < dtype.Length; ++i)
                        // if `coltype` equals any of the decimal types (dtype)
                        if (!isdecimal) // (is not a decimal)
                            isdecimal = coltype.Equals(dtype[i]) ? true : false;

                    if (isdecimal) break;

                    // string type
                    for (int i = 0; i < stype.Length; ++i)
                        // if `coltype` equals any of the string types (stype)
                        if (!isstring) // (is not a string)
                            isstring = coltype.Equals(stype[i]) ? true : false;

                    if (isstring) break;

                    // image type
                    if ((isimage = coltype.Equals("image") ? true : false)) break;

                    // datetime type
                    if ((isdatetime = coltype.Equals("datetime") ? true : false)) break;
                }

                objectsrc[index].IsString = isstring;
                objectsrc[index].IsDateTime = isdatetime;
                objectsrc[index].IsImage = isimage;
                objectsrc[index].IsDecimal = isdecimal;

                // set the column of non nullable into red 
                if (!(objectsrc[index].IsNullable = isnullable))
                    objectsrc[index].Label.ForeColor = System.Drawing.Color.Maroon;
                #endregion

                ++index;
            }
        }
        #region Init a `FillObject` array (Using both the list of textboxes and labels)
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
                //item.Text = "foo";
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
        private void InitFillObject(FillObject[] objectsrc, List<TextBox> listtextboxsrc, List<Label> listlabelsrc)
        {
            ListTextBoxSetup(listtextboxsrc);
            ListLabelSetup(listlabelsrc);


            for (int i = 0; i < objectsrc.Length; ++i)
            {
                #region Setup textboxes
                objectsrc[i].Textbox = listtextbox[i];
                objectsrc[i].Textbox.Text = string.Empty;
                #endregion

                #region Setup labels
                objectsrc[i].Label = listlabel[i];
                // TODO: find a way to determine the primary keys
                //       in order to set their color into red;
                // 
                //MessageBox.Show(objectsrc[i].IsNullable ? "yyes":"nno");
                //// is not nullable 
                //if (objectsrc[i].IsNullable) objectsrc[i].Label.ForeColor = System.Drawing.Color.Maroon;

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
                    if (!this.fobject[i].IsNullable &&
                        this.fobject[i].Textbox.Text.CompareTo(string.Empty) == 0)
                         MessageBox.Show("Test"); 
                }
                for (int i = 0; i < usedobjects; i++)
                {
                    string t_str;
                    FillObject temp_object = this.fobject[i];

                    #region if it's the first loop of the for-loop
                    if (i == 0 ? true : false)
                    {
                        // create an insert insertquery to fill all columns exept 
                        // the ID column, which is the first column usually.

                        // string temp;
                        t_str = string.Format("INSERT INTO [{0}]({1}", table, this.fobject[1].Label.Text);

                        // the first item is used above, so we'll start counting from 2
                        for (int j = 2; j < usedobjects; ++j)
                            t_str += string.Format(", {0}", this.fobject[j].Label.Text);
                        // ')' to close column's parentheses 
                        t_str += ")";

                        insertquery = string.Format("{0} VALUES(", t_str);

                        continue; // move to the next element in `fobject`
                    }
                    #endregion
                    // temporary variable to hold the  current object

                    if (temp_object.Textbox.Text.CompareTo(string.Empty) == 0)
                    {
                        // insert NULL whether the user did not fill the textbox with a value
                        t_str = "NULL";
                    }
                    else if (temp_object.IsString)
                    {
                        // put the text value of the textbox between single
                        // quotes in order to add it to the insertquery
                        t_str = "'" + temp_object.Textbox.Text + "'";
                    }
                    else
                    {
                        // decimal values don't need anything to be added.
                        // Cheers!
                        t_str = temp_object.Textbox.Text;
                    }

                    insertquery += string.Format("{0}{1}",i == 1?"":",",t_str);

                }

                // close the value's paretheses
                insertquery += ")";
                MessageBox.Show(insertquery);
                #endregion

                SqlCommand cmd = new SqlCommand(insertquery, connection);

                try { cmd.ExecuteNonQuery(); }
                catch (SqlException e) { MessageBox.Show(e.ToString()); }

            Error:
                return;
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
