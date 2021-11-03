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
    public partial class CustomerJobHistory : Form
    {
        ResourceManager res_man;
        // ResourceManager res_man1; // declare Resource manager to access to specific cultureinfo
        CultureInfo cul;
        public CustomerJobHistory()
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

        public string Customer
        {
            set
            {
                lblCustomerName.Text = value;
            }
            get
            {
                return lblCustomerName.Text;
            }
        }

        private void CustomerJobHistory_Load(object sender, EventArgs e)
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

        public string getRecipeName(int recNo)
        {
            string RecipeName = "-- select Receipe / Package --";
            string sql = "SELECT  (TR.recNo || ' - ' ||TR.Receipe_English || ' - ' || TR.Receipe_Arabic) as Receipe " +
                         " FROM tbl_Receipe TR inner join Receipe_Menegement RM on RM.recNo = TR.recNo and RM.TenentID = TR.TenentID " +
                         " where RM.TenentID = " + Tenent.TenentID + " and TR.recNo = " + recNo + " ";
            DataTable dt = DataAccess.GetDataTable(sql);
            if(dt.Rows.Count > 0)
            {
                RecipeName = dt.Rows[0]["Receipe"].ToString();
            }
            return RecipeName;
        }

        public void Databind()
        {
            if (lblCustomerName.Text != "-")
            {
                //2 - Dj - 12345879630
                int CUSTID = Convert.ToInt32(lblCustomerName.Text.ToString().Split('-')[0].Trim());
                string sqlCmd = "select CMA.MasterCode as 'Job ID',CMA.ACTIVITYE as 'Job Title', (CMA.UseReciepeID || ' - ' || CMA.UseReciepeName) as 'Use Service Template', " +
                            " CMA.Remarks as 'Remarks',  CMA.USERNAME as 'Employee',CMA.MyStatus as 'InvoiceNO'  " +
                            " from CRMMainActivities CMA  inner join CRMActivities CA on CA.TenentID = CMA.TenentID and CA.MasterCode = CMA.MasterCode  " +
                            " inner join Appointment AP on AP.ID = CMA.MyID and AP.TenentID = CMA.TenentID " +
                            " inner join tbl_customer TC on  AP.c_id  = TC.ID and AP.TenentID  = TC.TenentID " +
                            " where CMA.TenentID = " + Tenent.TenentID + " and TC.ID = " + CUSTID + " ; ";
                DataTable dt1 = DataAccess.GetDataTable(sqlCmd);
                dtGrdvCustomerDetails.DataSource = dt1;
                dtGrdvCustomerDetails.Columns["Job ID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dtGrdvCustomerDetails.Columns["Employee"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dtGrdvCustomerDetails.Columns["InvoiceNO"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

                dtGrdvCustomerDetails.Columns["Job Title"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dtGrdvCustomerDetails.Columns["Remarks"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dtGrdvCustomerDetails.Columns["Use Service Template"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            }
        }

        private void dtGrdvCustomerDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == dtGrdvCustomerDetails.Columns["Select"].Index && e.RowIndex >= 0)
                {
                    DataGridViewRow row = dtGrdvCustomerDetails.Rows[e.RowIndex];
                    // 1 - T SHIRT Ironing - الملابس قميص تي
                    int recNo = Convert.ToInt32(row.Cells["Use Service Template"].Value.ToString().Split('-')[0].Trim());
                    string ReceipeName = getRecipeName(recNo);

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
                else
                {
                    DataGridViewRow row = dtGrdvCustomerDetails.Rows[e.RowIndex];

                    int recNo = Convert.ToInt32(row.Cells["Use Service Template"].Value.ToString().Split('-')[0].Trim());
                    string ReceipeName = getRecipeName(recNo);

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

        private void btnReset_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
