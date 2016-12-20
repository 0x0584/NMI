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
            /* This routine is to indicate the status of the current element. it vary between
             * two states, SHOWN (The object is displayed on the screen) and HIDDEN (The object 
             * is *not* displayed on the screen).
             */
            public enum ObjectStatus { SHOWN = 0, HIDDEN = 1 }

            private TextBox txt;
            public TextBox Textbox { get { return txt; } set { txt = value; } }

            private Label label;
            public Label Label { get { return label; } set { label = value; } }

            private ObjectStatus status;
            public ObjectStatus Status { get { return status; } set { status = value; } }
        };
        FillObject[] fobject = new FillObject[18];
        //

        List<Label> listlabel = new List<Label>();
        List<TextBox> listtextbox = new List<TextBox>();

       

        public FillForm() { InitializeComponent(); }

        private void FillForm_Load(object sender, EventArgs e)
        {
           
            // TODO: get the number of columns
            // $ 
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
        private void FillObjectSetup(FillObject[] objectsrc, List<TextBox> listtextboxsrc, List<Label> listlabelsrc)
        {
            ListTextBoxSetup(listtextboxsrc);
            ListLabelSetup(listlabelsrc);


            for (int i = 0; i < objectsrc.Length; ++i)
            {
                objectsrc[i].Textbox = listtextbox[i];
                objectsrc[i].Label = listlabel[i];
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

        public void GetTableInformation(SqlConnection input, string table)
        {
            lbltable.Text = table;

            FillObjectSetup(fobject, listtextbox, listlabel);

            if (input.State == ConnectionState.Closed) input.Open();

            //
            string query = "SELECT COUNT(*) FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '" + table + "'";
            SqlCommand cmd = new SqlCommand(query, input);
            int colnumber = (int) cmd.ExecuteScalar();
            //

            //
            query = "SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '" + table + "'";
            cmd.CommandText = query;
            SqlDataReader reader = cmd.ExecuteReader();
            //

            int i = 0;
            while (reader.Read()) fobject[i++].Label.Text = (string) reader[0];

            // put them out!
            HandleFillObject(fobject, colnumber, FillObject.ObjectStatus.SHOWN);
        }

        private void btndimiss_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnconfirm_Click(object sender, EventArgs e)
        {

        }

    }
}
