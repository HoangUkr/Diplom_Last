using System;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.IO;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Erasmus
{
    public partial class Professor : Form
    {
        string username;
        string role;
        string faculty_2;
        int id;
        public string server = "ftp://192.168.56.1/Application";
        SqlConnection connection = new SqlConnection(connectionString);
        public string user_name = "PHAM HOANG";
        public string user_pass = "01101999hoang";
        static string connectionString = "Data Source =.\\SQLEXPRESS;Initial Catalog = Public; Integrated Security = True;";

        public Professor(int id, string username, string faculty, string role)
        {
            InitializeComponent();
            this.username = username;
            this.faculty_2 = faculty;
            this.role = role;
            this.id = id;
        }

        public void Loading()
        {
            string query = "select Users.username, Doument.application, Doument.inp from Doument inner join Users on Doument.id_sudent = Users.id ";
            SqlCommand command1 = new SqlCommand(query, connection);
            connection.Open();
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter(command1);
            da1.Fill(dt1);
            document_down.DataSource = dt1;
            connection.Close();

            string query1 = "select Users.username, Doument.application, Doument.inp from Doument inner join Users on Doument.id_sudent = Users.id ";
            SqlCommand command2 = new SqlCommand(query, connection);
            connection.Open();
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter(command2);
            da2.Fill(dt1);
            document_upl.DataSource = dt2;
            connection.Close();
        }
        public void UploadFile()
        {
            string FullName1 = this.zayava.Text;
            string FullName2 = this.inp.Text;
            FileInfo toUpload1 = new FileInfo(FullName1);
            FileInfo toUpload2 = new FileInfo(FullName2);
            FtpWebRequest request1 = (FtpWebRequest)WebRequest.Create(server + "/" + toUpload1.Name);
            request1.Method = WebRequestMethods.Ftp.UploadFile;
            request1.Credentials = new NetworkCredential("PHAM HOANG", "01101999hoang");
            Stream stream1 = request1.GetRequestStream();
            FileStream fs1 = File.OpenRead(FullName1);
            byte[] buffer1 = new byte[1024];
            double total1 = (double)fs1.Length;
            int byteRead1 = 0;
            //double read = 0;
            do
            {
                byteRead1 = fs1.Read(buffer1, 0, 1024);
                stream1.Write(buffer1, 0, byteRead1);
                //read += (double)byteRead;

            } while (byteRead1 != 0);
            fs1.Close();
            stream1.Close();
            //================Upload Certificate=================//
            FtpWebRequest request2 = (FtpWebRequest)WebRequest.Create(server + "/" + toUpload2.Name);
            request2.Method = WebRequestMethods.Ftp.UploadFile;
            request2.Credentials = new NetworkCredential("PHAM HOANG", "01101999hoang");
            Stream stream2 = request2.GetRequestStream();
            FileStream fs2 = File.OpenRead(FullName2);
            byte[] buffer2 = new byte[1024];
            double total2 = (double)fs2.Length;
            int byteRead2 = 0;
            do
            {
                byteRead2 = fs2.Read(buffer2, 0, 1024);
                stream2.Write(buffer2, 0, byteRead2);
                //read += (double)byteRead;

            } while (byteRead2 != 0);
            fs2.Close();
            stream2.Close();

        }
        public void Sending()
        {
            string participant = this.name.Text;
            uint index; 
            for (int i = 0; i < document_upl.RowCount - 1; i++)
            {
                if (participant == document_upl.Rows[i].Cells[1].Value.ToString())
                {
                    document_upl.Rows[i].Cells[1].Value = zayava.Text;
                    document_upl.Rows[i].Cells[2].Value = inp.Text;
                    index = Convert.ToUInt32(document_upl.Rows[i].Cells[0].Value.ToString());
                    string query = @"update Doument set application ='" + zayava.Text + "', inp = '" + inp.Text + "' where id_student = '" + index + "'";
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        using (SqlCommand command = new SqlCommand())
                        {
                            command.Connection = connection;
                            connection.Open();
                            command.CommandText = query;
                            command.ExecuteNonQuery();
                        }
                    }
                }
            }
            MessageBox.Show("Successful edit", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void Professor_Load(object sender, EventArgs e)
        {
            username_1.Text = username;
            role_1.Text = role;
            faculty_1.Text = faculty_2;
            Loading();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void download_Click(object sender, EventArgs e)
        {
            List<int> list_ind = new List<int>() { 1,  2 };
            string path = @"C:\Users\famsu\Desktop\";
            string folder;

            for (int i = 1; i < document_down.RowCount; i++)
            {
                folder = document_down.Rows[i].Cells[0].Value.ToString();
                System.IO.Directory.CreateDirectory(path + folder);
                foreach (int j in list_ind)
                {
                    string fileName = document_down.Rows[i].Cells[j].Value.ToString();
                    Download(folder, fileName);

                }
            }
            MessageBox.Show("Successful download!", "Information", MessageBoxButtons.OK);
        }
        public void Download(string folder, string fileName)
        {
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(server + "/" + fileName);
                request.Method = WebRequestMethods.Ftp.DownloadFile;
                request.Credentials = new NetworkCredential(user_name, user_pass);
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                string folder_1 = folder + @"\";
                string path = @"C:\Users\famsu\Desktop\" + folder_1;
                using (Stream responseStream = response.GetResponseStream())
                {
                    using (Stream fileStream = new FileStream(path + fileName, FileMode.CreateNew))
                    {
                        responseStream.CopyTo(fileStream);
                    }
                }
            }
            catch (WebException ex)
            {
                throw new Exception((ex.Response as FtpWebResponse).StatusDescription);
            }

        }
        private void zayava_browse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog() { Multiselect = false, ValidateNames = true, Filter = "Document files (*.doc, *.docx, *.txt, *pdf) | *.doc; *.docx; *.txt; *.pdf" })
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filename = openFileDialog.FileName;
                    zayava.Text = filename;

                }
            }
        }

        private void inp_browse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog() { Multiselect = false, ValidateNames = true, Filter = "Document files (*.doc, *.docx, *.txt, *pdf) | *.doc; *.docx; *.txt; *.pdf" })
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filename = openFileDialog.FileName;
                    inp.Text = filename;

                }
            }
        }

        private void upload_Click(object sender, EventArgs e)
        {
            UploadFile();
            Sending();
        }
    }
}
