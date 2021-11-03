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

namespace supershop.User_mgt
{
    public partial class GetPassword : Form
    {
        public GetPassword()
        {
            InitializeComponent();
        }

        private void GetPassword_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text != "" && txtEmail.Text != "")
            {
                Both();
            }
            else if (txtUserName.Text != "")
            {
                WithUserName();
            }
            else if (txtEmail.Text != "")
            {
                WithEmail();
            }
            else
            {
                if (txtUserName.Text == "")
                {
                    lblmsg.Visible = true;
                    lblmsg.Text = "Enter User name";
                    txtUserName.Focus();
                    return;
                }

                if (txtEmail.Text == "")
                {
                    lblmsg.Visible = true;
                    lblmsg.Text = "Enter Email";
                    txtEmail.Focus();
                    return;
                }
            }



        }

        public void WithUserName()
        {
            try
            {
                if (Login.InternetConnection() == true)
                {
                    bool CON_Ceck = Login.CheckDBConnection();

                    if (CON_Ceck == true)
                    {
                        int TenentIDreg = Login.get_reg_TenentID();

                        string sql = "select * from VW_CheckLogin_Win where TenentID=" + TenentIDreg + " and Username='" + txtUserName.Text + "' ";
                        DataTable dt = DataLive.GetLiveDataTable(sql);
                        if (dt.Rows.Count > 0)
                        {
                            string email = dt.Rows[0]["Email"].ToString();
                            string Username = dt.Rows[0]["Username"].ToString();
                            string Password = dt.Rows[0]["password"].ToString();
                            string LastLogin = lastLogin(TenentIDreg, Username);

                            DateTime LAst = Convert.ToDateTime(LastLogin);

                            string DateLogin = LAst.ToString("dd/MMM/yyyy");

                            string body = "Your email : " + email + " <BR> username = : <b> " + Username + " </b> <BR> PassWord : <b>" + Password + " </b> <BR> Last Login = <b> " + DateLogin + " </b> ";
                            bool flag = sendEmail(body, email);

                            if (flag == true)
                            {
                                string ActivityName = "send Email";
                                string LogData = "send Email with email : " + email + " and username = : " + Username + " ";
                                Login.InsertUserLog(ActivityName, LogData);

                                MessageBox.Show("Password Send in Your Ragistered Email, If You Not Seen in Inbox Please Show in Spam");
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Problem To Send Email");
                                this.Close();
                            }
                        }
                        else
                        {
                            lblmsg.Visible = true;
                            lblmsg.Text = "Your User Name Not Match In Our Server";
                            return;
                        }
                    }
                    else
                    {
                        lblmsg.Visible = true;
                        lblmsg.Text = "server Down OR Temparary Unavalable Please Try After Some Time";
                        return;
                    }
                }
                else
                {
                    lblmsg.Visible = true;
                    lblmsg.Text = "Check Your Internet Connection";
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void WithEmail()
        {
            try
            {
                if (Login.InternetConnection() == true)
                {
                    bool CON_Ceck = Login.CheckDBConnection();

                    if (CON_Ceck == true)
                    {
                        int TenentIDreg = Login.get_reg_TenentID();

                        string sql = "select * from VW_CheckLogin_Win where TenentID=" + TenentIDreg + " and Email='" + txtEmail.Text + "' ";
                        DataTable dt = DataLive.GetLiveDataTable(sql);
                        if (dt.Rows.Count > 0)
                        {
                            string sql1 = "select UserName,Password,Email from VW_CheckLogin_Win where TenentID=" + TenentIDreg + " and Email='" + txtEmail.Text + "' group by UserName,Password,Email ";
                            DataTable dt1 = DataLive.GetLiveDataTable(sql1);
                            int count = dt1.Rows.Count;
                            if (count > 1)
                            {
                                lblmsg.Visible = true;
                                lblmsg.Text = "Found Multiple User in Registered Email. Enter User name";
                                txtUserName.Focus();
                                return;
                            }

                            string email = dt.Rows[0]["Email"].ToString();
                            string Username = dt.Rows[0]["Username"].ToString();
                            string Password = dt.Rows[0]["password"].ToString();
                            string LastLogin = lastLogin(TenentIDreg, Username);

                            DateTime LAst = Convert.ToDateTime(LastLogin);

                            string DateLogin = LAst.ToString("dd/MMM/yyyy");

                            string body = "Your email : " + email + " <BR> username = : <b> " + Username + " </b> <BR> PassWord : <b>" + Password + " </b> <BR> Last Login = <b> " + DateLogin + " </b> ";
                            bool flag = sendEmail(body, email);

                            if (flag == true)
                            {
                                string ActivityName = "send Email";
                                string LogData = "send Email with email : " + email + " and username = : " + Username + " ";
                                Login.InsertUserLog(ActivityName, LogData);

                                MessageBox.Show("Password Send in Your Email \n If You Not Seen in Inbox Please Show in Spam");
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Problem To Send Email");
                                this.Close();
                            }
                        }
                        else
                        {
                            lblmsg.Visible = true;
                            lblmsg.Text = "Your Email Not Match In Our Server";
                            return;
                        }
                    }
                    else
                    {
                        lblmsg.Visible = true;
                        lblmsg.Text = "server Down OR Temparary Unavalable Please Try After Some Time";
                        return;
                    }
                }
                else
                {
                    lblmsg.Visible = true;
                    lblmsg.Text = "Check Your Internet Connection";
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void Both()
        {
            if (txtUserName.Text == "")
            {
                lblmsg.Visible = true;
                lblmsg.Text = "Enter User name";
                txtUserName.Focus();
                return;
            }

            if (txtEmail.Text == "")
            {
                lblmsg.Visible = true;
                lblmsg.Text = "Enter Email";
                txtEmail.Focus();
                return;
            }

            try
            {
                if (Login.InternetConnection() == true)
                {
                    bool CON_Ceck = Login.CheckDBConnection();

                    if (CON_Ceck == true)
                    {
                        int TenentIDreg = Login.get_reg_TenentID();

                        string sql = "select *  from VW_CheckLogin_Win where TenentID=" + TenentIDreg + " and Username='" + txtUserName.Text + "' and Email='" + txtEmail.Text + "' ";
                        DataTable dt = DataLive.GetLiveDataTable(sql);
                        if (dt.Rows.Count > 0)
                        {
                            string email = dt.Rows[0]["Email"].ToString();
                            string Username = dt.Rows[0]["Username"].ToString();
                            string Password = dt.Rows[0]["password"].ToString();
                            string LastLogin = lastLogin(TenentIDreg, Username);

                            DateTime LAst = Convert.ToDateTime(LastLogin);

                            string DateLogin = LAst.ToString("dd/MMM/yyyy");

                            string body = "Your email : " + email + " <BR> username = : <b> " + Username + " </b> <BR> PassWord : <b>" + Password + " </b> <BR> Last Login = <b> " + DateLogin + " </b> ";
                            bool flag = sendEmail(body, email);

                            string ActivityName = "send Email";
                            string LogData = "send Email with email : " + email + " and username = : " + Username + " ";
                            Login.InsertUserLog(ActivityName, LogData);

                            if (flag == true)
                            {
                                MessageBox.Show("Password Send in Your Email \n If You Not Seen in Inbox Please Show in Spam");
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Problem To Send Email");
                                this.Close();
                            }
                        }
                        else
                        {
                            lblmsg.Visible = true;
                            lblmsg.Text = "Your User Name or Email Not Match In Our Server";
                            return;
                        }
                    }
                    else
                    {
                        lblmsg.Visible = true;
                        lblmsg.Text = "server Down OR Temparary Unavalable Please Try After Some Time";
                        return;
                    }
                }
                else
                {
                    lblmsg.Visible = true;
                    lblmsg.Text = "Check Your Internet Connection";
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public bool sendEmail(string body, string email)
        {
            try
            {
                if (String.IsNullOrEmpty(email))
                    return false;

                System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();

                msg.Subject = "Thanks you for Visiting our site..";

                msg.From = new System.Net.Mail.MailAddress("info@pos53.com");

                msg.To.Add(new System.Net.Mail.MailAddress(email));
                msg.BodyEncoding = System.Text.Encoding.UTF8;
                msg.Body = body;                
                msg.IsBodyHtml = true;
                msg.Priority = System.Net.Mail.MailPriority.High;


                System.Net.Mail.SmtpClient smpt = new System.Net.Mail.SmtpClient();
                smpt.UseDefaultCredentials = false;
                smpt.Host = "webmail.pos53.com";//for google required smtp.gmail.com and must be check Google Account setting https://myaccount.google.com/lesssecureapps?pli=1 ON

                smpt.Port = 25;

                smpt.EnableSsl = false;//for google required true

                smpt.Credentials = new System.Net.NetworkCredential("info@pos53.com", "Ayo1234");

                smpt.Send(msg);
                return true;
            }
            catch
            {
                return false;
            }


        }

        public string lastLogin(int TenentID,string UserName)
        {
            string lastLogindate = "";
            string sql = "select TOP 1 * from Win_tbl_workrecords where TenentID=" + TenentID + " and Username = '" + UserName + "' order by logdatetime desc ";
            DataTable dt = DataLive.GetLiveDataTable(sql);
            if (dt.Rows.Count > 0)
            {
                lastLogindate = dt.Rows[0]["logdatetime"].ToString();
            }
            return lastLogindate;
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
