using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace supershop
{
    public partial class Cusromer_Eye_Data : Form
    {
        public Cusromer_Eye_Data()
        {
            InitializeComponent();
            dtDateofCheck.Format = DateTimePickerFormat.Custom;
            dtDateofCheck.CustomFormat = "yyyy-MM-dd";

            DataGridViewButtonColumn del = new DataGridViewButtonColumn();
            datagridEyeHistory.Columns.Add(del);
            del.HeaderText = "Delete";
            del.Text = "Delete";
            del.Name = "Delete";
            del.ToolTipText = "Delete this UOM";
            del.UseColumnTextForButtonValue = true;
            del.Width = 100;

            DataGridViewButtonColumn EditConv = new DataGridViewButtonColumn();
            datagridEyeHistory.Columns.Add(EditConv);
            EditConv.HeaderText = "Edit";
            EditConv.Text = "Edit";
            EditConv.Name = "Edit";
            EditConv.ToolTipText = "Edit this UOM Conversion";
            EditConv.UseColumnTextForButtonValue = true;
            EditConv.Width = 100;
        }

        public string CustomerID
        {
            set
            {
                lblCustomerID.Text = value;
            }
            get
            {
                return lblCustomerID.Text;
            }
        }

        public string CustomerName
        {
            set
            {
                txtCustomerName.Text = value;
            }
            get
            {
                return txtCustomerName.Text;
            }
        }

        private void Cusromer_Eye_Data_Load(object sender, EventArgs e)
        {
            string sql = "select * from tbl_customer where TenentID = " + Tenent.TenentID + " and ID = '" + lblCustomerID.Text + "' ";
            DataTable dt = DataAccess.GetDataTable(sql);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    txtCustomerName.Text = dt.Rows[0]["Name"] != null && dt.Rows[0]["Name"].ToString() != "" ? dt.Rows[0]["Name"].ToString() : "";
                }
            }
            DataBind();
        }

        public void DataBind()
        {
            string sql1 = "  select MyID as ID , DateOFCheck as 'Date of Check'  from tbl_Customer_Eye_history  where TenentID = " + Tenent.TenentID + " and CustomerID = '" + lblCustomerID.Text + "'";
            DataTable dt1 = DataAccess.GetDataTable(sql1);
            datagridEyeHistory.DataSource = dt1;

            datagridEyeHistory.Columns["Edit"].DisplayIndex = 3;
            datagridEyeHistory.Columns["Edit"].Width = 100;

            datagridEyeHistory.Columns["Delete"].DisplayIndex = 3;
            datagridEyeHistory.Columns["Delete"].Width = 100;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //TenentID,CustomerID,MyID,DateOFCheck,RSPHDistance,RSPHReading,RCylDistance,RCylReading,RAxisDistance,RAxisReading,
            //LPDDistance,LPDReading,LSPHDistance,LSPHReading,LCylDistance,LCylReading,LAxisDistance,LAxisReading

            //TenentID,CustomerID,MyID,DateOFCheck,RSPHDistance,RSPHReading,RCylDistance,RCylReading,RAxisDistance,RAxisReading,
            //LPDDistance,LPDReading,LSPHDistance,LSPHReading,LCylDistance,LCylReading,LAxisDistance,LAxisReading

            string CustomerID = lblCustomerID.Text;
            string DateOFCheck = dtDateofCheck.Text;
            int MyID = 0;

            if (lblMyID.Text == "-")
            {
                MyID = DataAccess.getCustomer_Eye_MYid(Tenent.TenentID, CustomerID);
            }
            else
            {
                MyID = Convert.ToInt32(lblMyID.Text);
            }

            string RSPHDistance = txtRSPHDistance.Text;
            string RSPHReading = txtRSPHReading.Text;
            string RCylDistance = txtRCylDistance.Text;
            string RCylReading = txtRCylReading.Text;
            string RAxisDistance = txtRAxisDistance.Text;
            string RAxisReading = txtRAxisReading.Text;
            string LPDDistance = txtLPDDistance.Text;
            string LPDReading = txtLPDReading.Text;
            string LSPHDistance = txtLSPHDistance.Text;
            string LSPHReading = txtLSPHReading.Text;
            string LCylDistance = txtLCylDistance.Text;
            string LCylReading = txtLCylReading.Text;
            string LAxisDistance = txtLAxisDistance.Text;
            string LAxisReading = txtLAxisReading.Text;


            string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");

            string sqlselect = " select * from tbl_Customer_Eye_history where TenentID = " + Tenent.TenentID + " and CustomerID = '" + lblCustomerID.Text + "' and MyID = '" + MyID + "' ";
            DataTable Dtselect = DataAccess.GetDataTable(sqlselect);

            if (Dtselect.Rows.Count < 1)
            {
                string sqlinsert = " insert into tbl_Customer_Eye_history ( TenentID,CustomerID,MyID,DateOFCheck,RSPHDistance,RSPHReading,RCylDistance,RCylReading,RAxisDistance,RAxisReading, " +
                                   " LPDDistance,LPDReading,LSPHDistance,LSPHReading,LCylDistance,LCylReading,LAxisDistance,LAxisReading , UploadDate,Uploadby,SynID) " +
                                   " values ( " + Tenent.TenentID + " , '" + lblCustomerID.Text + "' , '" + MyID + "','" + DateOFCheck + "','" + RSPHDistance + "','" + RSPHReading + "', " +
                                   " '" + RCylDistance + "' , '" + RCylReading + "', '" + RAxisDistance + "','" + RAxisReading + "','" + LPDDistance + "','" + LPDReading + "',  " +
                                   " '" + LSPHDistance + "','" + LSPHReading + "','" + LCylDistance + "', '" + LCylReading + "' , '" + LAxisDistance + "', '" + LAxisReading + "' , " +
                                   " '" + UploadDate + "' , '" + UserInfo.UserName + "',1 ) ";
                DataAccess.ExecuteSQL(sqlinsert);
                Datasyncpso.insert_Live_sync(sqlinsert, "tbl_Customer_Eye_history", "INSERT");

            }
            else
            {
                string SqlUpdate = " Update tbl_Customer_Eye_history set DateOFCheck = '" + DateOFCheck + "' , RSPHDistance = '" + RSPHDistance + "' ,RSPHReading = '" + RSPHReading + "' , " +
                                   " RCylDistance = '" + RCylDistance + "' ,RCylReading = '" + RCylReading + "' ,RAxisDistance = '" + RAxisDistance + "' ,RAxisReading = '" + RAxisReading + "' , " +
                                   " LPDDistance = '" + LPDDistance + "' ,LPDReading = '" + LPDReading + "' ,LSPHDistance = '" + LSPHDistance + "' ,LSPHReading = '" + LSPHReading + "' , " +
                                   " LCylDistance = '" + LCylDistance + "' ,LCylReading = '" + LCylReading + "' ,LAxisDistance = '" + LAxisDistance + "' ,LAxisReading = '" + LAxisReading + "'  , " +
                                   " UploadDate = '" + UploadDate + "',Uploadby = '" + UserInfo.UserName + "',SynID = 2 " +
                                   " where TenentID = " + Tenent.TenentID + " and CustomerID = '" + lblCustomerID.Text + "' and MyID = '" + MyID + "' ";
                DataAccess.ExecuteSQL(SqlUpdate);
                Datasyncpso.insert_Live_sync(SqlUpdate, "tbl_Customer_Eye_history", "UPDATE");
            }
   
            Cusromer_Eye_Data go = new Cusromer_Eye_Data();
            go.MdiParent = Application.OpenForms[UserInfo.MDiPerent];
            go.CustomerID = lblCustomerID.Text;
            go.CustomerName = txtCustomerName.Text;
            go.Show();

            this.Close();            
        }

        public void EditDate(int MYID)
        {
            string sqlselect = " select * from tbl_Customer_Eye_history where TenentID = " + Tenent.TenentID + " and CustomerID = '" + lblCustomerID.Text + "' and MyID = '" + MYID + "' ";
            DataTable Dtselect = DataAccess.GetDataTable(sqlselect);
            if (Dtselect.Rows.Count > 0)
            {
                DateTime DateofCheck = Convert.ToDateTime(Dtselect.Rows[0]["DateOFCheck"]);
                dtDateofCheck.Text = DateofCheck.ToString("yyyy-MM-dd");

                string RSPHDistance = Dtselect.Rows[0]["RSPHDistance"] != null && Dtselect.Rows[0]["RSPHDistance"].ToString() != "" ? Dtselect.Rows[0]["RSPHDistance"].ToString() : "";
                txtRSPHDistance.Text = RSPHDistance;

                string RSPHReading = Dtselect.Rows[0]["RSPHReading"] != null && Dtselect.Rows[0]["RSPHReading"].ToString() != "" ? Dtselect.Rows[0]["RSPHReading"].ToString() : "";
                txtRSPHReading.Text = RSPHReading;

                string RCylDistance = Dtselect.Rows[0]["RCylDistance"] != null && Dtselect.Rows[0]["RCylDistance"].ToString() != "" ? Dtselect.Rows[0]["RCylDistance"].ToString() : "";
                txtRCylDistance.Text = RCylDistance;

                string RCylReading = Dtselect.Rows[0]["RCylReading"] != null && Dtselect.Rows[0]["RCylReading"].ToString() != "" ? Dtselect.Rows[0]["RCylReading"].ToString() : "";
                txtRCylReading.Text = RCylReading;

                string RAxisDistance = Dtselect.Rows[0]["RAxisDistance"] != null && Dtselect.Rows[0]["RAxisDistance"].ToString() != "" ? Dtselect.Rows[0]["RAxisDistance"].ToString() : "";
                txtRAxisDistance.Text = RAxisDistance;

                string RAxisReading = Dtselect.Rows[0]["RAxisReading"] != null && Dtselect.Rows[0]["RAxisReading"].ToString() != "" ? Dtselect.Rows[0]["RAxisReading"].ToString() : "";
                txtRAxisReading.Text = RAxisReading;

                string LPDDistance = Dtselect.Rows[0]["LPDDistance"] != null && Dtselect.Rows[0]["LPDDistance"].ToString() != "" ? Dtselect.Rows[0]["LPDDistance"].ToString() : "";
                txtLPDDistance.Text = LPDDistance;

                string LPDReading = Dtselect.Rows[0]["LPDReading"] != null && Dtselect.Rows[0]["LPDReading"].ToString() != "" ? Dtselect.Rows[0]["LPDReading"].ToString() : "";
                txtLPDReading.Text = LPDReading;

                string LSPHDistance = Dtselect.Rows[0]["LSPHDistance"] != null && Dtselect.Rows[0]["LSPHDistance"].ToString() != "" ? Dtselect.Rows[0]["LSPHDistance"].ToString() : "";
                txtLSPHDistance.Text = LSPHDistance;

                string LSPHReading = Dtselect.Rows[0]["LSPHReading"] != null && Dtselect.Rows[0]["LSPHReading"].ToString() != "" ? Dtselect.Rows[0]["LSPHReading"].ToString() : "";
                txtLSPHReading.Text = LSPHReading;

                string LCylDistance = Dtselect.Rows[0]["LCylDistance"] != null && Dtselect.Rows[0]["LCylDistance"].ToString() != "" ? Dtselect.Rows[0]["LCylDistance"].ToString() : "";
                txtLCylDistance.Text = LCylDistance;

                string LCylReading = Dtselect.Rows[0]["LCylReading"] != null && Dtselect.Rows[0]["LCylReading"].ToString() != "" ? Dtselect.Rows[0]["LCylReading"].ToString() : "";
                txtLCylReading.Text = LCylReading;

                string LAxisDistance = Dtselect.Rows[0]["LAxisDistance"] != null && Dtselect.Rows[0]["LAxisDistance"].ToString() != "" ? Dtselect.Rows[0]["LAxisDistance"].ToString() : "";
                txtLAxisDistance.Text = LAxisDistance;

                string LAxisReading = Dtselect.Rows[0]["LAxisReading"] != null && Dtselect.Rows[0]["LAxisReading"].ToString() != "" ? Dtselect.Rows[0]["LAxisReading"].ToString() : "";
                txtLAxisReading.Text = LAxisReading;

            }
        }

        private void datagridEyeHistory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == datagridEyeHistory.Columns["Delete"].Index && e.RowIndex >= 0)
            {
                foreach (DataGridViewRow row in datagridEyeHistory.SelectedRows)
                {
                    int MYID = Convert.ToInt32(row.Cells["ID"].Value.ToString());

                    string sqlselect = " select * from tbl_Customer_Eye_history where TenentID = " + Tenent.TenentID + " and CustomerID = '" + lblCustomerID.Text + "' and MyID = '" + MYID + "' ";
                    DataTable Dtselect = DataAccess.GetDataTable(sqlselect);
                    if (Dtselect.Rows.Count > 0)
                    {
                        string SqlDelete = " Delete from tbl_Customer_Eye_history where TenentID = " + Tenent.TenentID + " and CustomerID = '" + lblCustomerID.Text + "' and MyID = '" + MYID + "' ";

                        DataAccess.ExecuteSQL(SqlDelete);
                        Datasyncpso.insert_Live_sync(SqlDelete, "tbl_Customer_Eye_history", "DELETE");

                        DataBind();

                    }

                }
            }
            else if (e.ColumnIndex == datagridEyeHistory.Columns["Edit"].Index && e.RowIndex >= 0)
            {
                foreach (DataGridViewRow row in datagridEyeHistory.SelectedRows)
                {
                    int MYID = Convert.ToInt32(row.Cells["ID"].Value.ToString());
                    lblMyID.Text = MYID.ToString();
                    EditDate(MYID);
                }
            }
            else
            {
                foreach (DataGridViewRow row in datagridEyeHistory.SelectedRows)
                {
                    int MYID = Convert.ToInt32(row.Cells["ID"].Value.ToString());
                    lblMyID.Text = MYID.ToString();
                    EditDate(MYID);
                }
            }            
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cusromer_Eye_Data go = new Cusromer_Eye_Data();
            go.MdiParent = Application.OpenForms[UserInfo.MDiPerent];
            go.CustomerID = lblCustomerID.Text;
            go.CustomerName = txtCustomerName.Text;
            go.Show();

            this.Close();  
        }

        private void txtLAxisReading_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\'' || e.KeyChar == '"')
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

    }
}
