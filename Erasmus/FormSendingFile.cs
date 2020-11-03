using System;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.IO;

namespace Erasmus
{
    public partial class FormSendingFile : Form
    {
        public static string IP;
        string splitter = "'\\'";
        string fName;
        string[] split = null;
        byte[] clientData;
        FormMessage f;
        public FormSendingFile()
        {
            InitializeComponent();   
        }
        public FormSendingFile(FormMessage form)
        {
            InitializeComponent();
            f = new FormMessage();
            f = form;
        }
        
        private void btnSend_Click(object sender, EventArgs e)
        {
            Socket clientSock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            byte[] fileName = Encoding.UTF8.GetBytes(fName);
            byte[] fileData = File.ReadAllBytes(txtFileLink.Text);
            byte[] fileNameLen = BitConverter.GetBytes(fileName.Length); 
            clientData = new byte[4 + fileName.Length + fileData.Length];
            fileNameLen.CopyTo(clientData, 0);
            fileName.CopyTo(clientData, 4);
            fileData.CopyTo(clientData, 4 + fileName.Length);
            lblStatus.Text = "Connecting to receiver...";
            clientSock.Connect(IP, 6565);
            lblStatus.Text = "Sending...";
            clientSock.Send(clientData);
            clientSock.Close();
            lblStatus.Text = "Sending successful: " + Path.GetFileName(txtFileLink.Text);
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            char[] delimiter = splitter.ToCharArray();
            openFileDialog1.ShowDialog();
            txtFileLink.Text = openFileDialog1.FileName;
            split = txtFileLink.Text.Split(delimiter);
            int limit = split.Length;
            fName = split[limit - 1].ToString();
            if (txtFileLink.Text != null)
                btnSend.Enabled = true;
        }
        private void FormSendingFile_Load(object sender, EventArgs e)
        {
            IP = f.IPContact;
        }
    }
}
