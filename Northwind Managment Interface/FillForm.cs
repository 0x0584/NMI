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

            private TextBox txt;
            public TextBox Textbox { get { return txt; } set { txt = value; } }
            
            // this variable is used to to indecate whether the variable
            // is an decimal or a string. this routine is to avoid sql injection.
            private bool isstring;
            public bool Isstring { get { return isstring; } set { isstring = value; } }

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

            if (connection.State == ConnectionState.Closed) connection.Open();

            #region set `usedobjects` to be # of columns in `table`
            string query = "SELECT COUNT(*) FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '" + table + "'";
            SqlCommand cmd = new SqlCommand(query, connection);
            usedobjects = (int)cmd.ExecuteScalar();
            #endregion

            fobject = new FillObject[usedobjects];
            isprimary = new bool[usedobjects];
            isforiegn = new bool[usedobjects];

            InitObjectSetup(fobject, listtextbox, listlabel);

            #region get the name of all columns
            int i = 0;
            query = "SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '" + table + "'";
            cmd.CommandText = query;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read()) fobject[i++].Label.Text = (string)reader[0];
            reader.Close();
            #endregion

            // put them out!
            HandleFillObject(fobject, usedobjects, FillObject.ObjectStatus.SHOWN);

            // TODO: get the number of columns
            // done.

        }

        private void FillForm_Load(object sender, EventArgs e)
        {

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
                #region Setup textboxes
                objectsrc[i].Textbox = listtextbox[i];
                objectsrc[i].Textbox.Text = string.Empty;
                objectsrc[i].Isstring = true; // consider all textboxes as strings by default.
                #endregion

                #region Setup labels
                objectsrc[i].Label = listlabel[i];
                // TODO: find a way to determine the primary keys
                //       in order to set their color into red;
                // if(isprimary[i]) objectsrc[i].Label.ForeColor = System.Drawing.Color.Maroon;
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
            
            validated = true;
            this.Hide();
        }

        internal void SendToServer(SqlConnection connection, string table)
        {
            if (validated)
            {
                #region Prepare the insertion query
                // TODO: after determining the columns types
                //       do just normal-loop instead of loop and 1/2
                // 

                string query = "INSERT INTO [" + table + " ] VALUES(" + fobject[0].Textbox.Text;

                // the 0th item is used above, so we'll start counting from 1
                for (int i = 1; i < usedobjects; i++)
                {
                    string str;
                    FillObject temp = fobject[i];

                    // TODO: Determine the whether the values are correct or not
                    //

                    if (temp.Textbox.Text.CompareTo(string.Empty) == 0)
                    {
                        // insert NULL whether the user did not fill the textbox with a value
                        str = "NULL";
                        query += "," + str; // ", NULL"
                    }
                    else if (temp.Isstring) // <----[HERE]
                    {
                        // put the text value of the textbox between `'<something>'` (single quotes) 
                        // in order to add it to the query
                        str = ",'" + temp.Textbox.Text + "'";
                        query += str;
                    }
                    else
                    {
                        // decimal values don't need anything to be added.
                        // Cheers :)
                        str = "," + temp.Textbox.Text;
                        query += str;
                    }
                }

                query += ")";
                #endregion

                SqlCommand cmd = new SqlCommand(query, connection);

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

                // void foo(string str) { str = "foo"; } 
                // string s = "FOO";
                // foo(s);
                // 
                // str?
            }
        }
    }
}
