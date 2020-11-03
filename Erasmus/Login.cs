using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using Erasmus.DAO;
using System.Data.SqlClient;

namespace Erasmus
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        string connectionString = "Data Source =.\\SQLEXPRESS;Initial Catalog = Public; Integrated Security = True;";
        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(MessageBox.Show("Do you want to exit?","Warning",MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void entry_Click(object sender, EventArgs e)
        {
            string username = txtusername.Text;
            string password = txtpassword.Text;
            if (txtusername.Text == "")
            {
                MessageBox.Show("Немає логін", "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtusername.Focus();
                return;
            }
            if (txtpassword.Text == "")
            {
                MessageBox.Show("Немає пароль", "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtpassword.Focus();
                return;
            }
            try
            {
                CheckLogin(username, password);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public void CheckLogin(string username, string password)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand("select Users.id, Users.username, Users.userlogin, Users.user_year, Users.user_role, Faculty.faculty_name from Users " +
                                                     "inner join Faculty on Users.faculty_id = Faculty.id " +
                                                     "WHERE userlogin = @login AND user_password = @password", connection);
            SqlParameter uName = new SqlParameter("@login", SqlDbType.VarChar);
            SqlParameter uPassword = new SqlParameter("@password", SqlDbType.VarChar);
            uName.Value = username;
            uPassword.Value = password;

            sqlCommand.Parameters.Add(uName);
            sqlCommand.Parameters.Add(uPassword);

            sqlCommand.Connection.Open();

            string username1;
            string userfaculty;
            string userlogin;
            string user_year;
            string user_role;
            int user_id;

            SqlDataReader myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
            if (myReader.Read() == true)
            {
                user_role = myReader["user_role"].ToString();
                user_id = Convert.ToInt32(myReader["id"]);
                username1 = myReader["username"].ToString();
                userfaculty = myReader["faculty_name"].ToString();
                if(myReader["user_year"] == null)
                {
                    user_year = "0";
                }
                else
                {
                    user_year = myReader["user_year"].ToString();
                }
                Exchange exchange = new Exchange(user_id, username1, userfaculty, user_year, user_role);
                exchange.Show();
            }
            else
            {
                MessageBox.Show("Аккаунт не існує", "Повідомлення", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtusername.Clear();
                txtpassword.Clear();
            }
            if (connection.State == ConnectionState.Open)
            {
                connection.Dispose();
            }
        }


        private void Login_Load(object sender, EventArgs e)
        {
            txtpassword.PasswordChar = '*';
        }

        private void createAccount_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Registration registration = new Registration();
            registration.Show();
            this.Hide();
        }
    }
}
