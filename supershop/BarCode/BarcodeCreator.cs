using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;

namespace supershop.BarCode
{
    public partial class BarcodeCreator : Form
    {
        public BarcodeCreator()
        {
            InitializeComponent();

            //string str = "503.0ads,d.asd";
            //label2.Text = str.Replace(',', '.');
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                EaN13Barcode1.Value = cmboProductCode.Text;
                //  MessageBox.Show("The Check Sum is : " + EaN13Barcode1.CheckSum.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            if (ColorDialog1.ShowDialog() == DialogResult.OK)
            {
                btnColor.BackColor = ColorDialog1.Color;
                EaN13Barcode1.BackColor = ColorDialog1.Color;
            }
        }

        private void btnforecolor_Click(object sender, EventArgs e)
        {
            if (ColorDialog1.ShowDialog() == DialogResult.OK)
            {
                btnforecolor.ForeColor = ColorDialog1.Color;
                EaN13Barcode1.ForeColor = ColorDialog1.Color;
            }
        }

        private void chbShowText_CheckedChanged(object sender, EventArgs e)
        {
            EaN13Barcode1.ShowBarcodeText = chbShowText.Checked;
        }

        private void chbShowCheckSum_CheckedChanged(object sender, EventArgs e)
        {
            EaN13Barcode1.ShowCheckSum = chbShowCheckSum.Checked;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (PrintDialog1.ShowDialog() == DialogResult.OK)
            {
                PrintDocument1.PrinterSettings = PrintDialog1.PrinterSettings;
                PrintDocument1.DocumentName = cmboProductCode.Text + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss");
                PrintDocument1.Print();
            }
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            PrintPreviewDialog1 = new PrintPreviewDialog();
            PrintPreviewDialog1.Document = PrintDocument1;
            PrintDocument1.DocumentName = cmboProductCode.Text + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss");
            PrintPreviewDialog1.WindowState = FormWindowState.Maximized;
            PrintPreviewDialog1.PrintPreviewControl.Zoom = 0.75;
            PrintPreviewDialog1.ShowDialog();
        }

        int pageNumber = 1;
        int numberOfPages = 1;
        int i = 0;

        private void PrintDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            numberOfPages = int.Parse(nudPages.Value.ToString());
            int x = 10;
            int y = 20;

            for (int j = 0; j <= 3; j++)
            {

                for (int m = 0; m <= 6; m++)
                {
                    Rectangle drawRect = new Rectangle(x, y, EaN13Barcode1.Width, EaN13Barcode1.Height);
                    EaN13Barcode1.PrintToGraphics(e.Graphics, drawRect);
                    //x = x + EaN13Barcode1.Width
                    y = y + EaN13Barcode1.Height;
                }
                x = x + EaN13Barcode1.Width;
                y = 20;
            }


            if ((pageNumber < numberOfPages))
            {
                e.HasMorePages = true;
                i = i + 1;
                pageNumber = pageNumber + 1;
            }
            else
            {
                e.HasMorePages = false;
            }
        }

        private void BarcodeCreator_Load(object sender, EventArgs e)
        {
            try
            {
                //Product Code Databind from Database
                string sql5 = "select   product_id   from purchase where TenentID = " + Tenent.TenentID + "";
                DataAccess.ExecuteSQL(sql5);
                DataTable dt5 = DataAccess.GetDataTable(sql5);
                cmboProductCode.DataSource = dt5;
                cmboProductCode.DisplayMember = "product_id";
            }
            catch
            {
            }
        }

        private void lnkAdvanceBC_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CreateBarcode go = new CreateBarcode();
            go.MdiParent = this.ParentForm;
            go.Show();
        }

    }
}
