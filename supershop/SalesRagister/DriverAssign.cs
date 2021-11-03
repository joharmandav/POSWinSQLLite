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
    public partial class DriverAssign : Form
    {
        private int desiredStartLocationX;
        private int desiredStartLocationY;
        public DriverAssign(int x, int y)
        {
            InitializeComponent();

            DataGridViewButtonColumn AssignDriver = new DataGridViewButtonColumn();
            this.dataGridViewDriverAssign.Columns.Add(AssignDriver);
            AssignDriver.HeaderText = "Action";
            AssignDriver.Text = "Assign";
            AssignDriver.Name = "Assign";
            AssignDriver.ToolTipText = "Assign Driver";
            AssignDriver.UseColumnTextForButtonValue = true;            

            this.desiredStartLocationX = x;
            this.desiredStartLocationY = y;

            Load += new EventHandler(DriverAssign_Load);
        }

        private void DriverAssign_Load(object sender, EventArgs e)
        {
            this.SetDesktopLocation(desiredStartLocationX, desiredStartLocationY);
            bindAssignDriver();            
        }

        
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MoveForm.ReleaseCapture();
                MoveForm.SendMessage(Handle, MoveForm.WM_NCLBUTTONDOWN, MoveForm.HT_CAPTION, 0);
            }
        }
       
        public string OrderNO
        {
            set
            {
                lblorderNO.Text = value;
            }
            get
            {
                return lblorderNO.Text;
            }
        }

        public void bindAssignDriver()
        {
            string sqlDriver = "select (Name ||' - '|| Father_name) as Name from usermgt where tenentid=" + Tenent.TenentID + " and position='Driver' ";
            DataAccess.ExecuteSQL(sqlDriver);
            DataTable dtDriver = DataAccess.GetDataTable(sqlDriver);
            if (dtDriver.Rows.Count > 0)
            {
                dataGridViewDriverAssign.DataSource = dtDriver;
                dataGridViewDriverAssign.Columns["Assign"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dataGridViewDriverAssign.Columns["Assign"].DisplayIndex = 1;
            }

        }

        private void dataGridViewDriverAssign_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == dataGridViewDriverAssign.Columns["Assign"].Index && e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewDriverAssign.Rows[e.RowIndex];
                string Name = row.Cells["Name"].Value.ToString();
                string DriverName = Name.Split('-')[0];
                DriverName = DriverName.Trim();

                string sql = "select * from sales_item where TenentID=" + Tenent.TenentID + " and InvoiceNO='" + lblorderNO.Text + "' ";
                DataTable dt = DataAccess.GetDataTable(sql);

                if (dt.Rows.Count > 0)
                {
                    string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                    string sql1 = " update sales_item set Driver='" + DriverName + "' , " +
                                  " Uploadby='" + UserInfo.UserName + "' ,UploadDate= '" + UploadDate + "' ,SynID=2 " +
                                  " where TenentID = " + Tenent.TenentID + " and InvoiceNO='" + lblorderNO.Text + "' ";
                    DataAccess.ExecuteSQL(sql1);

                    string sql1Win = " update Win_sales_item set Driver='" + DriverName + "' , " +
                                   " Uploadby='" + UserInfo.UserName + "' ,UploadDate= '" + UploadDate + "' ,SynID=2 " +
                                   " where TenentID = " + Tenent.TenentID + " and InvoiceNO='" + lblorderNO.Text + "' ";
                    Datasyncpso.insert_Live_sync(sql1Win, "Win_sales_item", "UPDATE");

                    string ActivityName = "Driver Assign";
                    string LogData = "Driver Assign with InvoiceNO = " + lblorderNO.Text + " ";
                    Login.InsertUserLog(ActivityName, LogData);
                }
            }

            if (Application.OpenForms["CashierAction"] != null)
            {
                Application.OpenForms["CashierAction"].Close();
            }

            if (Application.OpenForms["DriverAction"] != null)
            {
                Application.OpenForms["DriverAction"].Close();
            }

            UserInfo.TranjationPerform = "DriverAssign";
            if (Application.OpenForms["SalesRegister"] != null)
            {
                SalesRegister mkc1 = (SalesRegister)Application.OpenForms["SalesRegister"];
                mkc1.OrderNO = lblorderNO.Text;
                mkc1.Show();
            }

            this.Close();
        }

        private void btnColse_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       
    }
}
