using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace supershop
{
    public partial class HelpPage : Form
    {
        public HelpPage()
        {
            InitializeComponent();
        }

        private void HelpPage_Load(object sender, EventArgs e)
        {        

            if (parameter.helpid == "SR")
            {
                tabControl1.SelectedTab =   tabSalesRegister;
            }
            else if (parameter.helpid == "config")
            {
                tabControl1.SelectedTab = tabSettings;
            }
            else if (parameter.helpid == "INV")
            {
                tabControl1.SelectedTab = tabPrintInovice;
            }

        }

        private void linkHelp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Help.HelpPageBarcode go = new Help.HelpPageBarcode();
            go.MdiParent = this.ParentForm;
            go.Show();
        }
    }
}
