using System;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace Erasmus
{
    public partial class Document : Form
    {
        public string server = "ftp://192.168.56.1/Exchange_Document";
        public string user_name = "PHAM HOANG";
        public string user_pass = "01101999hoang";
        public Document()
        {
            InitializeComponent();
        }

        private void проАвторToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.Show();
        }

        private void link1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try {
                
                string path = @"C:\Users\famsu\Desktop\Document_Erasmus\";
                string fileName = "Application_Form.docx";
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(server + "/" + fileName);
                request.Method = WebRequestMethods.Ftp.DownloadFile;
                request.Credentials = new NetworkCredential(user_name, user_pass);
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                using (Stream responseStream = response.GetResponseStream())
                {
                    using (Stream fileStream = new FileStream(path + fileName, FileMode.CreateNew))
                    {
                        responseStream.CopyTo(fileStream);
                    }
                }
                MessageBox.Show("Successful download file", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (WebException ex)
            {
                throw new Exception((ex.Response as FtpWebResponse).StatusDescription);
            }
        }

        private void link2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try {
                
                string path = @"C:\Users\famsu\Desktop\Document_Erasmus\";
                string fileName = "Learning_Agreement.docx";
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(server + "/" + fileName);
                request.Method = WebRequestMethods.Ftp.DownloadFile;
                request.Credentials = new NetworkCredential(user_name, user_pass);
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                using (Stream responseStream = response.GetResponseStream())
                {
                    using (Stream fileStream = new FileStream(path + fileName, FileMode.CreateNew))
                    {
                        responseStream.CopyTo(fileStream);
                    }
                }
                MessageBox.Show("Successful download file", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (WebException ex)
            {
                throw new Exception((ex.Response as FtpWebResponse).StatusDescription);
            }
        }

        private void link3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {

                string path = @"C:\Users\famsu\Desktop\Document_Erasmus\";
                string fileName = "application.jpg";
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(server + "/" + fileName);
                request.Method = WebRequestMethods.Ftp.DownloadFile;
                request.Credentials = new NetworkCredential(user_name, user_pass);
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                using (Stream responseStream = response.GetResponseStream())
                {
                    using (Stream fileStream = new FileStream(path + fileName, FileMode.CreateNew))
                    {
                        responseStream.CopyTo(fileStream);
                    }
                }
                MessageBox.Show("Successful download file", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (WebException ex)
            {
                throw new Exception((ex.Response as FtpWebResponse).StatusDescription);
            }
        }

        private void link4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {

                string path = @"C:\Users\famsu\Desktop\Document_Erasmus\";
                string fileName = "IPN.docx";
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(server + "/" + fileName);
                request.Method = WebRequestMethods.Ftp.DownloadFile;
                request.Credentials = new NetworkCredential(user_name, user_pass);
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                using (Stream responseStream = response.GetResponseStream())
                {
                    using (Stream fileStream = new FileStream(path + fileName, FileMode.CreateNew))
                    {
                        responseStream.CopyTo(fileStream);
                    }
                }
                MessageBox.Show("Successful download file", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (WebException ex)
            {
                throw new Exception((ex.Response as FtpWebResponse).StatusDescription);
            }
        }
    }
}
