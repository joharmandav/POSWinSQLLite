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
    public partial class CatagorySearch : Form
    {
        ResourceManager res_man;
        // ResourceManager res_man1; // declare Resource manager to access to specific cultureinfo
        CultureInfo cul;
        public CatagorySearch()
        {
            InitializeComponent();

            dtGrdvCustomerDetails.EnableHeadersVisualStyles = false;
            dtGrdvCustomerDetails.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dtGrdvCustomerDetails.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dtGrdvCustomerDetails.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            //Select Button
            DataGridViewButtonColumn btnselect = new DataGridViewButtonColumn();
            dtGrdvCustomerDetails.Columns.Add(btnselect);
            btnselect.HeaderText = "Select";
            btnselect.Text = "Select";
            btnselect.Name = "Select";
            btnselect.UseColumnTextForButtonValue = true;
            btnselect.Width = 70;

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
                Databind();
            }
            catch
            {
            }

        }
        public void Databind()
        {
            string sqlCmd = " select CATID,CAT_NAME1 as 'category in English',CAT_NAME2 as 'category in Arabic' From CAT_MST Where TenentID = " + Tenent.TenentID + " ";

            DataTable dt1 = DataAccess.GetDataTable(sqlCmd);
            dtGrdvCustomerDetails.DataSource = dt1;

            dtGrdvCustomerDetails.Columns["Select"].DisplayIndex = 3;
            dtGrdvCustomerDetails.Columns["Select"].Width = 100;
        }

        private void txtCetegorySearch_TextChanged(object sender, EventArgs e)
        {
            if (txtCetegorySearch.Text != "")
            {
                string Name = txtCetegorySearch.Text;
                Name = Name.Trim();

                string sqlCmd = " select CATID,CAT_NAME1 as 'category in English',CAT_NAME2 as 'category in Arabic' From CAT_MST " +
                                " Where TenentID = " + Tenent.TenentID + " and ( CAT_NAME1 like '%" + Name + "%' or CAT_NAME2 like '%" + Name + "%' or CATID Like '%" + Name + "%' ) ";

                DataTable dt1 = DataAccess.GetDataTable(sqlCmd);
                dtGrdvCustomerDetails.DataSource = dt1;

                dtGrdvCustomerDetails.Columns["Select"].DisplayIndex = 3;
                dtGrdvCustomerDetails.Columns["Select"].Width = 100;
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

                    string category = row.Cells["category in English"].Value.ToString();

                    if(lblPageName.Text == "salesreport")
                    {
                        salesreport mkc1 = (salesreport)Application.OpenForms["salesreport"];
                        mkc1.setcategory = category;
                        mkc1.Show();
                    }
                    else if (lblPageName.Text == "Add_Item")
                    {
                        Add_Item mkc1 = (Add_Item)Application.OpenForms["Add_Item"];
                        mkc1.selectCatagory = category;
                    }
                    else if (lblPageName.Text == "Stock_List")
                    {
                        Stock_List mkc1 = (Stock_List)Application.OpenForms["Stock_List"];
                        mkc1.selectCatagory = category;
                    }
                    else if (lblPageName.Text == "ReceipeMenegement")
                    {
                        ReceipeMenegement mkc1 = (ReceipeMenegement)Application.OpenForms["ReceipeMenegement"];
                        mkc1.selectCatagory = category;
                    }
                    else if (lblPageName.Text == "AppintmentReceipe")
                    {
                        AppintmentReceipe mkc1 = (AppintmentReceipe)Application.OpenForms["AppintmentReceipe"];
                        mkc1.selectCatagory = category;
                    }
                    else
                    {

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
