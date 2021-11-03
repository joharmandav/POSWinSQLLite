using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace supershop
{
    public partial class SerialSearch : Form
    {
        ResourceManager res_man;
        // ResourceManager res_man1; // declare Resource manager to access to specific cultureinfo
        CultureInfo cul;
        public SerialSearch(double productid,string searchtext)
        {
            InitializeComponent();
            lblprodid.Text = productid.ToString();
            lblSearchtest.Text = searchtext.ToString();
           
        }

        public string PageName
        {
            set
            {
                lblPageName.Text = value;
            }
            get
            {
                return lblPageName.Text;
            }
            
        }

        private void CustomerSearch_Load(object sender, EventArgs e)
        {
            try
            {
                dtGrdvCustomerDetails.EnableHeadersVisualStyles = false;
                dtGrdvCustomerDetails.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
                dtGrdvCustomerDetails.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
                dtGrdvCustomerDetails.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                if (lblSearchtest.Text != "")
                {
                    txtCustomerSearch.Text = lblSearchtest.Text;
                    double pid = Convert.ToDouble(lblprodid.Text);
                    string Name = txtCustomerSearch.Text;
                    Name = Name.Trim();
                    string sqlCmd = "select Serial_Number from ICIT_BR_Serialize where tenentid=" + Tenent.TenentID + " and OnHand >=1 and MyProdID=" + pid + " and Serial_Number like '%" + Name + "%'";
                    DataTable dt1 = DataAccess.GetDataTable(sqlCmd);
                    dtGrdvCustomerDetails.DataSource = dt1;
                }
                else
                {
                    Databind();
                }
               

                //Select Button
                DataGridViewButtonColumn btnselect = new DataGridViewButtonColumn();
                dtGrdvCustomerDetails.Columns.Add(btnselect);
                btnselect.HeaderText = "Select";
                btnselect.Text = "Select";
                btnselect.Name = "Select";
                btnselect.UseColumnTextForButtonValue = true;
                btnselect.Width = 70;

            }
            catch
            {
            }

        }
        public void Databind()
        {
            double pid = Convert.ToDouble(lblprodid.Text);
            string sqlCmd = "select Serial_Number from ICIT_BR_Serialize where tenentid=" + Tenent.TenentID + " and OnHand >=1 and MyProdID=" + pid + "";
            DataTable dt1 = DataAccess.GetDataTable(sqlCmd);
            dtGrdvCustomerDetails.DataSource = dt1;
        }

        private void txtCustomerSearch_TextChanged(object sender, EventArgs e)
        {
            if(txtCustomerSearch.Text!="")
            {
                double pid = Convert.ToDouble(lblprodid.Text);
                string Name = txtCustomerSearch.Text;
                Name = Name.Trim();
                string sqlCmd = "select Serial_Number from ICIT_BR_Serialize where tenentid=" + Tenent.TenentID + " and OnHand >=1 and MyProdID=" + pid + " and Serial_Number like '%" + Name + "%'";
                             
                DataTable dt1 = DataAccess.GetDataTable(sqlCmd);
                dtGrdvCustomerDetails.DataSource = dt1;    
            }
            else
            {
                Databind();
            }
                    
        }

        private void dtGrdvCustomerDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {               
                if (e.ColumnIndex == dtGrdvCustomerDetails.Columns["Select"].Index && e.RowIndex >= 0)
                {
                    DataGridViewRow row = dtGrdvCustomerDetails.Rows[e.RowIndex];

                    string Serial_Number = row.Cells["Serial_Number"].Value.ToString();

                    if (lblPageName.Text == "SalesSerialize")
                    {
                        SalesSerialize mkc1 = (SalesSerialize)Application.OpenForms["SalesSerialize"];
                        mkc1.selectedSerial = Serial_Number;
                        mkc1.Show();
                        this.Close();
                    }
                   
                }
                else
                {
                    DataGridViewRow row = dtGrdvCustomerDetails.Rows[e.RowIndex];

                    string Serial_Number = row.Cells["Serial_Number"].Value.ToString();

                    if (lblPageName.Text == "SalesSerialize")
                    {
                        SalesSerialize mkc1 = (SalesSerialize)Application.OpenForms["SalesSerialize"];
                        mkc1.selectedSerial = Serial_Number;
                        mkc1.Show();
                        this.Close();
                    }
                   
                }
            }
            catch // (Exception exp)
            {
                // MessageBox.Show("Sorry" + exp.Message);
            }
        }


    }
}
