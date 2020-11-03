using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Net;

namespace Erasmus
{
    public partial class User_Form : Form
    {
        string faculty_2;
        string username;
        string year;
        string role;
        int id;
        public string server = "ftp://192.168.56.1/Application";
        public string user_name = "PHAM HOANG";
        public string user_pass = "01101999hoang";
        private static string connectionString = "Data Source=.\\sqlexpress;Initial Catalog=Public;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        //SqlConnection connection = new SqlConnection(connectionString);
        public User_Form(int id, string username, string faculty, string year, string role)
        {
            InitializeComponent();
            this.username = username;
            this.faculty_2 = faculty;
            this.year = year;
            this.role = role;
            this.id = id;
        }

        private void проАвторуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.Show();
        }

        private void User_Form_Load(object sender, EventArgs e)
        {
            username_1.Text = username;
            year_1.Text = year;
            role_1.Text = role;
            faculty_1.Text = faculty_2;
        }

        private void вихідToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void apply_document()
        {
            int publication_available = 0;
            int competition_available = 0;

            double average_score = Convert.ToDouble(average.Text);

            int exchangeid_1 = partner_1.SelectedIndex + 1;
            int exchangeid_2 = partner_2.SelectedIndex + 1;

            string fileName = Path.GetFileName(passport_scan.Text);
            string fileName6 = Path.GetFileName(avatar.Text);
            string fileName1 = Path.GetFileName(average_scan.Text);
            string fileName2 = Path.GetFileName(certificate_file.Text);
            string fileName3 = Path.GetFileName(publication_path.Text);
            string fileName4 = Path.GetFileName(competition_file.Text);
            string fileName5 = Path.GetFileName(learning_file.Text);

            if (publication_yes.Checked)
            {
                publication_available = 1;
                publication_path.Enabled = true;
                browse_publication.Enabled = true;
            }
            else
            {
                publication_available = 0;
                publication_path.Enabled = false;
                browse_publication.Enabled = false;

            }
            if (competition_yes.Checked)
            {
                competition_available = 1;
                competition_file.Enabled = true;
                browse_competition.Enabled = true;
            }
            else
            {
                competition_available = 0;
                competition_file.Enabled = false;
                browse_competition.Enabled = false;
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO App_Docs VALUES(@id_student, @id_program, @passport_number, @passport_scan, @average_score, @average_scan, @english_skill, " +
                                "@type_certificate, @certificate_scan, @publication_avail, @publication_file, @competition_avail, @competition_file, " +
                                "@learning_agreement_file, @email, @avatar, @publication_score, @competition_score, @rating)";

                string query1 = "INSERT INTO App_Docs VALUES(@id_student, @id_program, @passport_number, @passport_scan, @average_score, @average_scan, @english_skill, " +
                                "@type_certificate, @certificate_scan, @publication_avail, @publication_file, @competition_avail, @competition_file, " +
                                "@learning_agreement_file, @email, @avatar, @publication_score, @competition_score, @rating)";
                using (SqlCommand queryInsert = new SqlCommand(query))
                {
                    queryInsert.Connection = connection;
                    queryInsert.Parameters.Add("@id_student", SqlDbType.Int).Value = id;
                    queryInsert.Parameters.Add("@id_program", SqlDbType.Int).Value = exchangeid_1;

                    queryInsert.Parameters.Add("@passport_number", SqlDbType.NChar, 20).Value = series_pas.Text;
                    queryInsert.Parameters.Add("@passport_scan", SqlDbType.NChar, 100).Value = fileName;

                    queryInsert.Parameters.Add("@average_score", SqlDbType.Float).Value = average_score;
                    queryInsert.Parameters.Add("@average_scan", SqlDbType.NChar, 100).Value = fileName1;

                    queryInsert.Parameters.Add("@english_skill", SqlDbType.NChar, 10).Value = language.Text;
                    queryInsert.Parameters.Add("@type_certificate", SqlDbType.NChar, 10).Value = certificate.Text;
                    queryInsert.Parameters.Add("@certificate_scan", SqlDbType.NChar, 100).Value = fileName2;

                    queryInsert.Parameters.Add("@publication_avail", SqlDbType.Int).Value = publication_available;
                    queryInsert.Parameters.Add("@publication_file", SqlDbType.NVarChar, 100).Value = fileName3;

                    queryInsert.Parameters.Add("@competition_avail", SqlDbType.Int).Value = competition_available;
                    queryInsert.Parameters.Add("@competition_file", SqlDbType.NVarChar, 100).Value = fileName4;

                    queryInsert.Parameters.Add("@learning_agreement_file", SqlDbType.NChar, 100).Value = fileName5;
                    queryInsert.Parameters.Add("@email", SqlDbType.VarChar, 100).Value = email.Text;
                    queryInsert.Parameters.Add("@avatar", SqlDbType.VarChar, 100).Value = fileName6;

                    queryInsert.Parameters.Add("@publication_score", SqlDbType.Int).Value = null;
                    queryInsert.Parameters.Add("@competition_score", SqlDbType.Int).Value = null;
                    queryInsert.Parameters.Add("@rating", SqlDbType.Float).Value = null;

                    try
                    {
                        connection.Open();
                        queryInsert.ExecuteNonQuery();
                        connection.Close();
                        
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
                using (SqlCommand queryInsert1 = new SqlCommand(query1))
                {
                    queryInsert1.Connection = connection;
                    queryInsert1.Parameters.Add("@id_student", SqlDbType.Int).Value = id;
                    queryInsert1.Parameters.Add("@id_program", SqlDbType.Int).Value = exchangeid_2;

                    queryInsert1.Parameters.Add("@passport_number", SqlDbType.NChar, 20).Value = series_pas.Text;
                    queryInsert1.Parameters.Add("@passport_scan", SqlDbType.NChar, 100).Value = fileName;

                    queryInsert1.Parameters.Add("@average_score", SqlDbType.Float).Value = average_score;
                    queryInsert1.Parameters.Add("@average_scan", SqlDbType.NChar, 100).Value = fileName1;

                    queryInsert1.Parameters.Add("@english_skill", SqlDbType.NChar, 10).Value = language.Text;
                    queryInsert1.Parameters.Add("@type_certificate", SqlDbType.NChar, 10).Value = certificate.Text;
                    queryInsert1.Parameters.Add("@certificate_scan", SqlDbType.NChar, 100).Value = fileName2;

                    queryInsert1.Parameters.Add("@publication_avail", SqlDbType.Int).Value = publication_available;
                    queryInsert1.Parameters.Add("@publication_file", SqlDbType.NVarChar, 100).Value = fileName3;

                    queryInsert1.Parameters.Add("@competition_avail", SqlDbType.Int).Value = competition_available;
                    queryInsert1.Parameters.Add("@competition_file", SqlDbType.NVarChar, 100).Value = fileName4;

                    queryInsert1.Parameters.Add("@learning_agreement_file", SqlDbType.NChar, 100).Value = fileName5;
                    queryInsert1.Parameters.Add("@email", SqlDbType.VarChar, 100).Value = email.Text;
                    queryInsert1.Parameters.Add("@avatar", SqlDbType.VarChar, 100).Value = fileName6;

                    queryInsert1.Parameters.Add("@publication_score", SqlDbType.Int).Value = null;
                    queryInsert1.Parameters.Add("@competition_score", SqlDbType.Int).Value = null;
                    queryInsert1.Parameters.Add("@rating", SqlDbType.Float).Value = null;
                    try
                    {
                        connection.Open();
                        queryInsert1.ExecuteNonQuery();
                        //DialogResult result = MessageBox.Show("Успішно зареєстрував", "Повідомлення", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        connection.Close();
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }
    
        public void UpLoadFile()
        {
            string FullName = this.passport_scan.Text;
            string FullName1 = this.average_scan.Text;
            string FullName2 = this.certificate_file.Text;
            string FullName3 = this.publication_path.Text;
            string FullName4 = this.competition_file.Text;
            string FullName5 = this.learning_file.Text;
            string FullName6 = this.avatar.Text;
            
            FileInfo toUpload = new FileInfo(FullName);
            FileInfo toUpload1 = new FileInfo(FullName1);
            FileInfo toUpload2 = new FileInfo(FullName2);
            FileInfo toUpload3 = new FileInfo(FullName3);
            FileInfo toUpload4 = new FileInfo(FullName4);
            FileInfo toUpload5 = new FileInfo(FullName5);
            FileInfo toUpload6 = new FileInfo(FullName6);

            //================Upload passport scan=================//
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(server + "/" + toUpload.Name);
            request.Method = WebRequestMethods.Ftp.UploadFile;
            request.Credentials = new NetworkCredential("PHAM HOANG", "01101999hoang");
            Stream stream = request.GetRequestStream();
            FileStream fs = File.OpenRead(FullName);
            byte[] buffer = new byte[1024];
            double total = (double)fs.Length;
            int byteRead = 0;
            //double read = 0;
            do
            {
                byteRead = fs.Read(buffer, 0, 1024);
                stream.Write(buffer, 0, byteRead);
                //read += (double)byteRead;

            } while (byteRead != 0);
            fs.Close();
            stream.Close();
            //================Upload Average Score=================//
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
            //================Upload Publication=================//
            FtpWebRequest request3 = (FtpWebRequest)WebRequest.Create(server + "/" + toUpload3.Name);
            request3.Method = WebRequestMethods.Ftp.UploadFile;
            request3.Credentials = new NetworkCredential("PHAM HOANG", "01101999hoang");
            Stream stream3 = request3.GetRequestStream();
            FileStream fs3 = File.OpenRead(FullName3);
            byte[] buffer3 = new byte[1024];
            double total3 = (double)fs3.Length;
            int byteRead3 = 0;
            do
            {
                byteRead3 = fs3.Read(buffer3, 0, 1024);
                stream3.Write(buffer3, 0, byteRead3);
                //read += (double)byteRead;

            } while (byteRead3 != 0);
            fs3.Close();
            stream3.Close();
            //================Upload Competition=================//
            FtpWebRequest request4 = (FtpWebRequest)WebRequest.Create(server + "/" + toUpload4.Name);
            request4.Method = WebRequestMethods.Ftp.UploadFile;
            request4.Credentials = new NetworkCredential("PHAM HOANG", "01101999hoang");
            Stream stream4 = request4.GetRequestStream();
            FileStream fs4 = File.OpenRead(FullName4);
            byte[] buffer4 = new byte[1024];
            double total4 = (double)fs4.Length;
            int byteRead4 = 0;
            do
            {
                byteRead4 = fs4.Read(buffer4, 0, 1024);
                stream4.Write(buffer4, 0, byteRead4);
                //read += (double)byteRead;

            } while (byteRead4 != 0);
            fs4.Close();
            stream4.Close();
            //================Upload Learning Agreement=================//
            FtpWebRequest request5 = (FtpWebRequest)WebRequest.Create(server + "/" + toUpload5.Name);
            request5.Method = WebRequestMethods.Ftp.UploadFile;
            request5.Credentials = new NetworkCredential("PHAM HOANG", "01101999hoang");
            Stream stream5 = request5.GetRequestStream();
            FileStream fs5 = File.OpenRead(FullName5);
            byte[] buffer5 = new byte[1024];
            double total5 = (double)fs5.Length;
            int byteRead5 = 0;
            do
            {
                byteRead5 = fs5.Read(buffer5, 0, 1024);
                stream5.Write(buffer5, 0, byteRead5);
                //read += (double)byteRead;

            } while (byteRead5 != 0);
            fs5.Close();
            stream5.Close();
            //================Upload Learning Agreement=================//
            FtpWebRequest request6 = (FtpWebRequest)WebRequest.Create(server + "/" + toUpload6.Name);
            request6.Method = WebRequestMethods.Ftp.UploadFile;
            request6.Credentials = new NetworkCredential("PHAM HOANG", "01101999hoang");
            Stream stream6 = request6.GetRequestStream();
            FileStream fs6 = File.OpenRead(FullName6);
            byte[] buffer6 = new byte[1024];
            double total6 = (double)fs6.Length;
            int byteRead6 = 0;
            do
            {
                byteRead6 = fs6.Read(buffer6, 0, 1024);
                stream6.Write(buffer6, 0, byteRead6);
                //read += (double)byteRead;

            } while (byteRead6 != 0);
            fs6.Close();
            stream6.Close();
        }

        private void apply_Click(object sender, EventArgs e)
        {
            UpLoadFile();
            apply_document();
            DialogResult result = MessageBox.Show("Успішно зареєстрував", "Повідомлення", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if(result == DialogResult.OK)
            {
                avatar.Text = "";
                series_pas.Text = "";
                passport_scan.Text = "";
                email.Text = "";
                average.Text = "";
                average_scan.Text = "";
                partner_1.Text = "";
                partner_2.Text = "";
                language.Text = "";
                certificate_file.Text = "";
                certificate.Text = "";
                publication_path.Text = "";
                competition_file.Text = "";
                learning_file.Text = "";
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void browse_certificate_Click(object sender, EventArgs e)
        {
            //FileInfo file;
            using (OpenFileDialog openFileDialog = new OpenFileDialog() { Multiselect = false, ValidateNames = true, Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png" })
            {
                if(openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filename = openFileDialog.FileName;
                    certificate_file.Text = filename;
                   
                }
            }
        }

        private void browse_publication_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog() { Multiselect = false, ValidateNames = true, Filter = "Document files (*.doc, *.docx, *.txt, *pdf) | *.doc; *.docx; *.txt; *.pdf" })
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filename = openFileDialog.FileName;
                    publication_path.Text = filename;
                }
            }
        }

        private void browse_competition_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog() { Multiselect = false, ValidateNames = true, Filter = "Document files (*.doc, *.docx, *.txt, *pdf) | *.doc; *.docx; *.txt; *.pdf" })
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filename = openFileDialog.FileName;
                    competition_file.Text = filename;

                }
            }
        }

        private void learning_browse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog() { Multiselect = false, ValidateNames = true, Filter = "All files|*.*" })
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filename = openFileDialog.FileName;
                    learning_file.Text = filename;
                }
            }
        }

        private void average_browse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog() { Multiselect = false, ValidateNames = true, Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png" })
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filename = openFileDialog.FileName;
                    average_scan.Text = filename;
                }
            }
        }

        private void browse_passport_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog() { Multiselect = false, ValidateNames = true, Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png"})
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filename = openFileDialog.FileName;
                    passport_scan.Text = filename;
                }
            }
        }

        private void avatar_browse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog() { Multiselect = false, ValidateNames = true, Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png" })
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filename = openFileDialog.FileName;
                    avatar.Text = filename;
                }
            }
        }

        private void zayava_browse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog() { Multiselect = false, ValidateNames = true, Filter = "Document files (*.doc, *.docx, *.txt, *pdf) | *.doc; *.docx; *.txt; *.pdf" })
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filename = openFileDialog.FileName;
                    competition_file.Text = filename;

                }
            }
        }

        private void invitation_browse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog() { Multiselect = false, ValidateNames = true, Filter = "Document files (*.doc, *.docx, *.txt, *pdf) | *.doc; *.docx; *.txt; *.pdf" })
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filename = openFileDialog.FileName;
                    competition_file.Text = filename;

                }
            }
        }

        private void invitation_trans_browse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog() { Multiselect = false, ValidateNames = true, Filter = "Document files (*.doc, *.docx, *.txt, *pdf) | *.doc; *.docx; *.txt; *.pdf" })
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filename = openFileDialog.FileName;
                    competition_file.Text = filename;

                }
            }
        }

        private void contract_browse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog() { Multiselect = false, ValidateNames = true, Filter = "Document files (*.doc, *.docx, *.txt, *pdf) | *.doc; *.docx; *.txt; *.pdf" })
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filename = openFileDialog.FileName;
                    competition_file.Text = filename;

                }
            }
        }

        private void apply_1_Click(object sender, EventArgs e)
        {
            UploadFile_1();
            Apply_1_etap();
            DialogResult result = MessageBox.Show("Успішно подав документи", "Повідомлення", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (result == DialogResult.OK)
            {
                zayava.Text = "";
                invitation.Text = "";
                invitation_trans.Text = "";
                contract.Text = "";
            }
        }
        public void Apply_1_etap()
        {
            string fileName1 = Path.GetFileName(zayava.Text);
            string fileName2 = Path.GetFileName(invitation.Text);
            string fileName3 = Path.GetFileName(invitation_trans.Text);
            string fileName4 = Path.GetFileName(contract.Text);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Doument VALUES(@id_student, @application, @invitation, @invitation_trans, @contract)";
                using (SqlCommand queryInsert = new SqlCommand(query))
                {
                    queryInsert.Connection = connection;
                    queryInsert.Parameters.Add("@id_student", SqlDbType.Int).Value = id;

                    queryInsert.Parameters.Add("@application", SqlDbType.VarChar, 100).Value = fileName1;
                    queryInsert.Parameters.Add("@invitation", SqlDbType.VarChar, 100).Value = fileName2;

                    queryInsert.Parameters.Add("@invitation_trans", SqlDbType.VarChar, 100).Value = fileName3;
                    queryInsert.Parameters.Add("@contract", SqlDbType.VarChar, 100).Value = fileName4;
                }
            }

        }
        public void UploadFile_1()
        {
            string FullName = this.zayava.Text;
            string FullName1 = this.invitation.Text;
            string FullName2 = this.invitation_trans.Text;
            string FullName3 = this.contract.Text;


            FileInfo toUpload = new FileInfo(FullName);
            FileInfo toUpload1 = new FileInfo(FullName1);
            FileInfo toUpload2 = new FileInfo(FullName2);
            FileInfo toUpload3 = new FileInfo(FullName3);

            //================Upload passport scan=================//
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(server + "/" + toUpload.Name);
            request.Method = WebRequestMethods.Ftp.UploadFile;
            request.Credentials = new NetworkCredential("PHAM HOANG", "01101999hoang");
            Stream stream = request.GetRequestStream();
            FileStream fs = File.OpenRead(FullName);
            byte[] buffer = new byte[1024];
            double total = (double)fs.Length;
            int byteRead = 0;
            //double read = 0;
            do
            {
                byteRead = fs.Read(buffer, 0, 1024);
                stream.Write(buffer, 0, byteRead);
                //read += (double)byteRead;

            } while (byteRead != 0);
            fs.Close();
            stream.Close();
            //================Upload Average Score=================//
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
            //================Upload Publication=================//
            FtpWebRequest request3 = (FtpWebRequest)WebRequest.Create(server + "/" + toUpload3.Name);
            request3.Method = WebRequestMethods.Ftp.UploadFile;
            request3.Credentials = new NetworkCredential("PHAM HOANG", "01101999hoang");
            Stream stream3 = request3.GetRequestStream();
            FileStream fs3 = File.OpenRead(FullName3);
            byte[] buffer3 = new byte[1024];
            double total3 = (double)fs3.Length;
            int byteRead3 = 0;
            do
            {
                byteRead3 = fs3.Read(buffer3, 0, 1024);
                stream3.Write(buffer3, 0, byteRead3);
                //read += (double)byteRead;

            } while (byteRead3 != 0);
            fs3.Close();
            stream3.Close();
        }

        private void ipn_browse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog() { Multiselect = false, ValidateNames = true, Filter = "Document files (*.doc, *.docx, *.txt, *pdf) | *.doc; *.docx; *.txt; *.pdf" })
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filename = openFileDialog.FileName;
                    competition_file.Text = filename;

                }
            }
        }

        private void nakaz_browse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog() { Multiselect = false, ValidateNames = true, Filter = "Document files (*.doc, *.docx, *.txt, *pdf) | *.doc; *.docx; *.txt; *.pdf" })
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filename = openFileDialog.FileName;
                    competition_file.Text = filename;

                }
            }
        }

        public void UploadFile_2()
        {
            string FullName = this.ipn.Text;
            string FullName1 = this.nakaz.Text;

            FileInfo toUpload = new FileInfo(FullName);
            FileInfo toUpload1 = new FileInfo(FullName1);

            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(server + "/" + toUpload.Name);
            request.Method = WebRequestMethods.Ftp.UploadFile;
            request.Credentials = new NetworkCredential("PHAM HOANG", "01101999hoang");
            Stream stream = request.GetRequestStream();
            FileStream fs = File.OpenRead(FullName);
            byte[] buffer = new byte[1024];
            double total = (double)fs.Length;
            int byteRead = 0;
            //double read = 0;
            do
            {
                byteRead = fs.Read(buffer, 0, 1024);
                stream.Write(buffer, 0, byteRead);
                //read += (double)byteRead;

            } while (byteRead != 0);
            fs.Close();
            stream.Close();
            //================Upload Average Score=================//
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
        }
        public void Apply_2_etap()
        {
            string fileName1 = Path.GetFileName(ipn.Text);
            string fileName2 = Path.GetFileName(nakaz.Text);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Doument VALUES(@inp, @nakaz)";
                using (SqlCommand queryInsert = new SqlCommand(query))
                {
                    queryInsert.Connection = connection;

                    queryInsert.Parameters.Add("@inp", SqlDbType.VarChar, 100).Value = fileName1;
                    queryInsert.Parameters.Add("@nakaz", SqlDbType.VarChar, 100).Value = fileName2;
                }
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            UploadFile_2();
            Apply_2_etap();
            DialogResult result = MessageBox.Show("Успішно подав документи", "Повідомлення", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (result == DialogResult.OK)
            {
                ipn.Text = "";
                nakaz.Text = "";

            }
        }
    }
}
