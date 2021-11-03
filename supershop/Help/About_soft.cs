using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//for DLL's
using System.Runtime.InteropServices;
using System.Management;
namespace supershop
{
    public partial class About_soft : Form
    {
        public About_soft()
        {
            InitializeComponent();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
                this.Close();
            return base.ProcessCmdKey(ref msg, keyData);
        }

        //const and dll functions for moving form
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd,
            int Msg, int wParam, int lParam);

        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.erp53.com/user/ERP53");
        }

        private void About_soft_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void About_soft_Load(object sender, EventArgs e)
        {

            string MACAddress = Login.GetMACAddress() ;
            lbMacAddress.Text = MACAddress.ToString();

        }

    }
}
