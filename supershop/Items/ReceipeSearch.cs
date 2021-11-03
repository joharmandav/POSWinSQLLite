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
    public partial class ReceipeSearch : Form
    {
        ResourceManager res_man;
        // ResourceManager res_man1; // declare Resource manager to access to specific cultureinfo
        CultureInfo cul;
        public ReceipeSearch()
        {
            InitializeComponent();

        }
        public string ReceipeType
        {
            set
            {
                lblReceipeType.Text = value;
            }
            get
            {
                return lblReceipeType.Text;
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
            string RecType = lblReceipeType.Text;
            string sqlCmd = "SELECT  (recNo || ' - ' ||Receipe_English || ' - ' || Receipe_Arabic) as Receipe    FROM tbl_Receipe where TenentID = " + Tenent.TenentID + " and RecType = '" + RecType + "' ";
            DataTable dt1 = DataAccess.GetDataTable(sqlCmd);
            dtGrdvCustomerDetails.DataSource = dt1;
        }

        private void txtCustomerSearch_TextChanged(object sender, EventArgs e)
        {
            string RecType = lblReceipeType.Text;
            if (txtCustomerSearch.Text != "")
            {
                string Name = txtCustomerSearch.Text;
                Name = Name.Trim();

                string sqlCmd = " SELECT  (recNo || ' - ' ||Receipe_English || ' - ' || Receipe_Arabic) as Receipe FROM tbl_Receipe " +
                                " where TenentID = " + Tenent.TenentID + " and (Receipe_English like '%" + Name + "%' or Receipe_Arabic like '%" + Name + "%'  or recNo like '%" + Name + "%') and RecType = '" + RecType + "' ";

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

                    string ReceipeName = row.Cells["Receipe"].Value.ToString();

                    ReceipeMenegement mkc1 = (ReceipeMenegement)Application.OpenForms["ReceipeMenegement"];
                    mkc1.ServiceTemplate = ReceipeName;                    
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
