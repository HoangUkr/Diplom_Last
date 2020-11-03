using System;
using System.Windows.Forms;

namespace Erasmus
{
    public partial class FormChangePassword : Form
    {
        public FormChangePassword()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.txtNewPassword.Text == txtConfirmPassword.Text)
            {
                try
                {
                    if (Global.server.ChangePassword(txtUsername.Text, txtCurPassword.Text, txtNewPassword.Text))
                    {
                        MessageBox.Show("Successful changed!");
                    }
                    else
                    {
                        MessageBox.Show("Wrong. Check it again!");
                        this.DialogResult = DialogResult.None;
                    }
                }
                catch
                {
                    MessageBox.Show("Connect error. Check it again!");
                }
            }
            else
            {
                MessageBox.Show("Retype password is not matched!");
                this.DialogResult = DialogResult.None;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormChangePassword_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.None)
            {
                e.Cancel = true;
            }
        }
    }
}
