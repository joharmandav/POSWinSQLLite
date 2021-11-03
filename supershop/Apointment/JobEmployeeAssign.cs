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
    public partial class JobEmployeeAssign : Form
    {
        private int desiredStartLocationX;
        private int desiredStartLocationY;
        public JobEmployeeAssign(int x, int y)
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

            Load += new EventHandler(EmployeeAssign_Load);
        }

        private void EmployeeAssign_Load(object sender, EventArgs e)
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

        public string Appintment_id
        {
            set
            {
                lblAppointmentNO.Text = value;
            }
            get
            {
                return lblAppointmentNO.Text;
            }
        }

        public string JobID
        {
            set
            {
                MasterCODE.Text = value;
            }
            get
            {
                return MasterCODE.Text;
            }
        }

        public void bindAssignDriver()
        {
            string sqlDriver = "select (Name ||' - '|| Father_name) as Name from usermgt where tenentid=" + Tenent.TenentID + " and (position = 'Spa Employee' or position = 'Admin') ";        
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
                string EmployeeName = Name.Split('-')[0];
                EmployeeName = EmployeeName.Trim();

                string sql = "select * from CRMMainActivities where TenentID=" + Tenent.TenentID + "  and MasterCODE = " + MasterCODE.Text + " and MyID = '" + lblAppointmentNO.Text + "' ";
                DataTable dt = DataAccess.GetDataTable(sql);

                if (dt.Rows.Count > 0)
                {
                    string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                    string sql1 = " update CRMMainActivities set USERNAME='" + EmployeeName + "',  " +
                                  " UploadDate = '" + UploadDate + "', Uploadby = '" + UserInfo.UserName + "', SynID = 2 " +
                                  " where TenentID = " + Tenent.TenentID + " and MasterCODE = " + MasterCODE.Text + " and MyID = '" + lblAppointmentNO.Text + "'  ";
                    DataAccess.ExecuteSQL(sql1);
                    Datasyncpso.insert_Live_sync(sql1, "CRMMainActivities", "UPDATE");

                    string sql2 = " update CRMActivities set USERNAME='" + EmployeeName + "',  " +
                                  " UploadDate = '" + UploadDate + "', Uploadby = '" + UserInfo.UserName + "', SynID = 2 " +
                                  " where TenentID = " + Tenent.TenentID + " and MasterCODE = " + MasterCODE.Text + "  ";
                    DataAccess.ExecuteSQL(sql2);
                    Datasyncpso.insert_Live_sync(sql2, "CRMActivities", "UPDATE");
                }
            }
            this.Close();
        }

        private void btnColse_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       
    }
}
