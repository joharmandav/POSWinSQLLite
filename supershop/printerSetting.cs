using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace supershop
{
    public partial class printerSetting : Form
    {
        public printerSetting()
        {
            InitializeComponent();
            lblmsgCash.Text = "";
            lblMsgCredit.Text = "";
            lblmsgKitchen.Text = "";
        }

        private void printerSetting_Load(object sender, EventArgs e)
        {

           // this.KitchenNoteSetting.Parent = null;
            bind_Printer();
            Bind_File();
            bindExist();
        }

        public void bind_Printer()
        {

            // Cash seiing

            comboPrinterCash.Items.Clear();

            string firstCash = "";
            foreach (string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                if (firstCash == "")
                {
                    firstCash = printer;
                }
                comboPrinterCash.Items.Add(printer);
            }
            comboPrinterCash.Text = firstCash;


            // credit seiing

            ComboPrinterCredit.Items.Clear();

            string firstCredit = "";
            foreach (string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                if (firstCredit == "")
                {
                    firstCredit = printer;
                }
                ComboPrinterCredit.Items.Add(printer);
            }
            ComboPrinterCredit.Text = firstCredit;


            // Kitchen seiing

            ComboPrinterKitchen.Items.Clear();

            string firstkitchen = "";
            foreach (string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                if (firstkitchen == "")
                {
                    firstkitchen = printer;
                }
                ComboPrinterKitchen.Items.Add(printer);
            }
            ComboPrinterKitchen.Text = firstkitchen;

        }

        public void Bind_File()
        {
            // for Cash Recipe File
            combofileCash.Items.Clear();

            string sql = "select * from tblinvoice_PrintFile where file_type = 'Sale'";
            DataTable dt = DataAccess.GetDataTable(sql);
            if (dt.Rows.Count > 0)
            {
                combofileCash.DataSource = dt;
                combofileCash.DisplayMember = "FileDisplayName";
                combofileCash.ValueMember = "ID";
            }

            // for Creadit Recipt File

            ComboFileCredit.Items.Clear();

            string sql1 = "select * from tblinvoice_PrintFile where file_type = 'Sale'";
            DataTable dt1 = DataAccess.GetDataTable(sql1);
            if (dt1.Rows.Count > 0)
            {
                ComboFileCredit.DataSource = dt1;
                ComboFileCredit.DisplayMember = "FileDisplayName";
                ComboFileCredit.ValueMember = "ID";
            }

            // comboFileKitchen

            comboFileKitchen.Items.Clear();

            string sql2 = "select * from tblinvoice_PrintFile where file_type = 'Sale'";
            DataTable dt2 = DataAccess.GetDataTable(sql1);
            if (dt2.Rows.Count > 0)
            {
                comboFileKitchen.DataSource = dt2;
                comboFileKitchen.DisplayMember = "FileDisplayName";
                comboFileKitchen.ValueMember = "ID";
            }

        }

        public void bindExist()
        {
            string sql = "select * from tblPrintSetup where TenentID= " + Tenent.TenentID + " and Shopid = '" + UserInfo.Shopid + "' ";
            DataTable dt = DataAccess.GetDataTable(sql);
            if (dt.Rows.Count > 0)
            {
                comboPrinterCash.Text = dt.Rows[0]["CashReciptPRinter"].ToString();
                ComboPrinterCredit.Text = dt.Rows[0]["CreditInvoicePrinter"].ToString();
                ComboPrinterKitchen.Text = dt.Rows[0]["KitchenNotePrinter"].ToString();

                string CashfileID = dt.Rows[0]["CashReceiptFile"].ToString();
                string CreditfileID = dt.Rows[0]["CreditInvoiceFile"].ToString();
                string KitchenfileID = dt.Rows[0]["KitchenNoteFile"].ToString();
                
                combofileCash.Text = SalesRegister.getFileType(CashfileID);
                ComboFileCredit.Text = SalesRegister.getFileType(CreditfileID);
                comboFileKitchen.Text = SalesRegister.getFileType(KitchenfileID); 
            }
        }

        private void btnCashReciptSave_Click(object sender, EventArgs e)
        {

            string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
            string sql = "update tblPrintSetup set CashReciptPRinter = '" + comboPrinterCash.Text + "' , CashReceiptFile = '" + combofileCash.SelectedValue + "' , " +
                         " Uploadby= '" + UserInfo.UserName + "' ,UploadDate = '" + UploadDate + "' ,SynID = 2 " +
                         " where TenentID= " + Tenent.TenentID + " and Shopid = '" + UserInfo.Shopid + "' ";
            int flag = DataAccess.ExecuteSQL(sql);

            if (flag == 1)
            {
                string sqlwin = "update tblPrintSetup set CashReciptPRinter = '" + comboPrinterCash.Text + "' , CashReceiptFile = '" + combofileCash.SelectedValue + "' , " +
                                " Uploadby= '" + UserInfo.UserName + "' ,UploadDate = '" + UploadDate + "' ,SynID = 2 " +
                                " where TenentID= " + Tenent.TenentID + " and Shopid = '" + UserInfo.Shopid + "' ";
                Datasyncpso.insert_Live_sync(sqlwin, "tblPrintSetup", "UPDATE");

                string ActivityName = "Printer Setup";
                string LogData = "Printer Setup cash recipt Change  with Shopid = " + UserInfo.Shopid + " ";
                Login.InsertUserLog(ActivityName, LogData);

                lblmsgCash.Visible = true;
                lblmsgCash.Text = "Update Successfully";
            }
        }

        private void btnCreditReciptSave_Click(object sender, EventArgs e)
        {
            string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
            string sql = "update tblPrintSetup set CreditInvoicePrinter = '" + ComboPrinterCredit.Text + "' , CreditInvoiceFile = '" + ComboFileCredit.SelectedValue + "' , " +
            " Uploadby= '" + UserInfo.UserName + "' ,UploadDate = '" + UploadDate + "' ,SynID = 2 " +
            " where TenentID= " + Tenent.TenentID + " and Shopid = '" + UserInfo.Shopid + "' ";
             int flag = DataAccess.ExecuteSQL(sql);

             if (flag == 1)
             {

                 string sqlwin = "update tblPrintSetup set CreditInvoicePrinter = '" + ComboPrinterCredit.Text + "' , CreditInvoiceFile = '" + ComboFileCredit.SelectedValue + "' , " +
                 " Uploadby= '" + UserInfo.UserName + "' ,UploadDate = '" + UploadDate + "' ,SynID = 2 " +
                 " where TenentID= " + Tenent.TenentID + " and Shopid = '" + UserInfo.Shopid + "' ";
                 Datasyncpso.insert_Live_sync(sqlwin, "tblPrintSetup", "UPDATE");

                 string ActivityName = "Printer Setup";
                 string LogData = "Printer Setup Credit recipt Change  with Shopid = " + UserInfo.Shopid + " ";
                 Login.InsertUserLog(ActivityName, LogData);

                 lblMsgCredit.Visible = true;
                 lblMsgCredit.Text = "Update Successfully";

             }
        }

        private void btnKitchenReciptSave_Click(object sender, EventArgs e)
        {
            if(btnKitchen.Checked)
            {
                string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                string sql = "update tblPrintSetup set KitchenNotePrinter = '" + "None" + "' , KitchenNoteFile = '" + "None" + "' , " +
                " Uploadby= '" + UserInfo.UserName + "' ,UploadDate = '" + UploadDate + "' ,SynID = 2 " +
                " where TenentID= " + Tenent.TenentID + " and Shopid = '" + UserInfo.Shopid + "' ";
                int flag = DataAccess.ExecuteSQL(sql);

                if (flag == 1)
                {

                    string sqlwin = "update tblPrintSetup set KitchenNotePrinter = '" + "None" + "' , KitchenNoteFile = '" + "None" + "' , " +
                    " Uploadby= '" + UserInfo.UserName + "' ,UploadDate = '" + UploadDate + "' ,SynID = 2 " +
                    " where TenentID= " + Tenent.TenentID + " and Shopid = '" + UserInfo.Shopid + "' ";
                    Datasyncpso.insert_Live_sync(sqlwin, "tblPrintSetup", "UPDATE");

                    string ActivityName = "Printer Setup";
                    string LogData = "Printer Setup Kitchen recipt Change  with Shopid = " + UserInfo.Shopid + " ";
                    Login.InsertUserLog(ActivityName, LogData);

                    lblmsgKitchen.Visible = true;
                    lblmsgKitchen.Text = "Update Successfully";
                }
            }
            else
            { 
            string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
            string sql = "update tblPrintSetup set KitchenNotePrinter = '" + ComboPrinterKitchen.Text + "' , KitchenNoteFile = '" + comboFileKitchen.SelectedValue + "' , " +
            " Uploadby= '" + UserInfo.UserName + "' ,UploadDate = '" + UploadDate + "' ,SynID = 2 " +
            " where TenentID= " + Tenent.TenentID + " and Shopid = '" + UserInfo.Shopid + "' ";
            int flag = DataAccess.ExecuteSQL(sql);

            if (flag == 1)
            {

                string sqlwin = "update tblPrintSetup set KitchenNotePrinter = '" + ComboPrinterKitchen.Text + "' , KitchenNoteFile = '" + comboFileKitchen.SelectedValue + "' , " +
                " Uploadby= '" + UserInfo.UserName + "' ,UploadDate = '" + UploadDate + "' ,SynID = 2 " +
                " where TenentID= " + Tenent.TenentID + " and Shopid = '" + UserInfo.Shopid + "' ";
                Datasyncpso.insert_Live_sync(sqlwin, "tblPrintSetup", "UPDATE");

                string ActivityName = "Printer Setup";
                string LogData = "Printer Setup Kitchen recipt Change  with Shopid = " + UserInfo.Shopid + " ";
                Login.InsertUserLog(ActivityName, LogData);

                lblmsgKitchen.Visible = true;
                lblmsgKitchen.Text = "Update Successfully";
            }
            }
        }
    }
}
