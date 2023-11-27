using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD_Mysql
{
    public partial class FormInvBuku : Form
    {
        private readonly InvBuku _parent;
        public string id_buku, judul_buku, kategori_buku, penulis, penerbit, tahun_terbit;

        public FormInvBuku(InvBuku parent)
        {
            InitializeComponent();
            _parent = parent;
        }
        public void UpdateInfo()
        {
            judulForm.Text = "Update Data Buku";
            btnCreateKat.Text = "Update";
            txtJudulBuku.Text = judul_buku;
            txtPenulis.Text = penulis;
            txtPenerbit.Text = penerbit;
            txtTahunTerbit.Text = tahun_terbit;
        }
        private void FormInvBuku_Load(object sender, EventArgs e)
        {
            DbPerpustakaan.LoadComboBox("SELECT * FROM kategori_buku", "kategori_buku", "nama_kategori", cmbKategoriBuku);
            cmbKategoriBuku.Text = kategori_buku;
        }

        public void Clear()
        {
            txtJudulBuku.Text = cmbKategoriBuku.Text = txtPenulis.Text = txtPenerbit.Text = txtTahunTerbit.Text = string.Empty;
            judulForm.Text = "Tambah Data Buku";
            btnCreateKat.Text = "Simpan";
            cmbKategoriBuku.Text = "";
        }

        private void btnCreateKat_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtJudulBuku.Text) || string.IsNullOrEmpty(cmbKategoriBuku.Text) || string.IsNullOrEmpty(txtPenulis.Text) || string.IsNullOrEmpty(txtPenerbit.Text) || string.IsNullOrEmpty(txtTahunTerbit.Text))
            {
                MessageBox.Show("Isi semua kolom dengan benar!");
                return;
            }

            if (btnCreateKat.Text == "Simpan")
            {
                Inven std = new Inven(txtJudulBuku.Text.Trim(), cmbKategoriBuku.Text.Trim(), txtPenulis.Text.Trim(), txtPenerbit.Text.Trim(), txtTahunTerbit.Text.Trim());
                DbPerpustakaan.AddBuku(std);
                Clear();
            }
            if (btnCreateKat.Text == "Update")
            {
                Inven std = new Inven(txtJudulBuku.Text.Trim(), cmbKategoriBuku.Text.Trim(), txtPenulis.Text.Trim(), txtPenerbit.Text.Trim(), txtTahunTerbit.Text.Trim());
                DbPerpustakaan.UpdateBuku(std, id_buku);
            }
            _parent.Display();
        }
    }
}
