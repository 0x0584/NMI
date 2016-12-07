using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Northwind
{
    public partial class FillForm : Form
    {
        List<Label> listlabel = new List<Label>();
        List<TextBox> listtextbox = new List<TextBox>();

        struct FillObject
        {
            public enum ObjectStatus { SHOW = 0, HIDE = 1 }
            //

            public TextBox txt;
            public Label lab;
            public ObjectStatus status;

        }

        FillObject []fobject = new FillObject[18];
        public FillForm()
        {
            InitializeComponent();
        }

        private void FillForm_Load(object sender, EventArgs e)
        {
            ListLableSetup(listlabel);
            ListTextBoxSetup(listtextbox);
            FillObjectSetup(fobject);

            for(int i = 0; i < 4; ++i ) HandleFillObject(fobject, i, FillObject.ObjectStatus.SHOW);

            //MessageBox.Show();
        }

        private void ListLableSetup(List<Label> source)
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

        private void FillObjectSetup(FillObject []source)
        {
            for (int i = 0; i < source.Length; ++i)
            {
                source[i].txt = listtextbox[i];
                source[i].lab = listlabel[i];
                source[i].status = FillObject.ObjectStatus.HIDE;
            }
        }

        private void HandleFillObject(FillObject []source, int index, FillObject.ObjectStatus status)
        {
            source[index].status = status;
        }

    }
}
