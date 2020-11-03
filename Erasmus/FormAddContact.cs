using System;
using System.Windows.Forms;

namespace Erasmus
{
    public partial class FormAddContact : Form
    {
        private System.Windows.Forms.Label label1_1;
        private System.Windows.Forms.TextBox txtContact_1;
        private System.Windows.Forms.Button btnAdd_1;
        private System.Windows.Forms.Button btnCancel_1;
        private System.ComponentModel.Container components_1 = null;
        public FormAddContact()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (Global.username == txtContact.Text)
            {
                MessageBox.Show("You cant add yourself to list!");
                txtContact.Text = "";
                this.DialogResult = DialogResult.None;
                return;
            }
            if (Global.server.AddContact(Global.username, txtContact.Text))
            {
                return;
            }
            else
            {
                
                bool check = false;          
                foreach (object o in Global.server.GetContacts(Global.username))
                    if (o.ToString() == txtContact.Text)
                    {
                        check = true;
                        break;
                    }
                if (check) MessageBox.Show("This user is already in your list");
                else
                    MessageBox.Show("This user is not existing!");
                this.DialogResult = DialogResult.None;
            }
        }

        private void FormAddContact_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.None)
                e.Cancel = true;
        }
    }
}
