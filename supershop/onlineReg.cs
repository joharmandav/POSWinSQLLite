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
    public partial class onlineReg : Form
    {
        public onlineReg()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {            

            string tenent =txttenent.Text.ToString();
            string username = txtuser.Text.ToString();
            string Password = txtPassword.Text.ToString();
            string CompnayName = txtCompany.Text.ToString();
            string CompnayNamearabic = txtcompnameArabic.Text.ToString();
            string CompnayNamefranch = txtcompnameFranch.Text.ToString();
            string defaultLanguage = txtdefaultlanguage.Text.ToString();
            string CompnayAddress = txtcompAddress.Text.ToString();
            string Compnayphone = txtCompPhone.Text.ToString();
            string Compnayweb = txtcompwebsite.Text.ToString();
            string userlastname = txtuserlastname.Text.ToString();
            string useraddress = txtuseraddress.Text.ToString();
            string userphone = txtuserphone.Text.ToString();
            string userBirth = txtuserbirth.Text.ToString();
            string userEmail = txtuserEmail.Text.ToString();
            string userType = txtuserType.Text.ToString();


            string enctenent = GlobleClass.EncryptionHelpers.Encrypt(tenent);
            string encusername = GlobleClass.EncryptionHelpers.Encrypt(username);
            string encPassword = GlobleClass.EncryptionHelpers.Encrypt(Password);
            string encCompnayName = GlobleClass.EncryptionHelpers.Encrypt(CompnayName);
            string encCompnayNamearabic = GlobleClass.EncryptionHelpers.Encrypt(CompnayNamearabic);
            string encCompnayNamefranch = GlobleClass.EncryptionHelpers.Encrypt(CompnayNamefranch);
            string encdefaultLanguage = GlobleClass.EncryptionHelpers.Encrypt(defaultLanguage);
            string encCompnayAddress = GlobleClass.EncryptionHelpers.Encrypt(CompnayAddress);
            string encCompnayphone = GlobleClass.EncryptionHelpers.Encrypt(Compnayphone);
            string encCompnayweb = GlobleClass.EncryptionHelpers.Encrypt(Compnayweb);
            string encuserlastname = GlobleClass.EncryptionHelpers.Encrypt(userlastname);
            string encuseraddress = GlobleClass.EncryptionHelpers.Encrypt(useraddress);
            string encuserphone = GlobleClass.EncryptionHelpers.Encrypt(userphone);
            string encuserBirth = GlobleClass.EncryptionHelpers.Encrypt(userBirth);
            string encuserEmail = GlobleClass.EncryptionHelpers.Encrypt(userEmail);
            string encuserType = GlobleClass.EncryptionHelpers.Encrypt(userType);


            erp53.com.WinRegistration reg = new erp53.com.WinRegistration();

            bool flag = reg.WinReg(enctenent, encusername, encPassword,encCompnayName,encCompnayNamearabic,encCompnayNamefranch,encdefaultLanguage,encCompnayAddress,encCompnayphone,encCompnayweb,encuserlastname,encuseraddress,encuserphone,encuserBirth,encuserEmail,encuserType);

            if(flag == true)
            {
                MessageBox.Show("Success", "Not match", MessageBoxButtons.OK, MessageBoxIcon.Warning);                
            }
            else
            {
                MessageBox.Show("Fali", "Not match", MessageBoxButtons.OK, MessageBoxIcon.Warning);                
            }

        }

     

    }
}
