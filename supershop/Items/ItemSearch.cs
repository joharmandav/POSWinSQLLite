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
    public partial class ItemSearch : Form
    {
        ResourceManager res_man;
        // ResourceManager res_man1; // declare Resource manager to access to specific cultureinfo
        CultureInfo cul;
        public ItemSearch()
        {
            InitializeComponent();

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

        private void ItemSearch_Load(object sender, EventArgs e)
        {
            try
            {
                dtGrdvCustomerDetails.EnableHeadersVisualStyles = false;
                dtGrdvCustomerDetails.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
                dtGrdvCustomerDetails.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
                dtGrdvCustomerDetails.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                Databind();

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
            string sqlCmd = "";
            if (lblPageName.Text == "salesreport")
            {
                sqlCmd = " select Product_ID as 'Item ID',pi.custitemCode as 'Item Code',Product_Name as 'Item Name' " +
                         " from purchase pi inner join tbl_item_uom_price iup on iup.itemID = pi.Product_ID and iup.TenentID = pi.TenentID " +
                         " Inner join sales_item si ON si.itemCode = pi.Product_ID and si.TenentID = pi.TenentID " +
                         " where pi.TenentID = " + Tenent.TenentID + " " +
                         " group by Product_ID Order by Product_ID";
            }
            else
            {
                sqlCmd = " select Product_ID as 'Item ID',custitemCode as 'Item Code',Product_Name as 'Item Name' " +
                         " from purchase pi inner join tbl_item_uom_price iup on iup.itemID = pi.Product_ID and iup.TenentID = pi.TenentID " +
                         " where pi.TenentID = " + Tenent.TenentID + " " +
                         " group by Product_ID Order by Product_ID ";
            }
            
            DataTable dt1 = DataAccess.GetDataTable(sqlCmd);
            dtGrdvCustomerDetails.DataSource = dt1;
        }

        private void txtCustomerSearch_TextChanged(object sender, EventArgs e)
        {
            if(txtCustomerSearch.Text!="")
            {
                string Name = txtCustomerSearch.Text;
                Name = Name.Trim();

                string sqlCmd = "";
                if (lblPageName.Text == "salesreport")
                {
                    sqlCmd = " select Product_ID as 'Item ID',pi.custitemCode as 'Item Code',Product_Name as 'Item Name' " +
                             " from purchase pi inner join tbl_item_uom_price iup on iup.itemID = pi.Product_ID and iup.TenentID = pi.TenentID " +
                             " Inner join sales_item si ON si.itemCode = pi.Product_ID and si.TenentID = pi.TenentID " +
                             " where pi.TenentID = " + Tenent.TenentID + " and ( Product_Name like '%" + Name + "%' or pi.custitemCode like '%" + Name + "%' or Product_ID Like '%" + Name + "%' ) " +
                             " group by Product_ID Order by Product_ID";
                }
                else
                {
                    sqlCmd = " select Product_ID as 'Item ID',custitemCode as 'Item Code',Product_Name as 'Item Name' " +
                             " from purchase pi inner join tbl_item_uom_price iup on iup.itemID = pi.Product_ID and iup.TenentID = pi.TenentID " +
                             " where pi.TenentID = " + Tenent.TenentID + " and ( Product_Name like '%" + Name + "%' or custitemCode like '%" + Name + "%' or Product_ID Like '%" + Name + "%' ) " +
                             " group by Product_ID ";
                }

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

                    string Product_ID = row.Cells["Item ID"].Value.ToString();

                    string ItemName = row.Cells["Item Name"].Value.ToString();

                    if (lblPageName.Text == "salesreport")
                    {
                        salesreport mkc1 = (salesreport)Application.OpenForms["salesreport"];
                        mkc1.ItemName = ItemName;
                        mkc1.Show();
                    }
                    else
                    {
                        if (Application.OpenForms["Add_Item"] != null)
                        {
                            Application.OpenForms["Add_Item"].Close();
                        }
                        this.Refresh();

                        Add_Item go = new Add_Item();
                        go.MdiParent = Application.OpenForms[UserInfo.MDiPerent];
                        go.itemCode = Product_ID;
                        go.Show();
                    }

                    this.Close();
                }
            }
            catch // (Exception exp)
            {
                // MessageBox.Show("Sorry" + exp.Message);
            }
        }

    }
}
