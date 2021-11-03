using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace supershop.Items
{
    public partial class DragAndDrop : Form
    {
        public DragAndDrop()
        {
            InitializeComponent();
        }

        private void DragAndDrop_Load(object sender, EventArgs e)
        {
            int PID = 1;
            string sql = " select  (select product_id || ' - ' || product_name || ' - ' || product_name_Arabic from purchase where product_id = TblProductRelated.RalatedProdID ) as 'Related Item name'" +
                         " from TblProductRelated where tenentid=" + Tenent.TenentID + " and MYPRODID = " + PID + " ";

            DataAccess.ExecuteSQL(sql);
            DataTable dt = DataAccess.GetDataTable(sql);

            datagrdReportDetails.DataSource = dt;

            this.dataGridAlwaysShow.Columns.Add("Related Item name", "Related Item name");
        }

        private Rectangle dragBoxFromMouseDown;
        private int rowIndexFromMouseDown;
        private void datagrdReportDetails_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                // If the mouse moves outside the rectangle, start the drag.
                if (dragBoxFromMouseDown != Rectangle.Empty && !dragBoxFromMouseDown.Contains(e.X, e.Y))
                {
                    // Proceed with the drag and drop, passing in the list item.                    
                    DragDropEffects dropEffect = datagrdReportDetails.DoDragDrop(datagrdReportDetails.Rows[rowIndexFromMouseDown], DragDropEffects.Copy);
                }
            }
        }

        private void datagrdReportDetails_MouseDown(object sender, MouseEventArgs e)
        {
            // Get the index of the item the mouse is below.
            rowIndexFromMouseDown = datagrdReportDetails.HitTest(e.X, e.Y).RowIndex;
            if (rowIndexFromMouseDown != -1)
            {
                // Remember the point where the mouse down occurred. 
                // The DragSize indicates the size that the mouse can move 
                // before a drag event should be started.                
                Size dragSize = SystemInformation.DragSize;

                // Create a rectangle using the DragSize, with the mouse position being
                // at the center of the rectangle.
                dragBoxFromMouseDown = new Rectangle(new Point(e.X - (dragSize.Width / 2), e.Y - (dragSize.Height / 2)), dragSize);
            }
            else
                // Reset the rectangle if the mouse is not over an item in the ListBox.
                dragBoxFromMouseDown = Rectangle.Empty;
        }

        private void dataGridAlwaysShow_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void dataGridAlwaysShow_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(DataRowView)))
            {
                // The mouse locations are relative to the screen, so they must be 
                // converted to client coordinates.
                Point clientPoint = dataGridAlwaysShow.PointToClient(new Point(e.X, e.Y));

                // If the drag operation was a copy then add the row to the other control.
                if (e.Effect == DragDropEffects.Copy)
                {
                    DataGridViewRow Row = (DataGridViewRow)e.Data.GetData(typeof(DataGridViewRow));
                    dataGridAlwaysShow.Rows.Add(Row.Cells[0].Value); //, Row.Cells[1].Value, Row.Cells[2].Value
                }

            }
        }
    }
}
