using System;
using System.Windows.Forms;
using System.Net;

namespace Erasmus
{
    public partial class FormCreateAccount : Form
    {
        public FormCreateAccount()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text == txtConfirm.Text)
            {
                try
                {
                    IPHostEntry temp = Dns.GetHostByName(Dns.GetHostName().ToString());
                    string IP = temp.AddressList[0].ToString();
                    if (Global.server.SignUp(txtUsername.Text, txtPassword.Text, txtDisplayName.Text, IP))
                    {
                        MessageBox.Show("Successful created.", "Create account...");
                    }
                    else
                    {
                        MessageBox.Show("Account already exist.", "Account error...");
                        this.DialogResult = DialogResult.None;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                    
                }
            }
            else
            {
                MessageBox.Show("Password is not matched!", "Error...");
                this.DialogResult = DialogResult.None;
            }
        }

        private void FormCreateAccount_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.None)
            {
                e.Cancel = true;
            }
        }
    }
}
