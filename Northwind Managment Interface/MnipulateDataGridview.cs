using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace Northwind
{
    class MnipulateDataGridview
    {
        public DataGridView SetupDataGridView()
        {
            DataGridView foo = new DataGridView();
            DataGridViewImageColumn p = new DataGridViewImageColumn();

            foo.Columns.Add("CategID", "Category ID");
            foo.Columns.Add("CategName", "Category Name");
            foo.Columns.Add("Desc", "Description");
            // mainDataGrid.Columns.Add("Pic", "Picture");

            p.HeaderText = "Picture";
            p.Name = "pic";
            foo.Columns.Add(p);
            foo.Columns.Add("LastEdit", "Last Edit Date");
            foo.Columns.Add("Creation", "Creation Date");

            return foo;
        }

        public void ClearDataGridViewRows(DataGridView foo)
        {
            try { foo.Rows.Clear(); }
            catch { }

        }

        public void ClearDataGridViewColumns(DataGridView foo)
        {
            try { foo.Columns.Clear(); }
            catch { }

        }
    }
}
