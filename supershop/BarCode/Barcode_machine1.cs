using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

using Spire.Barcode.Forms;
using Spire.Barcode;
using System.Drawing.Printing;

namespace supershop.BarCode
{
    public partial class Barcode_machine1 : Form
    {
        public Barcode_machine1()
        {
            Spire.Barcode.BarcodeSettings.ApplyKey("MOKMO-DD227-E7AER-O8MLC-3A7KP");
            InitializeComponent();
        }

        private void comboBoxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //this.barCodeControl1.TopText = "\n" + txtcompany.Text + "\n ================= \n" + txttoptext.Text + "\n\nPrice: " + txtCurrency.Text + txtPrice.Text;
                //this.barCodeControl1.SupSpace = 22;

                this.barCodeControl1.TopText = "\n" + txttoptext.Text + "\n\nPrice: " + txtCurrency.Text + txtPrice.Text;
                this.barCodeControl1.SupSpace = 22;

                string barcodeType = (sender as ComboBox).SelectedItem.ToString();
                this.barCodeControl1.Type = (BarCodeType)Enum.Parse(typeof(BarCodeType), barcodeType);
            }
            catch
            {

            }
        }

        private void comboBoxText_SelectedIndexChanged(object sender, EventArgs e)
        {
            string borderType = (sender as ComboBox).SelectedItem.ToString();
            this.barCodeControl1.BorderDashStyle = (DashStyle)Enum.Parse(typeof(DashStyle), borderType);
        }

        private void comboBoxFont_SelectedIndexChanged(object sender, EventArgs e)
        {
            string fontName = (sender as ComboBox).SelectedItem.ToString();
            this.barCodeControl1.Font = new Font(fontName, 8f);           
        }
        private void comboBoxColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            string color = (sender as ComboBox).SelectedItem.ToString();
            this.barCodeControl1.ForeColor = Color.FromName(color);
        }

        private void textBoxText_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if ((sender as TextBox).Text != null)
                {
                    //this.barCodeControl1.TopText = "\n" + txtcompany.Text + "\n ================= \n" + txttoptext.Text + "\n\nPrice: " + txtCurrency.Text + txtPrice.Text;
                    //this.barCodeControl1.SupSpace = 22;

                    this.barCodeControl1.TopText = "\n" + txttoptext.Text + "\n\nPrice: " + txtCurrency.Text + txtPrice.Text;
                    this.barCodeControl1.SupSpace = 22;

                    this.barCodeControl1.Data = (sender as TextBox).Text;
                    this.barCodeControl1.Data2D = (sender as TextBox).Text;
                }
            }
            catch
            {

            }
        }

        private void cmbitems_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string sql5 = "select product_id , product_name , price  FROM  purchase INNER JOIN tbl_item_uom_price ON purchase.product_id = tbl_item_uom_price.itemID and purchase.TenentID = tbl_item_uom_price.TenentID where purchase.TenentID = " + Tenent.TenentID + " and product_id = '" + cmbitems.SelectedValue + "' ";
               
                DataTable dt5 = DataAccess.GetDataTable(sql5);
                textBoxText.Text = dt5.Rows[0].ItemArray[0].ToString();
                txttoptext.Text = dt5.Rows[0].ItemArray[1].ToString() + "\nIngredients:";
                txtPrice.Text =  dt5.Rows[0].ItemArray[2].ToString();

                //this.barCodeControl1.TopText = "\n" + txtcompany.Text + "\n ================= \n" + txttoptext.Text +  "\n\nPrice: " + txtCurrency.Text + txtPrice.Text;
                //this.barCodeControl1.SupSpace = 22;

                this.barCodeControl1.TopText = "\n" + txttoptext.Text + "\n\nPrice: " + txtCurrency.Text + txtPrice.Text;
                this.barCodeControl1.SupSpace = 22;

                this.barCodeControl1.Data = (sender as TextBox).Text;
                this.barCodeControl1.Data2D = (sender as TextBox).Text;
                

            }
            catch
            {

            }

        }

        private void textBoxHeight_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string height = (sender as TextBox).Text;
                short validHeight = 15;
                if (Int16.TryParse(height, out validHeight))
                {
                    validHeight = Int16.Parse(height);
                }
                this.barCodeControl1.BarHeight = validHeight;
            }
            catch
            {

            }
        }

        private void textBoxSize_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string fontSize = (sender as TextBox).Text;
                short validSize = 15;

                string fontName = "SimSun";
                if (Int16.TryParse(fontSize, out validSize))
                {
                    validSize = Int16.Parse(fontSize);
                }
                if (this.comboBoxFont.SelectedItem != null)
                {
                    fontName = this.comboBoxFont.SelectedItem.ToString();
                }
                this.barCodeControl1.Font = new Font(fontName, validSize);
            }
            catch
            {
            }

        }

        private void checkBoxText_CheckedChanged(object sender, EventArgs e)
        {
            // this.barCodeControl1.ShowText = (sender as CheckBox).Checked;

            if (checkBoxText.Checked == true)
            {
                this.barCodeControl1.ShowTopText = true;
            }
            else
            {
                this.barCodeControl1.ShowTopText = false;
            }
        }

        private void checkBoxBorder_CheckedChanged(object sender, EventArgs e)
        {
            this.barCodeControl1.HasBorder = (sender as CheckBox).Checked;
        }

        private void checkBoxSum_CheckedChanged(object sender, EventArgs e)
        {
            this.barCodeControl1.ShowCheckSumChar = (sender as CheckBox).Checked;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Print(this.panelPrint);
        }

        Bitmap MemoryImage;
        public void GetPrintArea(Panel panel1)
        {
            MemoryImage = new Bitmap(panel1.Width, panel1.Height);
            panel1.DrawToBitmap(MemoryImage, new Rectangle(0, 0, panel1.Width, panel1.Height));
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            if (MemoryImage != null)
            {
                e.Graphics.DrawImage(MemoryImage, 0, 0);
                base.OnPaint(e);
            }
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            Rectangle pagearea = e.PageBounds;
            e.Graphics.DrawImage(MemoryImage, (pagearea.Width / 2) - (this.panelPrint.Width / 2), this.panelPrint.Location.Y);
        }

        public void Print(Panel panel1)
        {
            //  pannel = panel1;
            GetPrintArea(panel1);

            PaperSize paperSize = new PaperSize("My Envelope", 680, 1350);
            paperSize.RawKind = (int)PaperKind.Custom;



            printDocument1.DefaultPageSettings.PaperSize = paperSize;
            // printDocument1.DefaultPageSettings.Landscape = true;
            printDocument1.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);

            PrintPreviewDialog MyPrintPreviewDialog = new PrintPreviewDialog();
            printDocument1.DocumentName = "Bacode_" + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss");
            MyPrintPreviewDialog.WindowState = FormWindowState.Maximized;
            MyPrintPreviewDialog.PrintPreviewControl.Zoom = 1.0;
            MyPrintPreviewDialog.Document = printDocument1;
            MyPrintPreviewDialog.ShowDialog();
        }

        private void btnCreatebarcode_Click(object sender, EventArgs e)
        {
            //this.barCodeControl1.TopText = "\n" + txtcompany.Text + "\n ================= \n" + txttoptext.Text + "\n\nPrice: " + txtCurrency.Text + txtPrice.Text;
            //this.barCodeControl1.SupSpace = 22;

            this.barCodeControl1.TopText = "\n" + txttoptext.Text + "\n\nPrice: " + txtCurrency.Text + txtPrice.Text;
            this.barCodeControl1.SupSpace = 22;



            //generate the barcode use the settings
            BarCodeGenerator generator = new BarCodeGenerator(barCodeControl1);
            Image barcode = generator.GenerateImage();

            this.barCodeControl1.SaveToFile("barcodeImage.png");
            btnSaveimage.Enabled = true;

            string barcodeimagestore = Application.StartupPath + @"\barcodeImage.png";
            //save the barcode as an image
           // barcode.Save(@"..\..\..\BarCode\barcode.png");
         //   barcode.Save(barcodeimagestore);
            //launch the generated barcode image            
         //   string path = "..\\..\\..\\BarCode\\barcode.png";

            picbarcode1.ImageLocation = barcodeimagestore;
            picbarcode2.ImageLocation = barcodeimagestore;
            picbarcode3.ImageLocation = barcodeimagestore;
            picbarcode4.ImageLocation = barcodeimagestore;
            picbarcode5.ImageLocation = barcodeimagestore;
            picbarcode6.ImageLocation = barcodeimagestore;
            picbarcode7.ImageLocation = barcodeimagestore;
            picbarcode8.ImageLocation = barcodeimagestore;
        }

        private void btnSaveimage_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("barcodeImage.png");            
        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            string[] barcodes = Spire.Barcode.BarcodeScanner.Scan(this.barCodeControl1.GenerateImage());
            if (barcodes.Length > 0)
                this.textBox1.Text = barcodes[0];
        }

        private void Barcode_machine_Load(object sender, EventArgs e)
        {
            try
            {
                string sql5 = "select product_id,(product_id || '-' || Product_name) as Product  from purchase Where TenentID = " + Tenent.TenentID + "  ";
                DataAccess.ExecuteSQL(sql5);
                DataTable dt5 = DataAccess.GetDataTable(sql5);
                cmbitems.DataSource = dt5;
                cmbitems.DisplayMember = "Product";
                cmbitems.ValueMember = "product_id";

                txtcompany.Text = DataAccess.GetCompany() != null ? DataAccess.GetCompany() : "";
            }
            catch
            {
            }
        }

      

  
    }
}
