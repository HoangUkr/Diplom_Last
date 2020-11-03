using System;
using System.Windows.Forms;

using System.IO;

namespace Erasmus
{
    public partial class FormNetworkSetting : Form
    {
        public FormNetworkSetting()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            switch (MessageBox.Show("Are you sure?.", "Change setting?", MessageBoxButtons.YesNoCancel))
            {
                case DialogResult.Yes:
                    FileStream fs = new FileStream("NetSetting.Dat", FileMode.Create);
                    BinaryWriter bw = new BinaryWriter(fs);
                    bw.Write(txtIP.Text);
                    bw.Close();
                    fs.Close();
                    return;
                    break;
                case DialogResult.No:
                    this.DialogResult = DialogResult.None;
                    break;
                case DialogResult.Cancel:
                    this.DialogResult = DialogResult.Cancel;
                    break;
            }
        }

        private void FormNetworkSetting_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.None)
                e.Cancel = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
