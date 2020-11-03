using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
//using Erasmus.DAO;

namespace Erasmus
{
    public partial class Exchange : Form
    {
        static string connectionString = "Data Source =.\\SQLEXPRESS;Initial Catalog = Public; Integrated Security = True;";
        SqlConnection connection = new SqlConnection(connectionString);
        string faculty;
        string username;
        string year;
        string role;
        int id;
        public Exchange(int id, string username, string faculty, string year, string role)
        {
            InitializeComponent();
            this.faculty = faculty;
            this.username = username;
            this.year = year;
            this.role = role;
            this.id = id;
        }

        private void аккаунтToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (role == "Студент")
            {
                User_Form user = new User_Form(id, username, faculty, year, role);
                user.Show();
            }
            else if(role == "Працівник відділу")
            {
                Employee employ = new Employee(id, username, role);
                employ.Show();
            }
            else if (role == "Координатор" || role == "Завідувач факультету/кафедри")
            {
                Professor pro = new Professor(id, username,faculty,role);
                pro.Show();
            }
            
        }

        private void проАвторуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.Show();
        }

        private void вихідToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to exit?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == System.Windows.Forms.DialogResult.Yes){
                this.Close();
            }
        }

        private void Exchange_Load(object sender, EventArgs e)
        {
            
            string query = "select Exchange.id, Exchange.program, Exchange.country from Exchange";

            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(dt);
            list.DataSource = dt;
            int rowCount = (list.RowCount-1);
            for(int i = 0; i < rowCount; i++)
            {
                string item = list.Rows[i].Cells[1].Value.ToString();
                list_partner.Items.Add(item);
            }

            connection.Close();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                string query = "select Exchange.id, Exchange.program, Exchange.country, Faculty.faculty_name, Exchange.program_year" +
                            " from Exchange" +
                            " inner join Faculty" +
                            " on Exchange.faculty_id = Faculty.id " +
                            "where faculty_name = '" + faculty + "'";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dt);
                list.DataSource = dt;
                connection.Close();
            }
            else
            {
                string query = "select Exchange.id, Exchange.program, Exchange.country, Faculty.faculty_name, Exchange.program_year" +
                            " from Exchange" +
                            " inner join Faculty" +
                            " on Exchange.faculty_id = Faculty.id " +
                            "where faculty_name = '" + faculty + "'";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dt);
                list.DataSource = dt;
                connection.Close();
            }
        }

        private void search_Click(object sender, EventArgs e)
        {
            string[] description = new string[list.RowCount - 1];
            description[0] = @".\description\lodz.txt";
            description[1] = @".\description\vilnius.txt";
            description[2] = @".\description\dresden.txt";
            description[3] = @".\description\jena.txt";
            description[4] = @".\description\reutlingen.txt";
            int index = list_partner.Items.IndexOf(list_partner.Text);
            string str = File.ReadAllText(description[index]);
            desc.ScrollToCaret();
            desc.Text = str;
        }

        private void документиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Document doc = new Document();
            doc.Show();
        }
    }
}
