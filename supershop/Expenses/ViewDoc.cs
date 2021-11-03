using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms; 
 

namespace supershop.Expenses
{
    public partial class ViewDoc : Form
    {
         
        public ViewDoc(string filename, string filetype)
        {
            InitializeComponent();
            this.Text = filename;
            lblfilename.Text = filename;
            lblFileExtension.Text = filetype;
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
                this.Close();
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void ViewDoc_Load(object sender, EventArgs e)
        {
            if (lblfilename.Text != string.Empty && lblFileExtension.Text != string.Empty)
            {
                if (lblFileExtension.Text == ".pdf")
                {
                    string path = Application.StartupPath + @"\ExpenseAttachment\" + lblfilename.Text;
                    this.webBrowser1.Navigate(path);
                    this.webBrowser1.Dock = DockStyle.Fill;
                    picSupportfile.Visible = false;
                }
                else if (lblFileExtension.Text == ".png" || lblFileExtension.Text == ".jpg")
                {
                    string path = Application.StartupPath + @"\ExpenseAttachment\" + lblfilename.Text;
                    picSupportfile.ImageLocation = path;
                    picSupportfile.Dock = DockStyle.Fill;
                    webBrowser1.Visible = false; 
                }
                else
                {
                    string path = Application.StartupPath + @"\ExpenseAttachment\" + "Nofile.pdf";
                    this.webBrowser1.Navigate(path);
                    this.webBrowser1.Dock = DockStyle.Fill;
                    picSupportfile.Visible = false;
                }
            }
            else
            {
                string path = Application.StartupPath + @"\ExpenseAttachment\" + "Nofile.pdf";
                this.webBrowser1.Navigate(path);
                this.webBrowser1.Dock = DockStyle.Fill;
                picSupportfile.Visible = false;
            }
            
        }
    }
}
