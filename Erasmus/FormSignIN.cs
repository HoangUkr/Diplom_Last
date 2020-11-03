using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using LanMessengerLib;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using System.Threading;
using System.Net;

namespace Erasmus
{
    public partial class FormSignIN : Form
    {
        public FormSignIN()
        {
            InitializeComponent();
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text != "" && txtPassword.Text != "")
            {
                try
                {
                    if (Global.server.SignIn(txtUsername.Text, txtPassword.Text, !chkInvisible.Checked))
                    {
                        // Ghi địa chỉ IP của user đăng nhập
                        IPHostEntry temp = Dns.GetHostByName(Dns.GetHostName().ToString());
                        string IP = temp.AddressList[0].ToString();
                        Global.server.SetIP(txtUsername.Text, IP);
                    }
                    else
                    {
                        MessageBox.Show("Tên người dùng hoặc mật khẩu không đúng. Vui lòng kiểm tra lại!", "Lỗi đăng nhập...");
                        this.DialogResult = DialogResult.None;
                    }
                }
                catch
                {
                    MessageBox.Show("Lỗi kết nối tới Server. Vui lòng kiểm tra kết nối và thử lại!", "Lỗi kết nối...");
                    this.DialogResult = DialogResult.Cancel;
                }
            }
            else
            {
                MessageBox.Show("Lỗi! Vui lòng nhập tên tài khoản và mật khẩu!", "Lỗi đăng nhập...");
                this.DialogResult = DialogResult.None;
            }
        }

        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            FormCreateAccount frmCreateAccount = new FormCreateAccount();
            if (frmCreateAccount.ShowDialog() == DialogResult.OK)
            {
                txtUsername.Text = frmCreateAccount.txtUsername.Text;
                txtPassword.Text = frmCreateAccount.txtPassword.Text;
            }
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            FormChangePassword frmChangePassword = new FormChangePassword();
            frmChangePassword.txtUsername.Text = txtUsername.Text;
            frmChangePassword.txtCurPassword.Text = txtPassword.Text;
            if (frmChangePassword.ShowDialog() == DialogResult.OK)
            {
                txtUsername.Text = frmChangePassword.txtUsername.Text;
                txtPassword.Text = frmChangePassword.txtNewPassword.Text;
            }
        }

        private void FormSignIN_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.None)
            {
                e.Cancel = true;
            }
        }
    }
}
