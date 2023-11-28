using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace CRUD_Mysql
{
    public partial class Register : Form
    {
        MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");
        public Register()
        {
            InitializeComponent();
        }

        private void Register_Load(object sender, EventArgs e)
        {

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if(!this.regEmail.Text.Contains('@') && !this.regEmail.Text.Contains('.')) {
                MessageBox.Show("Masukkan Email dengan Benar!", "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(regPass.Text != confirmPass.Text)
            {
                MessageBox.Show("Password tidak sesuai", "Error");
                return;
            }

            if(string.IsNullOrEmpty(regUsername.Text) && string.IsNullOrEmpty(regEmail.Text) && string.IsNullOrEmpty(regNoTelp.Text) && string.IsNullOrEmpty(regPass.Text) && string.IsNullOrEmpty(confirmPass.Text))
            {
                MessageBox.Show("Harap isi semua kolom yang ada!", "Error");
                return;
            } else
            {
                conn.Open();
                MySqlCommand cmd1 = new MySqlCommand("SELECT * FROM manajemen_perpustakaan.user WHERE username = @UserName", conn),
                cmd2 = new MySqlCommand("SELECT * FROM manajemen_perpustakaan.user WHERE email = @UserEmail", conn);

                cmd1.Parameters.AddWithValue("@UserName", regUsername.Text);
                cmd2.Parameters.AddWithValue("@UserEmail", regEmail.Text);

                bool userExist = false, emailExist = false;

                using (var dr1 = cmd1.ExecuteReader())
                    if (userExist = dr1.HasRows) MessageBox.Show("Username sudah dipakai!");

                using (var dr2 = cmd2.ExecuteReader())
                    if (emailExist = dr2.HasRows) MessageBox.Show("Email sudah dipakai!");

                if(!(userExist || emailExist))
                {
                    string insert = "INSERT INTO manajemen_perpustakaan.user (id, username, email, no_telp, password) VALUES (NULL, '" + regUsername.Text + "', '"+ regEmail.Text + "', '"+ regNoTelp.Text + "', SHA2('"+ regPass.Text +"', 256))";

                    MySqlCommand insertData = new MySqlCommand(insert, conn);
                    insertData.CommandTimeout = 60;

                    try
                    {
                        MySqlDataReader myReader = insertData.ExecuteReader();
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    MessageBox.Show("Account Successfully Created!");
                }
                conn.Close();
            }

        }

        private void btnToLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            Info login = new Info();
            login.ShowDialog();
        }
    }
}
