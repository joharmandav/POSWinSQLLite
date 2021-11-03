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
    public partial class Syncscreen : Form
    {
        public Syncscreen()
        {
            InitializeComponent();
        }

        private void CashierAction_Load(object sender, EventArgs e)
        {
            if (backSyncro.Minute == 0)
            {
                int syntyme = Home.getsyncTime();
                int Secound = syntyme / 60;
                int minutes = Secound / 1000;
                backSyncro.Minute = minutes;
                btnPrint.Text = " Do it Later " + minutes + " Minutes ";

                lblMsg.Text = backSyncro.Msg;
            }
            else
            {
                btnPrint.Text = " Do it Later " + backSyncro.Minute + " Minutes ";
                lblMsg.Text = backSyncro.Msg;
            }
        }

        bool flag = false;
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            flag = true;
        }
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            //Check if Flag is True ??? if so then make form position same 
            //as Cursor position
            if (flag == true)
            {
                this.Location = Cursor.Position;
            }
        }
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            flag = false;
        }

        private void btnColse_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if(UserInfo.usertype == "1")
            {
                if (Application.OpenForms["Home"] != null)
                {
                    Home Go = (Home)Application.OpenForms["Home"];
                    Go.syncstatus = "*";

                }
            }

            if(UserInfo.usertype == "2")
            {
                if (Application.OpenForms["Manager_Home"] != null)
                {
                    Manager_Home Go = (Manager_Home)Application.OpenForms["Manager_Home"];
                    Go.syncstatus = "*";

                }
            }

            if (UserInfo.usertype == "3")
            {
                if (Application.OpenForms["SalesMan_Home"] != null)
                {
                    SalesMan_Home Go = (SalesMan_Home)Application.OpenForms["SalesMan_Home"];
                    Go.syncstatus = "*";

                }
            }

            if (UserInfo.usertype == "4")
            {
                if (Application.OpenForms["Kitchen_Home"] != null)
                {
                    Kitchen_Home Go = (Kitchen_Home)Application.OpenForms["Kitchen_Home"];
                    Go.syncstatus = "*";

                }
            }

            if (UserInfo.usertype == "5")
            {
                if (Application.OpenForms["Driver_Home"] != null)
                {
                    Driver_Home Go = (Driver_Home)Application.OpenForms["Driver_Home"];
                    Go.syncstatus = "*";

                }
            }
            
        }

        private void DateTimer_Tick(object sender, EventArgs e)
        {
            if(backSyncro.Minute == 0)
            {
                int syntyme = Home.getsyncTime();
                int Secound = syntyme / 60;
                int minutes = Secound / 1000;
                backSyncro.Minute = minutes;

                btnPrint.Text = " Do it Later " + minutes + " Minutes ";

                lblMsg.Text = backSyncro.Msg;
                msgCount.Text = backSyncro.MsgCount;
            }
            else
            {
                btnPrint.Text = " Do it Later " + backSyncro.Minute + " Minutes ";

                lblMsg.Text = backSyncro.Msg;

                msgCount.Text = backSyncro.MsgCount;
            }
            
        }

    }
}
