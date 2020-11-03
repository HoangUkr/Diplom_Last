using System;
using System.Windows.Forms;

namespace Erasmus
{
    public partial class ChangeDisplayName : Form
    {
        public ChangeDisplayName()
        {
            InitializeComponent();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "")
                MessageBox.Show("Empty text box", "Error!");
            else
            {
                Global.server.ChangeDisplayName(Global.username, txtName.Text);
                MessageBox.Show("Successful changed");
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ChangeDisplayName_Load(object sender, EventArgs e)
        {
            lblusername.Text += Global.username;
        }
    }
}
