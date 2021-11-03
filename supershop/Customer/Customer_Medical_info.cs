using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace supershop.Customer
{
    public partial class Customer_Medical_info : Form
    {
        public Customer_Medical_info()
        {
            InitializeComponent();

            dtDateOfBirth.Format = DateTimePickerFormat.Custom;
            dtDateOfBirth.CustomFormat = "yyyy-MM-dd";

            dtDateOfBirth.Text = "1970-01-01";

            lblCompanyName.Text = DataAccess.GetCompanyFullName();

            string Path = UserInfo.LOGO;
            if (File.Exists(Path))
            {
                pictureLogo.Image = Image.FromFile(Path);
            }
            else
            {
                Path = Application.StartupPath + @"\LOGO\POS53.png";
                pictureLogo.Image = Image.FromFile(Path);
            }
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

        private void Customer_Medical_info_Load(object sender, EventArgs e)
        {
            lblMSG.Visible = false;

            string sqlselect = " select * from tbl_Customer_Medical where TenentID = " + Tenent.TenentID + " and CustomerID = '" + lblCustomerID.Text + "' ";
            DataTable Dtselect = DataAccess.GetDataTable(sqlselect);

            if (Dtselect.Rows.Count < 1)
            {

                string sql = "select * from tbl_customer where TenentID = " + Tenent.TenentID + " and ID = '" + lblCustomerID.Text + "' ";
                DataTable dt = DataAccess.GetDataTable(sql);
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        txtCustomerName.Text = dt.Rows[0]["Name"] != null && dt.Rows[0]["Name"].ToString() != "" ? dt.Rows[0]["Name"].ToString() : "";

                        txtContact.Text = dt.Rows[0]["Phone"] != null && dt.Rows[0]["Phone"].ToString() != "" ? dt.Rows[0]["Phone"].ToString() : "";

                        txtEmail.Text = dt.Rows[0]["EmailAddress"] != null && dt.Rows[0]["EmailAddress"].ToString() != "" ? dt.Rows[0]["EmailAddress"].ToString() : "";

                        txtAddress.Text = dt.Rows[0]["Address"] != null && dt.Rows[0]["Address"].ToString() != "" ? dt.Rows[0]["Address"].ToString() : "";

                        dtDateOfBirth.Text = dt.Rows[0]["DateOfBirth"] != null && dt.Rows[0]["DateOfBirth"].ToString() != "" ? dt.Rows[0]["DateOfBirth"].ToString() : "1970-01-01";
                    }
                }
            }
            else
            {
                txtAge.Text = Dtselect.Rows[0]["Age"] != null && Dtselect.Rows[0]["Age"].ToString() != "" ? Dtselect.Rows[0]["Age"].ToString() : "";
                dtDateOfBirth.Text = Dtselect.Rows[0]["BirthDate"] != null && Dtselect.Rows[0]["BirthDate"].ToString() != "" ? Dtselect.Rows[0]["BirthDate"].ToString() : "";
                txtStatus.Text = Dtselect.Rows[0]["status"] != null && Dtselect.Rows[0]["status"].ToString() != "" ? Dtselect.Rows[0]["status"].ToString() : "";
                txtAddress.Text = Dtselect.Rows[0]["Address"] != null && Dtselect.Rows[0]["Address"].ToString() != "" ? Dtselect.Rows[0]["Address"].ToString() : "";
                txtContact.Text = Dtselect.Rows[0]["Phone"] != null && Dtselect.Rows[0]["Phone"].ToString() != "" ? Dtselect.Rows[0]["Phone"].ToString() : "";
                txtRefferedBy.Text = Dtselect.Rows[0]["RefferdBy"] != null && Dtselect.Rows[0]["RefferdBy"].ToString() != "" ? Dtselect.Rows[0]["RefferdBy"].ToString() : "";
                txtEmail.Text = Dtselect.Rows[0]["Email"] != null && Dtselect.Rows[0]["Email"].ToString() != "" ? Dtselect.Rows[0]["Email"].ToString() : "";
                txtChiefComplaint.Text = Dtselect.Rows[0]["ChiftComplaint"] != null && Dtselect.Rows[0]["ChiftComplaint"].ToString() != "" ? Dtselect.Rows[0]["ChiftComplaint"].ToString() : "";
                txtSkinProblem.Text = Dtselect.Rows[0]["ScreenProblem"] != null && Dtselect.Rows[0]["ScreenProblem"].ToString() != "" ? Dtselect.Rows[0]["ScreenProblem"].ToString() : "";
                if (txtSkinProblem.Text != "") { chkskinProblem.Checked = true; }
                txtTakingMadication.Text = Dtselect.Rows[0]["TakingMedication"] != null && Dtselect.Rows[0]["TakingMedication"].ToString() != "" ? Dtselect.Rows[0]["TakingMedication"].ToString() : "";
                string ISPregnent = Dtselect.Rows[0]["ISPregnent"] != null && Dtselect.Rows[0]["ISPregnent"].ToString() != "" ? Dtselect.Rows[0]["ISPregnent"].ToString() : "0";
                if (ISPregnent == "1")
                {
                    chkPregnant.Checked = true;
                }
                txtRiskFector.Text = Dtselect.Rows[0]["AnyRiskFactor"] != null && Dtselect.Rows[0]["AnyRiskFactor"].ToString() != "" ? Dtselect.Rows[0]["AnyRiskFactor"].ToString() : "";
                string PreviousSkinTreatments = Dtselect.Rows[0]["PreviousSkinTreatments"] != null && Dtselect.Rows[0]["PreviousSkinTreatments"].ToString() != "" ? Dtselect.Rows[0]["PreviousSkinTreatments"].ToString() : "";
                GetPreviousSkinTreatments(PreviousSkinTreatments);
                string ApplyToYou = Dtselect.Rows[0]["ApplyToYou"] != null && Dtselect.Rows[0]["ApplyToYou"].ToString() != "" ? Dtselect.Rows[0]["ApplyToYou"].ToString() : "";
                GetApplyToYou(ApplyToYou);
                txtAnyCondition.Text = Dtselect.Rows[0]["AnyCondition"] != null && Dtselect.Rows[0]["AnyCondition"].ToString() != "" ? Dtselect.Rows[0]["AnyCondition"].ToString() : "";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string Age = txtAge.Text;
            string BirthDate = dtDateOfBirth.Text;
            string status = txtStatus.Text;
            string Address = txtAddress.Text;
            string Phone = txtContact.Text;
            string RefferdBy = txtRefferedBy.Text;
            string Email = txtEmail.Text;
            string ChiftComplaint = txtChiefComplaint.Text;
            string ScreenProblem = txtSkinProblem.Text;
            string TakingMedication = txtTakingMadication.Text;
            int ISPregnent = 0;
            if (chkPregnant.Checked == true)
            {
                ISPregnent = 1;
            }
            string AnyRiskFactor = txtRiskFector.Text;
            string PreviousSkinTreatments = selecttedPreviousSkinTreatments();
            string ApplyToYou = selecttedApplyToYou();
            string AnyCondition = txtAnyCondition.Text;

            string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");

            string sqlselect = " select * from tbl_Customer_Medical where TenentID = " + Tenent.TenentID + " and CustomerID = '" + lblCustomerID.Text + "' ";
            DataTable Dtselect = DataAccess.GetDataTable(sqlselect);

            if (Dtselect.Rows.Count < 1)
            {
                string sqlinsert = " insert into tbl_Customer_Medical ( TenentID, CustomerID, Age, BirthDate, status, Address, Phone, RefferdBy, Email, ChiftComplaint, ScreenProblem, TakingMedication, " +
                               " ISPregnent, AnyRiskFactor, PreviousSkinTreatments, ApplyToYou,AnyCondition, UploadDate, Uploadby, SynID) " +
                               " values ( " + Tenent.TenentID + " , '" + lblCustomerID.Text + "' , '" + Age + "','" + BirthDate + "','" + status + "','" + Address + "', '" + Phone + "' , '" + RefferdBy + "', " +
                               " '" + Email + "','" + ChiftComplaint + "','" + ScreenProblem + "','" + TakingMedication + "', '" + ISPregnent + "','" + AnyRiskFactor + "','" + PreviousSkinTreatments + "', " +
                               " '" + ApplyToYou + "' , '" + AnyCondition + "' ,'" + UploadDate + "' , '" + UserInfo.UserName + "',1 ) ";
                DataAccess.ExecuteSQL(sqlinsert);
                Datasyncpso.insert_Live_sync(sqlinsert, "tbl_Customer_Medical", "INSERT");

                lblMSG.Text = "Save Success";
                lblMSG.Visible = true;
            }
            else
            {
                string SqlUpdate = " Update tbl_Customer_Medical set Age = '" + Age + "',BirthDate = '" + BirthDate + "',status = '" + status + "', " +
                                   " Address = '" + Address + "',Phone = '" + Phone + "',RefferdBy = '" + RefferdBy + "',Email = '" + Email + "', " +
                                   " ChiftComplaint = '" + ChiftComplaint + "',ScreenProblem = '" + ScreenProblem + "',TakingMedication = '" + TakingMedication + "', " +
                                   " ISPregnent = '" + ISPregnent + "',AnyRiskFactor = '" + AnyRiskFactor + "',PreviousSkinTreatments = '" + PreviousSkinTreatments + "', " +
                                   " ApplyToYou = '" + ApplyToYou + "',AnyCondition = '" + AnyCondition + "',UploadDate = '" + UploadDate + "',Uploadby = '" + UserInfo.UserName + "',SynID = 2 " +
                                   " where TenentID = " + Tenent.TenentID + " and CustomerID = '" + lblCustomerID.Text + "' ";
                DataAccess.ExecuteSQL(SqlUpdate);
                Datasyncpso.insert_Live_sync(SqlUpdate, "tbl_Customer_Medical", "UPDATE");

                lblMSG.Text = "Update Success";
                lblMSG.Visible = true;
            }

        }

        public string selecttedPreviousSkinTreatments()
        {
            string PreviousSkinTreatments = "";

            if (chkFacials.Checked == true) { PreviousSkinTreatments = chkFacials.Text; }
            if (chkChemicalPeeling.Checked == true) { PreviousSkinTreatments = PreviousSkinTreatments + ", " + chkChemicalPeeling.Text; }
            if (chkAHA_BHA.Checked == true) { PreviousSkinTreatments = PreviousSkinTreatments + ", " + chkAHA_BHA.Text; }
            if (chkAccutane.Checked == true) { PreviousSkinTreatments = PreviousSkinTreatments + ", " + chkAccutane.Text; }
            if (chkMicrodermabrasion.Checked == true) { PreviousSkinTreatments = PreviousSkinTreatments + ", " + chkMicrodermabrasion.Text; }
            if (chkRetin.Checked == true) { PreviousSkinTreatments = PreviousSkinTreatments + ", " + chkRetin.Text; }

            PreviousSkinTreatments = PreviousSkinTreatments.Trim();
            PreviousSkinTreatments = PreviousSkinTreatments.TrimStart(',');
            PreviousSkinTreatments = PreviousSkinTreatments.TrimEnd(',');
            PreviousSkinTreatments = PreviousSkinTreatments.Trim();

            return PreviousSkinTreatments;

        }

        public string selecttedApplyToYou()
        {
            string ApplyToYou = "";

            if (chkAlleries.Checked == true) { ApplyToYou = chkAlleries.Text; }
            if (chkDiabetes.Checked == true) { ApplyToYou = ApplyToYou + ", " + chkDiabetes.Text; }
            if (chkKidneyDysfunction.Checked == true) { ApplyToYou = ApplyToYou + ", " + chkKidneyDysfunction.Text; }
            if (chkSkinDisease.Checked == true) { ApplyToYou = ApplyToYou + ", " + chkSkinDisease.Text; }
            if (chkJointReplacement.Checked == true) { ApplyToYou = ApplyToYou + ", " + chkJointReplacement.Text; }
            if (chkBloodClots.Checked == true) { ApplyToYou = ApplyToYou + ", " + chkBloodClots.Text; }
            if (chkSkinCancer.Checked == true) { ApplyToYou = ApplyToYou + ", " + chkSkinCancer.Text; }
            if (chkHighLowBP.Checked == true) { ApplyToYou = ApplyToYou + ", " + chkHighLowBP.Text; }
            if (chkNumbness.Checked == true) { ApplyToYou = ApplyToYou + ", " + chkNumbness.Text; }
            if (chkMetalImplants.Checked == true) { ApplyToYou = ApplyToYou + ", " + chkMetalImplants.Text; }
            if (chkNeuropathy.Checked == true) { ApplyToYou = ApplyToYou + ", " + chkNeuropathy.Text; }
            if (chkSprainsorStrains.Checked == true) { ApplyToYou = ApplyToYou + ", " + chkSprainsorStrains.Text; }
            if (chkFibromyalgia.Checked == true) { ApplyToYou = ApplyToYou + ", " + chkFibromyalgia.Text; }
            if (chkBellsPalsy.Checked == true) { ApplyToYou = ApplyToYou + ", " + chkBellsPalsy.Text; }
            if (chkStroke.Checked == true) { ApplyToYou = ApplyToYou + ", " + chkStroke.Text; }
            if (chkArthritis.Checked == true) { ApplyToYou = ApplyToYou + ", " + chkArthritis.Text; }
            if (chkHeartAttack.Checked == true) { ApplyToYou = ApplyToYou + ", " + chkHeartAttack.Text; }
            if (chkHeadAchesMigraines.Checked == true) { ApplyToYou = ApplyToYou + ", " + chkHeadAchesMigraines.Text; }

            ApplyToYou = ApplyToYou.Trim();
            ApplyToYou = ApplyToYou.TrimStart(',');
            ApplyToYou = ApplyToYou.TrimEnd(',');
            ApplyToYou = ApplyToYou.Trim();

            return ApplyToYou;
        }

        public void GetPreviousSkinTreatments(string PreviousSkinTreatments)
        {
            if (PreviousSkinTreatments.Contains(chkFacials.Text)) { chkFacials.Checked = true; }
            if (PreviousSkinTreatments.Contains(chkChemicalPeeling.Text)) { chkChemicalPeeling.Checked = true; }
            if (PreviousSkinTreatments.Contains(chkAHA_BHA.Text)) { chkAHA_BHA.Checked = true; }
            if (PreviousSkinTreatments.Contains(chkAccutane.Text)) { chkAccutane.Checked = true; }
            if (PreviousSkinTreatments.Contains(chkMicrodermabrasion.Text)) { chkMicrodermabrasion.Checked = true; }
            if (PreviousSkinTreatments.Contains(chkRetin.Text)) { chkRetin.Checked = true; }
        }

        public void GetApplyToYou(string ApplyToYou)
        {
            if (ApplyToYou.Contains(chkAlleries.Text)) { chkAlleries.Checked = true; }
            if (ApplyToYou.Contains(chkDiabetes.Text)) { chkDiabetes.Checked = true; }
            if (ApplyToYou.Contains(chkKidneyDysfunction.Text)) { chkKidneyDysfunction.Checked = true; }
            if (ApplyToYou.Contains(chkSkinDisease.Text)) { chkSkinDisease.Checked = true; }
            if (ApplyToYou.Contains(chkJointReplacement.Text)) { chkJointReplacement.Checked = true; }
            if (ApplyToYou.Contains(chkBloodClots.Text)) { chkBloodClots.Checked = true; }
            if (ApplyToYou.Contains(chkSkinCancer.Text)) { chkSkinCancer.Checked = true; }
            if (ApplyToYou.Contains(chkHighLowBP.Text)) { chkHighLowBP.Checked = true; }
            if (ApplyToYou.Contains(chkNumbness.Text)) { chkNumbness.Checked = true; }
            if (ApplyToYou.Contains(chkMetalImplants.Text)) { chkMetalImplants.Checked = true; }
            if (ApplyToYou.Contains(chkNeuropathy.Text)) { chkNeuropathy.Checked = true; }
            if (ApplyToYou.Contains(chkSprainsorStrains.Text)) { chkSprainsorStrains.Checked = true; }
            if (ApplyToYou.Contains(chkFibromyalgia.Text)) { chkFibromyalgia.Checked = true; }
            if (ApplyToYou.Contains(chkBellsPalsy.Text)) { chkBellsPalsy.Checked = true; }
            if (ApplyToYou.Contains(chkStroke.Text)) { chkStroke.Checked = true; }
            if (ApplyToYou.Contains(chkArthritis.Text)) { chkArthritis.Checked = true; }
            if (ApplyToYou.Contains(chkHeartAttack.Text)) { chkHeartAttack.Checked = true; }
            if (ApplyToYou.Contains(chkHeadAchesMigraines.Text)) { chkHeadAchesMigraines.Checked = true; }

        }

        private void txtAge_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                bool ignoreKeyPress = false;

                bool matchString = Regex.IsMatch(txtAge.Text.ToString(), @"\.\d\d\d");

                if (e.KeyChar == '\b') // Always allow a Backspace
                    ignoreKeyPress = false;
                else if (matchString)
                    ignoreKeyPress = true;
                else if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                    ignoreKeyPress = true;
                else if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
                    ignoreKeyPress = true;

                e.Handled = ignoreKeyPress;
                //using System.Text.RegularExpressions;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtContact_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
                else
                {
                    e.Handled = false;
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }
        public void validemail()
        {
            System.Text.RegularExpressions.Regex rEmail = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");

            if (txtEmail.Text.Length > 0 && txtEmail.Text.Trim().Length != 0)
            {
                if (!rEmail.IsMatch(txtEmail.Text.Trim()))
                {
                    lblEmailerrormsg.Visible = true;
                    lblEmailerrormsg.Text = "Invalid Email address";
                    txtEmail.SelectAll();
                    // e.Cancel = true;

                }
                else
                {
                    lblEmailerrormsg.Visible = false;
                }
            }
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            validemail();
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            validemail();
        }

        private void txtAge_Enter(object sender, EventArgs e)
        {
            try
            {
                string DT = dtDateOfBirth.Text;
                DateTime dob = Convert.ToDateTime(DT);
                string text = CalculateYourAge(dob);
                int age = CalculateAge(dob);
                txtAge.Text = age.ToString();
            }
            catch
            {

            }
        }

        private static int CalculateAge(DateTime dateOfBirth)
        {
            int age = 0;
            age = DateTime.Now.Year - dateOfBirth.Year;
            if (DateTime.Now.DayOfYear < dateOfBirth.DayOfYear)
                age = age - 1;

            return age;
        }

        static string CalculateYourAge(DateTime Dob)
        {
            DateTime Now = DateTime.Now;
            int Years = new DateTime(DateTime.Now.Subtract(Dob).Ticks).Year - 1;
            DateTime PastYearDate = Dob.AddYears(Years);
            int Months = 0;
            for (int i = 1; i <= 12; i++)
            {
                if (PastYearDate.AddMonths(i) == Now)
                {
                    Months = i;
                    break;
                }
                else if (PastYearDate.AddMonths(i) >= Now)
                {
                    Months = i - 1;
                    break;
                }
            }
            int Days = Now.Subtract(PastYearDate.AddMonths(Months)).Days;
            int Hours = Now.Subtract(PastYearDate).Hours;
            int Minutes = Now.Subtract(PastYearDate).Minutes;
            int Seconds = Now.Subtract(PastYearDate).Seconds;
            return String.Format("Age: {0} Year(s) {1} Month(s) {2} Day(s) {3} Hour(s) {4} Second(s)",
            Years, Months, Days, Hours, Seconds);
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bitmap, 0, 0);
        }

        Bitmap bitmap;
        private void CaptureScreen()
        {
            Graphics myGraphics = this.CreateGraphics();
            Size s = this.Size;
            bitmap = new Bitmap(s.Width, s.Height, myGraphics);
            Graphics memoryGraphics = Graphics.FromImage(bitmap);
            memoryGraphics.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, s);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            lblMSG.Visible = false;
            lblMSG.Refresh();

            lblCustomerID.Visible = false;
            lblCustomerID.Refresh();

            btnSave.Visible = false;
            btnSave.Refresh();

            btnPrint.Visible = false;
            btnPrint.Refresh();


            Panel panel = new Panel();
            this.Controls.Add(panel);
            Graphics grp = panel.CreateGraphics();
            Size formSize = this.ClientSize;
            bitmap = new Bitmap(formSize.Width, formSize.Height, grp);
            grp = Graphics.FromImage(bitmap);
            Point panelLocation = PointToScreen(panel.Location);           
            grp.CopyFromScreen(panelLocation.X, panelLocation.Y, 0, 0, formSize);
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.PrintPreviewControl.Zoom = 1;
            printPreviewDialog1.ShowDialog();


            lblMSG.Visible = true;
            lblMSG.Refresh();

            lblCustomerID.Visible = true;
            lblCustomerID.Refresh();

            btnSave.Visible = true;
            btnSave.Refresh();

            btnPrint.Visible = true;
            btnPrint.Refresh();

        }

        private void chkskinProblem_CheckedChanged(object sender, EventArgs e)
        {
            if (chkskinProblem.Checked == true)
            {
                txtSkinProblem.Enabled = true;
            }
            else
            {
                txtSkinProblem.Enabled = false;
            }
        }

        private void txtAnyCondition_KeyPress(object sender, KeyPressEventArgs e)
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
