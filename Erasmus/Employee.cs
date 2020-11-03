using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net;
using System.IO;

namespace Erasmus
{
    public partial class Employee : Form
    {
        //string faculty_2;
        string username;
        string role;
        int id;
        public string server = "ftp://192.168.56.1/Application";
        SqlConnection connection = new SqlConnection(connectionString);
        public string user_name = "PHAM HOANG";
        public string user_pass = "01101999hoang";
        static string connectionString = "Data Source =.\\SQLEXPRESS;Initial Catalog = Public; Integrated Security = True;";
        
        public Employee(int id, string username, string role)
        {
            InitializeComponent();
            this.username = username;
            this.role = role;
            this.id = id;
        }

        private void проАвтораToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.Show();
        }

        private void Employee_Load(object sender, EventArgs e)
        {
            //SqlConnection connection = new SqlConnection(connectionString);
            username_1.Text = username;
            role_1.Text = role;
            string query = "select Users.username, Exchange.program, a.passport_number, a.passport_scan, a.average_score, a.average_score_scan, " +
                "a.english_skill, a.type_certificate, a.certificate_scan, " +
                "publication_file, a.competition_file, a.learning_agreement_file, a.avatar " +
                "from App_Docs as a inner join Users " +
                "on a.id_student = Users.id inner join Exchange " +
                "on a.id_program = Exchange.id";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(dt);
            list.DataSource = dt;
            connection.Close();
            SqlConnection connection1 = new SqlConnection(connectionString);
            string query1 = "select App_Docs.id_student, Users.username, Exchange.program, App_Docs.average_score, App_Docs.english_skill, App_Docs.type_certificate," +
                " App_Docs.publication_score, App_Docs.competition_score, App_Docs.rating" +
                " from App_Docs" +
                " inner join Users" +
                " on App_Docs.id_student = Users.id" +
                " inner join Exchange" +
                " on App_Docs.id_program = Exchange.id";
            SqlCommand command1 = new SqlCommand(query1, connection1);
            connection1.Open();
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter(command1);
            da1.Fill(dt1);
            listing.DataSource = dt1;
            connection1.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string partner = "";
            partner = partner_1.Text;
            string query = "select Users.username, Exchange.program, App_Docs.email from App_Docs" +
                            " inner join Users" +
                            " on App_Docs.id_student = Users.id" +
                            " inner join Exchange" +
                            " on App_Docs.id_program = Exchange.id where Exchange.program = '"+partner+"'";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(dt);
            list.DataSource = dt;
            connection.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void download_Click(object sender, EventArgs e)
        {
            List<int> list_ind = new List<int>() {3, 5, 8, 9, 10, 11, 12};
            string path = @"C:\Users\famsu\Desktop\";
            string folder;
            
            for (int i = 1; i < list.RowCount; i = i + 2)
            {
                folder = list.Rows[i].Cells[0].Value.ToString();
                System.IO.Directory.CreateDirectory(path + folder);
                foreach (int j in list_ind)
                {
                    string fileName = list.Rows[i].Cells[j].Value.ToString();
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
            }catch(WebException ex)
            {
                throw new Exception((ex.Response as FtpWebResponse).StatusDescription);
            }

        }

        private void insert_Click(object sender, EventArgs e)
        {
            string participant = this.participant.Text;
            int publication_score = Convert.ToInt32(pub_score.Text);
            int competition_score = Convert.ToInt32(comp_score.Text);
            int coef = 0;
            int english = 0;
            for (int i = 0; i < listing.RowCount-1; i++)
            {
                if(listing.Rows[i].Cells[4].Value.ToString() == "B1")
                {
                    english = 1;
                }
                else if(listing.Rows[i].Cells[4].Value.ToString() == "B2")
                {
                    english = 2;
                }
                else if(listing.Rows[i].Cells[4].Value.ToString() == "C1")
                {
                    english = 3;
                }
                else
                {
                    english = 4;
                }
            }
            for (int i = 0; i < listing.RowCount - 1; i++)
            {
                if (listing.Rows[i].Cells[5].Value.ToString() == "University")
                {
                    coef = 1;
                }
                else
                {
                    coef = 2;
                }
            }
            int english_score = english * coef;
            double rating;
            uint index;
            for (int i = 0; i < listing.RowCount - 1; i++)
            {
                if(participant == listing.Rows[i].Cells[1].Value.ToString())
                {
                    listing.Rows[i].Cells[6].Value = publication_score;
                    listing.Rows[i].Cells[7].Value = competition_score;
                    rating = Convert.ToDouble(listing.Rows[i].Cells[3].Value.ToString()) * 0.1 + english_score + Convert.ToUInt32(listing.Rows[i].Cells[6].Value.ToString()) + Convert.ToUInt32(listing.Rows[i].Cells[7].Value.ToString());
                    listing.Rows[i].Cells[8].Value = rating;
                    index = Convert.ToUInt32(listing.Rows[i].Cells[0].Value.ToString());
                    string query = @"update App_Docs set publication_score ='" + publication_score + "', competition_score = '" + competition_score + "', rating = '"+rating+"' where id_student = '" +index+ "'";
                    using(SqlConnection connection = new SqlConnection(connectionString))
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

        private void tabControl1_Click(object sender, EventArgs e)
        {

        }

        private void result_Click(object sender, EventArgs e)
        {
            string query = "select Users.username, Exchange.program, App_Docs.rating from App_Docs" +
                            " inner join Users" +
                            " on App_Docs.id_student = Users.id" +
                            " inner join Exchange" +
                            " on App_Docs.id_program = Exchange.id";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            connection.Close();
        }
    }
}
