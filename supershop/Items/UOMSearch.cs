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
    public partial class UOMSearch : Form
    {
        ResourceManager res_man;
        // ResourceManager res_man1; // declare Resource manager to access to specific cultureinfo
        CultureInfo cul;
        public UOMSearch()
        {
            InitializeComponent();

        }

        public string MultiUOM
        {
            set
            {
                lblMultiUOM.Text = value;
            }
            get
            {
                return lblMultiUOM.Text;
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
            if (lblMultiUOM.Text == "YES")
            {
                sqlCmd = " select UOM, UOMNAME1 ||' - '|| UOMNAME2 as 'UOMNAME' from ICUOM " +
                         " inner join ICUOMCONV on ICUOMCONV.TenentID = ICUOM.TenentID and ICUOMCONV.FUOM = ICUOM.UOM " +
                         " where ICUOM.TenentID= " + Tenent.TenentID + " Group by ICUOMCONV.FUOM";
            }
            else
            {
                sqlCmd = " select  UOM, UOMNAME1 ||' - '|| UOMNAME2 as 'UOMNAME' from ICUOM " + 
                         " where TenentID=" + Tenent.TenentID + " and UOM not in (select Fuom from ICUOMCONV where TenentID = ICUOM.TenentID)";
            }

            DataTable dt1 = DataAccess.GetDataTable(sqlCmd);
            dtGrdvCustomerDetails.DataSource = dt1;
        }

        private void txtCustomerSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtCustomerSearch.Text != "")
            {
                string Name = txtCustomerSearch.Text;
                Name = Name.Trim();

                string sqlCmd = "";

                if (lblMultiUOM.Text == "YES")
                {
                    sqlCmd = " select UOM, UOMNAME1 ||' - '|| UOMNAME2 as 'UOMNAME' from ICUOM " +
                             " inner join ICUOMCONV on ICUOMCONV.TenentID = ICUOM.TenentID and ICUOMCONV.FUOM = ICUOM.UOM " +
                             " where ICUOM.TenentID= " + Tenent.TenentID + " and ( UOMNAME1 like '%" + Name + "%' or UOMNAME2 like '%" + Name + "%' or UOM like '%" + Name + "%' ) " + 
                             " Group by ICUOMCONV.FUOM ";
                }
                else
                {
                    sqlCmd = " select  UOM, UOMNAME1 ||' - '|| UOMNAME2 as 'UOMNAME' from ICUOM " +
                             " where TenentID=" + Tenent.TenentID + " and ( UOMNAME1 like '%" + Name + "%' or UOMNAME2 like '%" + Name + "%' or UOM like '%" + Name + "%' ) and UOM not in (select Fuom from ICUOMCONV where TenentID = ICUOM.TenentID)";
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

                    string UOMNAME = row.Cells["UOMNAME"].Value.ToString().Trim();

                    string SelectUOM = UOMNAME.Split('-')[0];

                    if (Application.OpenForms["Add_Item"] != null)
                    {
                        Add_Item mkc1 = (Add_Item)Application.OpenForms["Add_Item"];
                        mkc1.selectUOM = SelectUOM;
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
