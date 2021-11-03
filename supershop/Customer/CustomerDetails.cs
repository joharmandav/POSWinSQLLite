using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace supershop.Customer
{
    public partial class CustomerDetails : Form
    {
        public CustomerDetails()
        {
            InitializeComponent();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
                this.Close();
            return base.ProcessCmdKey(ref msg, keyData);
        }

        #region Databind
        private void CustomerDetails_Load(object sender, EventArgs e)
        {
            try
            {
                dtGrdvCustomerDetails.EnableHeadersVisualStyles = false;
                dtGrdvCustomerDetails.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
                dtGrdvCustomerDetails.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
                dtGrdvCustomerDetails.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                Databind();

                //Edit Button
                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                dtGrdvCustomerDetails.Columns.Add(btn);
                btn.HeaderText = "Edit";
                btn.Text = "Edit";
                btn.Name = "Edit";
                // btn.Width = 2;
                btn.UseColumnTextForButtonValue = true;

                //Delete Button
                DataGridViewButtonColumn del = new DataGridViewButtonColumn();
                dtGrdvCustomerDetails.Columns.Add(del);
                del.HeaderText = "Delete";
                del.Text = "Delete";
                del.Name = "Delete";
                del.UseColumnTextForButtonValue = true;

            }
            catch
            {
            }

        }

        public void Databind()
        {
            if (parameter.peopleid == "SUP")
            {
                string sqlCmd = "Select ID,Name,NameArabic,phone,Address,EmailAddress,City,DateOfBirth,PeopleType from  tbl_customer   where TenentID = " + Tenent.TenentID + " and PeopleType  = 'Supplier' and id != '1' "; //From view combination of tbl_customer and custcredit               
                DataTable dt1 = DataAccess.GetDataTable(sqlCmd);
                dtGrdvCustomerDetails.DataSource = dt1;
            }
            else
            {
                string sqlCmd = "Select ID,Name,NameArabic,phone,Address,EmailAddress,City,DateOfBirth,PeopleType from  tbl_customer  where TenentID = " + Tenent.TenentID + " and id != '1' and PeopleType  = '" + CombPeopleType.Text + "'";
                DataAccess.ExecuteSQL(sqlCmd);
                DataTable dt1 = DataAccess.GetDataTable(sqlCmd);
                dtGrdvCustomerDetails.DataSource = dt1;
               
            }

        }
        #endregion

        private void dtGrdvCustomerDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == dtGrdvCustomerDetails.Columns["Edit"].Index && e.RowIndex >= 0)
                {
                    DataGridViewRow row = dtGrdvCustomerDetails.Rows[e.RowIndex];
                    // label1.Text = row.Cells[0].Value.ToString();

                    Customer.AddNewCustomer mkc = new Customer.AddNewCustomer();
                    mkc.MdiParent = this.ParentForm;
                    mkc.CustID = row.Cells[2].Value.ToString();
                    //mkc.CustName = row.Cells[3].Value.ToString();
                    //mkc.CustArabicName = row.Cells[4].Value.ToString();
                    //mkc.CustPhone = row.Cells[5].Value.ToString();
                    //mkc.City = row.Cells[6].Value.ToString();
                    //mkc.Email = row.Cells[7].Value.ToString();
                    //mkc.CustAddress = row.Cells[8].Value.ToString();
                    //mkc.PeopleType = row.Cells[9].Value.ToString();

                    mkc.Show();
                }

                if (e.ColumnIndex == dtGrdvCustomerDetails.Columns["Delete"].Index && e.RowIndex >= 0)
                {
                    foreach (DataGridViewRow rowdel in dtGrdvCustomerDetails.SelectedRows)
                    {
                        int ID1 = Convert.ToInt32(rowdel.Cells[2].Value);
                        string Name = rowdel.Cells[3].Value.ToString();
                        string sql1 = "select * from  sales_payment where TenentID = " + Tenent.TenentID + " and c_id = " + ID1 + " group by sales_id  ";
                        DataTable dt = DataAccess.GetDataTable(sql1);

                        if (dt.Rows.Count > 0)
                        {
                            int Count = dt.Rows.Count;
                            MessageBox.Show(" " + Name + " Used in  " + Count + " Invoice, Not allow To Delete. ", "Yes or No", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                            return;
                        }
                        else
                        {
                            DialogResult result = MessageBox.Show("Do you want to Delete?", "Yes or No", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                            if (result == DialogResult.Yes)
                            {
                                int ID = Convert.ToInt32(rowdel.Cells[2].Value);

                                string sql = "delete from tbl_customer where TenentID = " + Tenent.TenentID + " and id = " + ID + " and id != '1' ";
                                DataAccess.ExecuteSQL(sql);

                                string sqlLive = "delete from Win_tbl_customer where TenentID = " + Tenent.TenentID + " and id = " + ID + " and id != '1'";
                                Datasyncpso.insert_Live_sync(sqlLive, "Win_tbl_customer", "DELETE");

                                MessageBox.Show("Has been Deleted", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                Databind();
                            }
                        }
                    }
                }

            }
            catch // (Exception exp)
            {
                // MessageBox.Show("Sorry" + exp.Message);
            }
        }

        #region Data serach
        private void txtCustomerSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {

                string sqlCmd = " Select ID,Name,NameArabic,phone,Address,EmailAddress,City,DateOfBirth,PeopleType from  tbl_customer " +
                                " where TenentID = " + Tenent.TenentID + " and id != '1'  and ( Name  like  '%" + txtCustomerSearch.Text + "%' or " +
                                " ID like  '%" + txtCustomerSearch.Text + "%'  or " +
                                "  phone  like  '%" + txtCustomerSearch.Text + "%' or " +
                                "  City  like  '%" + txtCustomerSearch.Text + "%'  or " +
                                " EmailAddress  like  '%" + txtCustomerSearch.Text + "%' )";
                // = txtCustomerSearch.Text ";// or Phone  like  '%" + txtCustomerSearch.Text + "%'  or City  like  '%" + txtCustomerSearch.Text + "%'  or emailAddress  like  '%" + txtCustomerSearch.Text + "%'";
                DataAccess.ExecuteSQL(sqlCmd);
                DataTable dt1 = DataAccess.GetDataTable(sqlCmd);
                dtGrdvCustomerDetails.DataSource = dt1;
            }
            catch
            {
            }
        }

        private void CombPeopleType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (CombPeopleType.Text == "All")
                {
                    // string sqlCmd = "select  Name , Phone as [Contact],  EmailAddress as [Email], City, Address , PeopleType  from tbl_customer";
                    string sqlCmd = "Select ID,Name,NameArabic,Mobile,Address,EmailAddress,City,PeopleType from  customercredit where TenentID = " + Tenent.TenentID + " and id != '1'";
                    DataAccess.ExecuteSQL(sqlCmd);
                    DataTable dt1 = DataAccess.GetDataTable(sqlCmd);
                    dtGrdvCustomerDetails.DataSource = dt1;

                    //DataGridViewColumn column = dtGrdvCustomerDetails.Columns[8];
                    //column.Width = 5;
                }
                else
                {
                    string sqlCmd = "Select ID,Name,NameArabic,Mobile,Address,EmailAddress,City,PeopleType from  customercredit  where TenentID = " + Tenent.TenentID + " and id != '1' and PeopleType  = '" + CombPeopleType.Text + "'";
                    DataAccess.ExecuteSQL(sqlCmd);
                    DataTable dt1 = DataAccess.GetDataTable(sqlCmd);
                    dtGrdvCustomerDetails.DataSource = dt1;
                }

            }
            catch
            {
            }
        }
        #endregion


        #region Page link
        private void btnAddNewCustLink_Click(object sender, EventArgs e)
        {
            Customer.AddNewCustomer go = new Customer.AddNewCustomer();
            go.MdiParent = this.ParentForm;
            go.Show();
            this.Close();
        }

        private void btnStoreCreditRewards_Click(object sender, EventArgs e)
        {
            Customer.RewardsManagerReport go = new Customer.RewardsManagerReport();
            go.MdiParent = this.ParentForm;
            go.Show();
        }
        #endregion

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string CustomerCode = txtCustomerCode.Text;
            CustomerCode = CustomerCode.Trim();
            string sqlCmd = "";
            if (CustomerCode != "")
            {
                sqlCmd = "Select ID,Name,NameArabic,Mobile,Address,EmailAddress,City,PeopleType from  customercredit where TenentID=" + Tenent.TenentID + "  and ID = '" + CustomerCode + "'  and id != '1' and PeopleType  = '" + CombPeopleType.Text + "'";
                DataTable dt1 = DataAccess.GetDataTable(sqlCmd);
                dtGrdvCustomerDetails.DataSource = dt1;
            }
            else
                Databind();
            
          
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = "CustomerDetail" + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".csv";
            saveFileDialog1.ShowDialog();
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            string csv = string.Empty;

            //Add the Header row for CSV file.
            foreach (DataGridViewColumn column in dtGrdvCustomerDetails.Columns)
            {
                csv += column.HeaderText + ',';
            }

            //Add new line.
            csv += "\r\n";

            //Adding the Rows
            foreach (DataGridViewRow row in dtGrdvCustomerDetails.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    //Add the Data rows.
                    csv += cell.Value.ToString().Replace(",", ";") + ',';
                }

                //Add new line.
                csv += "\r\n";
            }

            //Exporting to CSV.           
            string fileName = "CustomerDetail" + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".csv";
            string targetPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string destFile = System.IO.Path.Combine(targetPath, fileName);

            // To copy a folder's contents to a new location: 
            // Create a new target folder, if necessary. 
            if (!System.IO.Directory.Exists(targetPath))
            {
                System.IO.Directory.CreateDirectory(targetPath);

            }

            // Get file name.
            string name = saveFileDialog1.FileName;
            File.WriteAllText(name, csv);
        }
    }
}
