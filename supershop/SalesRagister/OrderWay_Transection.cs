using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace supershop.SalesRagister
{
    public partial class OrderWay_Transection : Form
    {
        public OrderWay_Transection()
        {
            InitializeComponent();
        }


        private void OrderWay_Transection_Load(object sender, EventArgs e)
        {
            bindOrderWay();
        }
        public void bindOrderWay()
        {
            comboSalesMan.DataSource = null;
            comboSalesMan.Items.Clear();

            string sqlCust = "Select OrderWayID,Name1 from tbl_orderWay_transection where TenentID = " + Tenent.TenentID + " group by OrderWayID,Name1";
            DataAccess.ExecuteSQL(sqlCust);
            DataTable dtCust = DataAccess.GetDataTable(sqlCust);

            if (dtCust.Rows.Count > 0)
            {
                for (int i = 0; i < dtCust.Rows.Count; i++)
                {
                    comboSalesMan.Items.Add(dtCust.Rows[i][0] + " - " + dtCust.Rows[i][1]);
                }
            }
        }

        private void comboSalesMan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboSalesMan.Text != "Walk In" && comboSalesMan.Text != "")
            {
                string OrderWayID = comboSalesMan.Text.Split('-')[0].Trim();
                string Name = comboSalesMan.Text.Split('-')[1].Trim();

                //  Commission_per , Commission_Amount , Paid_Commission, Paid_Date , Paid_Reffrance ,Pending_Commission

                string sqlCust = " select orderwayid,Name1,Commission_per,sum(Commission_Amount) as Commission_Amount ," +
                                 " sum(Paid_Commission) as Paid_Commission,sum(Paid_Date) as Paid_Date," +
                                 " Paid_Reffrance,Paid_Date ,sum(Pending_Commission)as Pending_Commission" +
                                 " from tbl_orderWay_transection where TenentID = " + Tenent.TenentID + " and OrderWayID='" + OrderWayID + "' and Name1='" + Name + "' and paid_date is null " +
                                 " group by orderwayid,Name1 ";

                DataAccess.ExecuteSQL(sqlCust);
                DataTable dtCust = DataAccess.GetDataTable(sqlCust);

                if (dtCust.Rows.Count > 0)
                {
                    txtPEnding.Text = dtCust.Rows[0].ItemArray[8].ToString();
                }
                else
                {
                    txtPEnding.Text = "0";
                    txtPaidCommision.Text = " ";
                }
            }
        }

        private void bntSave_Click(object sender, EventArgs e)
        {
            if (comboSalesMan.Text == "")
            {
                MessageBox.Show("Please Select Order Way", "Yes or No", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                return;
            }
            if (txtPaidCommision.Text == "" || txtPaidCommision.Text == "0")
            {
                MessageBox.Show("Please enter Paid Commission", "Yes or No", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                return;
            }

            string OrderWayID = comboSalesMan.Text.Split('-')[0].Trim();
            string Name = comboSalesMan.Text.Split('-')[1].Trim();

            decimal pending = Convert.ToDecimal(txtPEnding.Text);
            decimal Paid = Convert.ToDecimal(txtPaidCommision.Text);
            string Paid_Reffrance = txtReffrance.Text;
            string Paid_Date = DateTime.Now.ToShortDateString();
            decimal Rest = Paid;
            // Paid_Commission
            // Paid_Date
            // Paid_Reffrance
            // Pending_Commission

            string sqlCust = " select * from tbl_orderWay_transection " +
                             " where TenentID = " + Tenent.TenentID + " and OrderWayID='" + OrderWayID + "' and Name1='" + Name + "' and  paid_date is null ";

            DataAccess.ExecuteSQL(sqlCust);
            DataTable dtCust = DataAccess.GetDataTable(sqlCust);

            for (int i = 0; i < dtCust.Rows.Count; i++)
            {
                decimal recPaid = Convert.ToDecimal(dtCust.Rows[i]["Pending_commission"]);
                int ID = Convert.ToInt32(dtCust.Rows[i]["ID"]);
                if (Rest >= recPaid)
                {
                    Rest = Rest - recPaid;

                    string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                    string sqlupdate = " update tbl_orderWay_transection set Paid_Commission='" + recPaid + "', Paid_Date='" + Paid_Date + "', " +
                                   " Paid_Reffrance='" + Paid_Reffrance + "' , " +
                                   " Uploadby= '" + UserInfo.UserName + "' ,UploadDate = '" + UploadDate + "' ,SynID = 2 " +
                                   " where TenentID= " + Tenent.TenentID + " and ID=" + ID;
                    DataAccess.ExecuteSQL(sqlupdate);

                    string sqlupdatewin = " update Win_tbl_orderWay_transection set Paid_Commission='" + recPaid + "', Paid_Date='" + Paid_Date + "', " +
                                   " Paid_Reffrance='" + Paid_Reffrance + "' , " +
                                   " Uploadby= '" + UserInfo.UserName + "' ,UploadDate = '" + UploadDate + "' ,SynID = 2 " +
                                   " where TenentID= " + Tenent.TenentID + " and ID=" + ID;
                    Datasyncpso.insert_Live_sync(sqlupdatewin, "Win_tbl_orderWay_transection", "UPDATE");
                }

            }

            SalesRagister.OrderWay_Transection go = new SalesRagister.OrderWay_Transection();
            go.MdiParent = this.ParentForm;
            go.Show();
            this.Close();
        }

    }
}
