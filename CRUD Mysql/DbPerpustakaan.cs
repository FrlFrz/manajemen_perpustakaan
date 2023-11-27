using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ComboBox = System.Windows.Forms.ComboBox;

namespace CRUD_Mysql
{
    internal class DbPerpustakaan
    {
        public static MySqlConnection GetConnection()
        {
            string sql = "datasource=localhost;port=3306;username=root;password=;database=manajemen_perpustakaan";
            MySqlConnection conn = new MySqlConnection(sql);

            try
            {
                conn.Open();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("MySql Connection! \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return conn;
        }

        public static void AddKategori(KatBuku std)
        {
            string sql = "INSERT INTO kategori_buku VALUES (NULL, @NamaKategori, @NamaPenanggungJawab)";
            MySqlConnection conn = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@NamaKategori", MySqlDbType.VarChar).Value = std.nama_kategori;
            cmd.Parameters.Add("@NamaPenanggungJawab", MySqlDbType.VarChar).Value = std.nama_penanggung_jawab;
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Berhasil Menambah Data", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Kategori tidak Dimasukkan \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conn.Close();
        }

        public static void UpdateKategori(KatBuku std, string id)
        {
            string sql = "UPDATE kategori_buku SET nama_kategori = @NamaKategori, nama_penanggung_jawab = @NamaPenanggungJawab WHERE id_kategori = @KategoriID";
            MySqlConnection conn = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@KategoriID", MySqlDbType.VarChar).Value = id;
            cmd.Parameters.Add("@NamaKategori", MySqlDbType.VarChar).Value = std.nama_kategori;
            cmd.Parameters.Add("@NamaPenanggungJawab", MySqlDbType.VarChar).Value = std.nama_penanggung_jawab;
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Update Berhasil", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update Gagal \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conn.Close();
        }

        public static void DeleteKategori(string id)
        {
            string sql = "DELETE FROM kategori_buku WHERE id_kategori = @KategoriID";
            MySqlConnection conn = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@KategoriID", MySqlDbType.VarChar).Value = id;
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Berhasil menghapus data", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menghapus data! \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conn.Close();
        }

        public static void AddPegawai(PegawaiPerp std)
        {
            string sql = "INSERT INTO pegawai VALUES (NULL, @Nama, @Alamat, @TanggalLahir, @NoTelp)";
            MySqlConnection conn = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@Nama", MySqlDbType.VarChar).Value = std.nama;
            cmd.Parameters.Add("@Alamat", MySqlDbType.VarChar).Value = std.alamat;
            cmd.Parameters.Add("@TanggalLahir", MySqlDbType.Date).Value = std.tanggal_lahir;
            cmd.Parameters.Add("@NoTelp", MySqlDbType.VarChar).Value = std.no_telp;
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Berhasil Menambah Data", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kategori tidak Dimasukkan \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conn.Close();
        }

        public static void UpdatePegawai(PegawaiPerp std, string id)
        {
            string sql = "UPDATE pegawai SET nama = @NamaPegawai, alamat = @Alamat, tanggal_lahir = @TanggalLahir, no_telp = @NoTelp WHERE id_pegawai = @PegawaiID";
            MySqlConnection conn = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@PegawaiID", MySqlDbType.VarChar).Value = id;
            cmd.Parameters.Add("@NamaPegawai", MySqlDbType.VarChar).Value = std.nama;
            cmd.Parameters.Add("@Alamat", MySqlDbType.VarChar).Value = std.alamat;
            cmd.Parameters.Add("@TanggalLahir", MySqlDbType.Date).Value = std.tanggal_lahir;
            cmd.Parameters.Add("@NoTelp", MySqlDbType.VarChar).Value = std.no_telp;
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Update Berhasil", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update Gagal \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conn.Close();
        }

        public static void DeletePegawai(string id)
        {
            string sql = "DELETE FROM pegawai WHERE id_pegawai = @PegawaiID";
            MySqlConnection conn = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@PegawaiID", MySqlDbType.VarChar).Value = id;
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Berhasil menghapus data", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menghapus data! \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conn.Close();
        }

        public static void AddBuku(Inven std)
        {
            string sql = "INSERT INTO inv_buku VALUES (NULL, @JudulBuku, @KategoriBuku, @Penulis, @Penerbit, @Tahunterbit)";
            MySqlConnection conn = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@JudulBuku", MySqlDbType.VarChar).Value = std.judul_buku;
            cmd.Parameters.Add("@KategoriBuku", MySqlDbType.VarChar).Value = std.kategori_buku;
            cmd.Parameters.Add("@Penulis", MySqlDbType.VarChar).Value = std.penulis;
            cmd.Parameters.Add("@Penerbit", MySqlDbType.VarChar).Value = std.penerbit;
            cmd.Parameters.Add("@TahunTerbit", MySqlDbType.VarChar).Value = std.tahun_terbit;
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Berhasil Menambah Data", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kategori tidak Dimasukkan \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conn.Close();
        }

        public static void UpdateBuku(Inven std, string id)
        {
            string sql = "UPDATE inv_buku SET judul_buku = @JudulBuku, kategori_buku = @KategoriBuku, penulis = @Penulis, penerbit = @Penerbit, tahun_terbit = @TahunTerbit WHERE id_buku = @BukuID";
            MySqlConnection conn = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@BukuID", MySqlDbType.VarChar).Value = id;
            cmd.Parameters.Add("@JudulBuku", MySqlDbType.VarChar).Value = std.judul_buku;
            cmd.Parameters.Add("@KategoriBuku", MySqlDbType.VarChar).Value = std.kategori_buku;
            cmd.Parameters.Add("@Penulis", MySqlDbType.VarChar).Value = std.penulis;
            cmd.Parameters.Add("@Penerbit", MySqlDbType.VarChar).Value = std.penerbit;
            cmd.Parameters.Add("@TahunTerbit", MySqlDbType.VarChar).Value = std.tahun_terbit;
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Update Berhasil", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update Gagal \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conn.Close();
        }

        public static void DeleteBuku(string id)
        {
            string sql = "DELETE FROM inv_buku WHERE id_buku = @BukuID";
            MySqlConnection conn = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@BukuID", MySqlDbType.VarChar).Value = id;
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Berhasil menghapus data", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menghapus data! \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conn.Close();
        }

        public static void DisplayAndSearch(string query, DataGridView dgv)
        {
            string sql = query;
            MySqlConnection conn = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataAdapter adp =  new MySqlDataAdapter(cmd);
            DataTable tbl = new DataTable();
            adp.Fill(tbl);
            dgv.DataSource = tbl;
            conn.Close();
        }

        public static void LoadComboBox(string query, string namaTabel, string displayItem, ComboBox cmb)
        {
            string sql = query;
            MySqlConnection conn = GetConnection();

            MySqlDataAdapter adp = new MySqlDataAdapter(sql, conn);
            DataSet dataSet = new DataSet();
            adp.Fill(dataSet, namaTabel);
            cmb.DisplayMember = displayItem;
            cmb.ValueMember = displayItem;
            cmb.DataSource = dataSet.Tables[namaTabel];

            conn.Close();
        }
    }
}
