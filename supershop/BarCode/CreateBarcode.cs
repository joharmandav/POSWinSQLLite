using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Printing;

namespace supershop
{
    public partial class CreateBarcode : Form
    {

        private Ean13 ean13 = null;
        private UpcA upc = null;


        public CreateBarcode()
        {
            InitializeComponent();
            cboScale.SelectedIndex = 2;
            // cboProductType.SelectedIndex = 0;

        }

        private void CreateBarcode_Load(object sender, EventArgs e)
        {
            //Product Code Databind from Database
            string sql5 = "select   product_id   from purchase where TenentID = " + Tenent.TenentID + "";
            DataAccess.ExecuteSQL(sql5);
            DataTable dt5 = DataAccess.GetDataTable(sql5);
            cmboProductCode.DataSource = dt5;
            cmboProductCode.DisplayMember = "product_id";
        }


        private void CreateEan13()
        {
            ean13 = new Ean13();
            ean13.CountryCode = txtCountryCode.Text;
            ean13.ManufacturerCode = txtManufacturerCode.Text;
            ean13.ProductCode = txtProductCode.Text;
            if (txtChecksumDigit.Text.Length > 0)
                ean13.ChecksumDigit = txtChecksumDigit.Text;
        }

        private void CreateUPC()
        {
            upc = new UpcA();
            upc.ProductType = cboProductType.Items[cboProductType.SelectedIndex].ToString();
            upc.ManufacturerCode = txtManufacturerCode.Text;
            upc.ProductCode = txtProductCode.Text;
            if (txtChecksumDigit.Text.Length > 0)
                upc.ChecksumDigit = txtChecksumDigit.Text;
        }

        private void butDraw_Click(object sender, EventArgs e)
        {
            try
            {
                if (rdbtnEAN13.Checked)
                {
                    if (txtCountryCode.Text == string.Empty)
                    {
                        MessageBox.Show("Please insert Country Code Min: 1 digit Max 2 digit");
                        txtCountryCode.Focus();
                    }
                    else if (txtManufacturerCode.Text == string.Empty)
                    {
                        MessageBox.Show("Please insert Manufacturer Code : 5 digit");
                        txtManufacturerCode.Focus();
                    }
                    else if (txtProductCode.Text == string.Empty)
                    {
                        MessageBox.Show("Please insert Product Code : 5 digit");
                        txtProductCode.Focus();
                    }
                    else
                    {
                        System.Drawing.Graphics g = this.picBarcode.CreateGraphics();

                        g.FillRectangle(new System.Drawing.SolidBrush(System.Drawing.SystemColors.Control),
                            new Rectangle(0, 0, picBarcode.Width, picBarcode.Height));

                        System.Drawing.Graphics g2 = this.picBarcode.CreateGraphics();

                        g2.FillRectangle(new System.Drawing.SolidBrush(System.Drawing.SystemColors.Control),
                            new Rectangle(0, 0, picBarcode.Width, picBarcode.Height));

                        CreateEan13();
                        ean13.Scale = (float)Convert.ToDecimal(cboScale.Items[cboScale.SelectedIndex]);
                        ean13.DrawEan13Barcode(g, new System.Drawing.Point(0, 0));
                        txtChecksumDigit.Text = ean13.ChecksumDigit;
                        g.Dispose();

                        // lblPrice.Font = new Font("Tahoma", 22); 
                    }

                }
                else if (rdbtnUPCA.Checked)
                {
                    if (txtManufacturerCode.Text == string.Empty)
                    {
                        MessageBox.Show("Please insert Manufacturer Code : 5 digit");
                        txtManufacturerCode.Focus();
                    }
                    else if (txtProductCode.Text == string.Empty)
                    {
                        MessageBox.Show("Please insert Product Code : 5 digit");
                        txtProductCode.Focus();
                    }
                    else if (cboProductType.Text == string.Empty)
                    {
                        MessageBox.Show("Please select Product Type");
                        cboProductType.Focus();
                    }
                    else
                    {
                        System.Drawing.Graphics g = this.picBarcode.CreateGraphics();

                        g.FillRectangle(new System.Drawing.SolidBrush(System.Drawing.SystemColors.Control),
                                        new Rectangle(0, 0, picBarcode.Width, picBarcode.Height));

                        CreateUPC();
                        upc.Scale = (float)Convert.ToDecimal(cboScale.Items[cboScale.SelectedIndex]);
                        upc.DrawUpcaBarcode(g, new System.Drawing.Point(0, 0));
                        txtChecksumDigit.Text = upc.ChecksumDigit;
                        g.Dispose();
                    }

                }
            }
            catch
            {
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            // e.Graphics.DrawImage(picBarcode.Image, 100, 100, 700, 600);
            e.Graphics.DrawImage(picBarcode.Image, 80, 80);
            // e.Graphics.DrawString("Hello World", new Font("Arial", 10), new SolidBrush(Color.Black), new PointF(10, 10)); 


        }

        private void butPrint_Click(object sender, EventArgs e)
        {
            try
            {


                //System.Drawing.Printing.PrintDocument pd = new System.Drawing.Printing.PrintDocument();
                //pd.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.pd_PrintPage);
                //PrintDialog dlg = new PrintDialog();
                //dlg.Document = pd;
                //if (dlg.ShowDialog() == DialogResult.OK)
                //{
                //   // dlg.ShowDialog();
                //    pd.Print();
                //}
                //else
                //{
                //    MessageBox.Show("Print Cancelled");
                //}

                PrintDocument pd = new PrintDocument();
                pd.PrintPage += new PrintPageEventHandler(this.pd_PrintPage);

                PrintDialog printdlg = new PrintDialog();
                PrintPreviewDialog printPrvDlg = new PrintPreviewDialog();

                // preview the assigned document or you can create a different previewButton for it
                printPrvDlg.Document = pd;
                printPrvDlg.ShowDialog(); // this shows the preview and then show the Printer Dlg below

                printdlg.Document = pd;
                pd.DocumentName = cmboProductCode.Text + "_" + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss");
                if (printdlg.ShowDialog() == DialogResult.OK)
                {
                    pd.Print();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void pd_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs ev)
        {
            if (rdbtnEAN13.Checked)
            {
                CreateEan13();
                ean13.Scale = (float)Convert.ToDecimal(cboScale.Items[cboScale.SelectedIndex]);
                ean13.DrawEan13Barcode(ev.Graphics, new System.Drawing.Point(0, 0));
                txtChecksumDigit.Text = ean13.ChecksumDigit;

                // Add Code here to print other information.
                ev.Graphics.Dispose();
            }
            else if (rdbtnUPCA.Checked)
            {
                CreateUPC();
                upc.Scale = (float)Convert.ToDecimal(cboScale.Items[cboScale.SelectedIndex]);
                upc.DrawUpcaBarcode(ev.Graphics, new System.Drawing.Point(0, 0));
                txtChecksumDigit.Text = upc.ChecksumDigit;
                ev.Graphics.Dispose();
            }

        }

        //Print Preview
        private void butCreateBitmap_Click(object sender, EventArgs e)
        {
            try
            {
                if (rdbtnEAN13.Checked)
                {
                    CreateEan13();
                    ean13.Scale = (float)Convert.ToDecimal(cboScale.Items[cboScale.SelectedIndex]);

                    System.Drawing.Bitmap bmp = ean13.CreateBitmap();
                    this.picBarcode.Image = bmp;
                    //  this.picBarcode.Image = bmp;


                    PrintDocument document = new PrintDocument();
                    document.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);

                    PrintPreviewDialog ppDialog = new PrintPreviewDialog();
                    //  ppDialog.ClientSize = new System.Drawing.Size(990, 630);
                    ppDialog.WindowState = FormWindowState.Maximized;
                    ppDialog.PrintPreviewControl.Zoom = 1.0;
                    ppDialog.Document = printDocument1;
                    ppDialog.ShowDialog();
                }
                else if (rdbtnUPCA.Checked)
                {
                    CreateUPC();
                    upc.Scale = (float)Convert.ToDecimal(cboScale.Items[cboScale.SelectedIndex]);

                    System.Drawing.Bitmap bmp = upc.CreateBitmap();
                    this.picBarcode.Image = bmp;

                    PrintDocument document = new PrintDocument();
                    document.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);

                    PrintPreviewDialog ppDialog = new PrintPreviewDialog();
                    // ppDialog.ClientSize = new System.Drawing.Size(980, 630);
                    ppDialog.WindowState = FormWindowState.Maximized;
                    ppDialog.PrintPreviewControl.Zoom = 1.0;
                    ppDialog.Document = printDocument1;
                    ppDialog.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }



        private void rdbtnUPCA_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                cboProductType.Visible = true;
                label6.Visible = true;

                cboProductType.Text = cmboProductCode.Text.Substring(0, 1);
                txtCountryCode.Text = ""; // cmboProductCode.Text.Substring(0, 2);
                txtManufacturerCode.Text = cmboProductCode.Text.Substring(1, 5);
                txtProductCode.Text = cmboProductCode.Text.Substring(6, 5);
            }
            catch
            {
            }

        }

        private void rdbtnEAN13_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                cboProductType.Visible = false;
                label6.Visible = false;

                txtCountryCode.Text = cmboProductCode.Text.Substring(0, 2);
                txtManufacturerCode.Text = cmboProductCode.Text.Substring(2, 5);
                txtProductCode.Text = cmboProductCode.Text.Substring(7, 5);
            }
            catch
            {
            }

        }

        private void cmboProductCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdbtnEAN13.Checked)
                {
                    string sql5 = "select  product_name , price  FROM  purchase INNER JOIN tbl_item_uom_price ON purchase.product_id = tbl_item_uom_price.itemID and purchase.TenentID = tbl_item_uom_price.TenentID " +
                                  " where purchase.TenentID = " + Tenent.TenentID + " and  product_id = '" + cmboProductCode.Text + "' ";
                    DataAccess.ExecuteSQL(sql5);
                    DataTable dt5 = DataAccess.GetDataTable(sql5);
                    lblProductName.Text = dt5.Rows[0].ItemArray[0].ToString();
                    lblPrice.Text = "| " + dt5.Rows[0].ItemArray[1].ToString();

                    txtCountryCode.Text = cmboProductCode.Text.Substring(0, 2);
                    txtManufacturerCode.Text = cmboProductCode.Text.Substring(2, 5);
                    txtProductCode.Text = cmboProductCode.Text.Substring(7, 5);
                }
                else if (rdbtnUPCA.Checked)
                {
                    string sql5 = "select  product_name , price  FROM  purchase INNER JOIN tbl_item_uom_price ON purchase.product_id = tbl_item_uom_price.itemID and purchase.TenentID = tbl_item_uom_price.TenentID " +
                                  " where purchase.TenentID = " + Tenent.TenentID + " and product_id = '" + cmboProductCode.Text + "' ";
                    DataAccess.ExecuteSQL(sql5);
                    DataTable dt5 = DataAccess.GetDataTable(sql5);
                    lblProductName.Text = dt5.Rows[0].ItemArray[0].ToString();
                    lblPrice.Text = "| " + dt5.Rows[0].ItemArray[1].ToString();

                    cboProductType.Text = cmboProductCode.Text.Substring(0, 1);
                    txtCountryCode.Text = ""; // cmboProductCode.Text.Substring(0, 2);
                    txtManufacturerCode.Text = cmboProductCode.Text.Substring(1, 5);
                    txtProductCode.Text = cmboProductCode.Text.Substring(6, 5);
                }



            }
            catch
            {
            }
        }

        private void linkHelp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Help.HelpPageBarcode go = new Help.HelpPageBarcode();
            go.MdiParent = this.ParentForm;
            go.Show();
        }


        // Print Product Label with price
        private void printDocLabelprint_PrintPage(object sender, PrintPageEventArgs e)
        {
            Bitmap myBitmap2 = new Bitmap(splitContainer1.Panel2.Width, splitContainer1.Panel2.Height);
            splitContainer1.Panel2.DrawToBitmap(myBitmap2, new Rectangle(41, 11, splitContainer1.Panel2.Width, splitContainer1.Panel2.Height));
            e.Graphics.DrawImage(myBitmap2, 0, 0);
        }

        // Print Product Label with price
        private void btnlabelPrint_Click(object sender, EventArgs e)
        {

            try
            {
                if (rdbtnEAN13.Checked)
                {
                    CreateEan13();
                    ean13.Scale = (float)Convert.ToDecimal(cboScale.Items[cboScale.SelectedIndex]);

                    System.Drawing.Bitmap bmp = ean13.CreateBitmap();
                    this.picBarcode.Image = bmp;

                    PrintDocument document = new PrintDocument();
                    document.PrintPage += new PrintPageEventHandler(printDocLabelprint_PrintPage);

                    PrintPreviewDialog ppDialog = new PrintPreviewDialog();
                    ppDialog.Document = printDocLabelprint;
                    ppDialog.ShowDialog();
                }
                else if (rdbtnUPCA.Checked)
                {
                    CreateUPC();
                    upc.Scale = (float)Convert.ToDecimal(cboScale.Items[cboScale.SelectedIndex]);

                    System.Drawing.Bitmap bmp = upc.CreateBitmap();
                    this.picBarcode.Image = bmp;

                    PrintDocument document = new PrintDocument();
                    document.PrintPage += new PrintPageEventHandler(printDocLabelprint_PrintPage);

                    PrintPreviewDialog ppDialog = new PrintPreviewDialog();
                    ppDialog.Document = printDocLabelprint;
                    ppDialog.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }







    }
}
