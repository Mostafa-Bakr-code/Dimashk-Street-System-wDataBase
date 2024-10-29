using BuisnessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms_PresentationLayer
{
    public partial class FormLogIn : Form
    {
        public FormLogIn()
        {
            InitializeComponent();
            ResetFields();
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            string idText = txtID.Text;
            string password = txtPassword.Text;

            
            int.TryParse(idText, out int id);
            
            bool isValid = clsUserBusiness.ValidateUserCredentials(id, password);

                if (isValid)
                {
               
                     clsUserBusiness user = clsUserBusiness.Find(id);

                    if (user != null)
                    {
                  
                        clsUserBusiness.SetActiveUser(user);

                        MessageBox.Show("تم تسجيل الدخول بنجاح");

                        FormMain frm = new FormMain();
                        frm.ShowDialog();

                        this.Hide(); 

                     
                        ResetFields();

                }


                 }

                else
                {
                    MessageBox.Show("برجاء ادخال رقم مستخدم صحيح وكلمة مرور صحيحه");
                }
         
        }

        private void ResetFields()
        {
            txtID.Text = string.Empty;
            txtPassword.Text = string.Empty;
        }



    }
}
