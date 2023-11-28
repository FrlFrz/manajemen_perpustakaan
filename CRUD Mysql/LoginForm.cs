using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace CRUD_Mysql
{
    public partial class Info : Form
    {
        MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");
        MySqlCommand cmd;
        MySqlDataReader mdr;
        public Info()
        {
            InitializeComponent();
        }

        private void btnToRegister_Click(object sender, EventArgs e)
        {
            this.Hide();
            Register regform = new Register();
            regform.ShowDialog();
        }

        private void Info_Load(object sender, EventArgs e)
        {

        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(inputUsername.Text) || string.IsNullOrEmpty(inputPassword.Text))
            {
                MessageBox.Show("Isi Kolom Username dan Password!");
            }
            else
            {
                using (MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root;password="))
                {
                    conn.Open();

                    string selectQuery = "SELECT * FROM manajemen_perpustakaan.user WHERE Username = @Username AND Password = SHA2(@Password, 256)";
                    using (MySqlCommand selectCmd = new MySqlCommand(selectQuery, conn))
                    {
                        selectCmd.Parameters.AddWithValue("@Username", inputUsername.Text);
                        selectCmd.Parameters.AddWithValue("@Password", inputPassword.Text);

                        using (MySqlDataReader mdr = selectCmd.ExecuteReader())
                        {
                            if (mdr.Read())
                            {
                                mdr.Close();
                                string updateQuery = "UPDATE manajemen_perpustakaan.user SET lastlogin = @LastLogin WHERE username = @Username";
                                using (MySqlCommand updateCmd = new MySqlCommand(updateQuery, conn))
                                {
                                    updateCmd.Parameters.AddWithValue("@LastLogin", DateTime.Now);
                                    updateCmd.Parameters.AddWithValue("@Username", inputUsername.Text);
                                    updateCmd.ExecuteNonQuery();
                                }

                                MessageBox.Show("Login Berhasil!");
                                this.Hide();

                                // Ambil username pengguna
                                FileStream fs = new FileStream("nama.txt", FileMode.Create);
                                BinaryFormatter bf = new BinaryFormatter();
                                bf.Serialize(fs, inputUsername.Text);
                                fs.Close();

                                HomePage homePage = new HomePage();
                                homePage.Show();
                            }
                            else
                            {
                                MessageBox.Show("Password atau Username salah! Coba lagi");
                            }
                        }
                    }
                }
            }
        }
    }
}
