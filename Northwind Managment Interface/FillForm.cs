﻿using System;
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
        /* FillObject is the main object in the form, it's 
         * the combination of a textbox and a lable.
         */
        struct FillObject
        {
            /* This routine is to indicate the status of the 
             * current element. it vary between two states:
             *
             *      + SHOW :: The object is displayed on the screen.
             *      + HIDE :: The object is *not* displayed on the screen.
             */
            public enum ObjectStatus { SHOW = 0, HIDE = 1 }

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

        public FillForm()
        {
            InitializeComponent();
        }

        private void FillForm_Load(object sender, EventArgs e)
        {
            FillObjectSetup(fobject, listtextbox, listlabel);

            for (int i = 0; i < 4; ++i) HandleFillObject(fobject, i, FillObject.ObjectStatus.SHOW);


            //MessageBox.Show();
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
                objectsrc[i].Status = FillObject.ObjectStatus.HIDE; // Hidden by default.
            }
        }
        #endregion

        private void HandleFillObject(FillObject[] source, int index, FillObject.ObjectStatus status)
        {
            switch ((source[index].Status = status))
            {
                case FillObject.ObjectStatus.SHOW:
                    source[index].Label.Show();
                    source[index].Textbox.Show();
                    break;
                case FillObject.ObjectStatus.HIDE:
                    source[index].Label.Hide();
                    source[index].Textbox.Hide();
                    break;
                default:
                    break;
            }
        }

    }
}
