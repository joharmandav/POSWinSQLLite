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
    public partial class ReciepeReport : Form
    {
        public ReciepeReport()
        {
            InitializeComponent();
        }

        private void ReciepeReport_Load(object sender, EventArgs e)
        {
            BindReceipe();
        }

        public void BindReceipe()
        {
            string sql = "SELECT  (recNo || ' - ' ||Receipe_English || ' - ' || Receipe_Arabic) as Receipe    FROM tbl_Receipe where TenentID = " + Tenent.TenentID + " ";

            DataAccess.ExecuteSQL(sql);
            DataTable dt = DataAccess.GetDataTable(sql);
            //comboReceipe.DataSource = dt;
            //comboReceipe.DisplayMember = "Receipe";

            comboReceipe.Items.Clear();

            comboReceipe.Items.Add("---- select Receipe ----");
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    comboReceipe.Items.Add(dt.Rows[i][0]);
                }
            }
            comboReceipe.Text = "---- select Receipe ----";
        }

        private void btnRefreshReceipe_Click(object sender, EventArgs e)
        {
            BindReceipe();
        }

        private void comboReceipe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboReceipe.Text != "" && comboReceipe.Text != "System.Data.DataRowView" && comboReceipe.Text != "---- select Receipe ----")
            {
                string RecValye = comboReceipe.Text.Trim();

                string recVanno = RecValye.Split('-')[0].Trim();

                int recNo = Convert.ToInt32(recVanno);

                BindEdit(recNo);
            }
        }

        public bool CheckReceipeExist(int recNo)
        {
            string Str = "select * from Receipe_Menegement Where TenentID = " + Tenent.TenentID + " and recNo = " + recNo + "; ";
            DataTable dt = DataAccess.GetDataTable(Str);

            if (dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void BindEdit(int recNo)
        {
            string Str = " SELECT (product_id || ' - ' ||product_name || ' - ' || product_name_Arabic || ' - ' || Receipe_Menegement.UOM ) as Items, " +
                     " Receipe_Menegement.IOSwitch as 'Item Type', Receipe_Menegement.Qty" +
                     " FROM  purchase " +
                     " Inner Join Receipe_Menegement on purchase.product_id = Receipe_Menegement.ItemCode " +
                     " where purchase.TenentID = " + Tenent.TenentID + " and product_id = Receipe_Menegement.ItemCode and Receipe_Menegement.recNo = " + recNo + " order by Receipe_Menegement.IOSwitch ";

            DataTable dtInput = DataAccess.GetDataTable(Str);

            dtGrdLedgerReport.DataSource = dtInput;
            dtGrdLedgerReport.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dtGrdLedgerReport.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

        }
    }
}
