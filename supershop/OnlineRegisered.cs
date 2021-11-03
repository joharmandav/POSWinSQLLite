using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace supershop
{
    public partial class OnlineRegisered : Form
    {
        public OnlineRegisered()
        {
            InitializeComponent();
        }

        private void GetPassword_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // SELECT TenentID,CompanyName,UserName,EmailID,MobileNo,Country,WeSiteURL,Password FROM NewCompaniySetup_Tryel

            if (Login.InternetConnection() == true)
            {
                bool CON_Ceck = Login.CheckDBConnection();

                if (CON_Ceck == true)
                {
                    int TenentIDreg = Login.get_reg_TenentID();

                    string sql = "select * from NewCompaniySetup_Tryel where UserName='" + txtUserName.Text + "' and EmailID='" + txtEmail.Text + "' ";
                    DataTable dt = DataLive.GetLiveDataTable(sql);
                    if (dt.Rows.Count > 0)
                    {
                        string CompanyName = dt.Rows[0]["CompanyName"] != null ? dt.Rows[0]["CompanyName"].ToString() : "";
                        string UserName = dt.Rows[0]["UserName"] != null ? dt.Rows[0]["UserName"].ToString() : "";
                        string EmailID = dt.Rows[0]["EmailID"] != null ? dt.Rows[0]["EmailID"].ToString() : "";
                        string MobileNo = dt.Rows[0]["MobileNo"] != null ? dt.Rows[0]["MobileNo"].ToString() : "";
                        string WeSiteURL = dt.Rows[0]["WeSiteURL"] != null ? dt.Rows[0]["WeSiteURL"].ToString() : "";
                        string Password = dt.Rows[0]["Password"] != null ? dt.Rows[0]["Password"].ToString() : "";

                        if (Application.OpenForms["Registation"] != null)
                        {
                           Registation GO = (Registation)Application.OpenForms["Registation"];
                           GO.CompanyName = CompanyName;
                           GO.UserName = UserName;
                           GO.EmailID = EmailID;
                           GO.MobileNo = MobileNo;
                           GO.WeSiteURL = WeSiteURL;
                           GO.Password = Password;
                           GO.Show();
                        }

                        this.Close();
                    }
                }
            }

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            bool falge = IsValid(txtEmail.Text);

            if (falge == false)
            {
                lblmsg.Visible = true;
                lblmsg.Text = "Invalid Email address";
                txtEmail.SelectAll();
            }
            else
            {
                lblmsg.Visible = false;
            }
        }

        public bool IsValid(string emailaddress)
        {
            try
            {
                if (emailaddress != "")
                {
                    MailAddress m = new MailAddress(emailaddress);
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}
