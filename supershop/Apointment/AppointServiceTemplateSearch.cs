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
    public partial class AppointServiceTemplateSearch : Form
    {
        ResourceManager res_man;
        // ResourceManager res_man1; // declare Resource manager to access to specific cultureinfo
        CultureInfo cul;
        public AppointServiceTemplateSearch()
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
            string sqlCmd = "SELECT  (TR.Receipe_English || ' ~ ' || TR.recNo || ' ~ ' || TR.Receipe_Arabic) as Receipe " +
                         " FROM tbl_Receipe TR inner join Receipe_Menegement RM on RM.recNo = TR.recNo and RM.TenentID = TR.TenentID " +
                         " where RM.TenentID = " + Tenent.TenentID + " group by RM.recNo ";
            DataTable dt1 = DataAccess.GetDataTable(sqlCmd);
            dtGrdvCustomerDetails.DataSource = dt1;
        }

        private void txtCustomerSearch_TextChanged(object sender, EventArgs e)
        {
            if(txtCustomerSearch.Text!="")
            {
                string Name = txtCustomerSearch.Text;
                Name = Name.Trim();
                string sqlCmd = "SELECT  (TR.Receipe_English || ' ~ ' || TR.recNo || ' ~ ' || TR.Receipe_Arabic) as Receipe " +
                             " FROM tbl_Receipe TR inner join Receipe_Menegement RM on RM.recNo = TR.recNo and RM.TenentID = TR.TenentID " +
                             " where RM.TenentID = " + Tenent.TenentID + " and (TR.Receipe_English like '%" + Name + "%' or TR.Receipe_Arabic like '%" + Name + "%'  or TR.recNo like '%" + Name + "%') " +
                             " group by RM.recNo ";
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

                    if(lblPageName.Text=="Add_Appointment")
                    {
                        Add_Appointment mkc1 = (Add_Appointment)Application.OpenForms["Add_Appointment"];
                        mkc1.ServiceTemplate = ReceipeName;
                        mkc1.Show();
                        this.Close();
                    }
                    if (lblPageName.Text == "Add_Job")
                    {
                        Add_Job mkc1 = (Add_Job)Application.OpenForms["Add_Job"];
                        mkc1.ServiceTemplate = ReceipeName;
                        mkc1.Show();
                        this.Close();
                    }
                }
                else
                {
                    DataGridViewRow row = dtGrdvCustomerDetails.Rows[e.RowIndex];

                    string ReceipeName = row.Cells["Receipe"].Value.ToString();

                    if (lblPageName.Text == "Add_Appointment")
                    {
                        Add_Appointment mkc1 = (Add_Appointment)Application.OpenForms["Add_Appointment"];
                        mkc1.ServiceTemplate = ReceipeName;
                        mkc1.Show();
                        this.Close();
                    }
                    if (lblPageName.Text == "Add_Job")
                    {
                        Add_Job mkc1 = (Add_Job)Application.OpenForms["Add_Job"];
                        mkc1.ServiceTemplate = ReceipeName;
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
