using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CRUD_Mysql
{
    
    public partial class AddKategoriBuku : Form
    {
        private readonly KategoriBuku _parent;
        public string id_kategori, nama_kategori, nama_penanggung_jawab;

        public AddKategoriBuku(KategoriBuku parent)
        {
            InitializeComponent();
            _parent = parent;
        }

        private void AddKategoriBuku_Load(object sender, EventArgs e)
        {
            DbPerpustakaan.LoadComboBox("SELECT * FROM pegawai", "pegawai", "nama", cmbPenanggungJawab);
            UpdateInfo();

            int itemCount = cmbPenanggungJawab.Items.Count;
            MessageBox.Show("Jumlah item dalam ComboBox: " + itemCount.ToString());

        }

        public void UpdateInfo()
        {
            judulForm.Text = "Update Kategori";
            btnCreateKat.Text = "Update";
            txtNamaKat.Text = nama_kategori;
            cmbPenanggungJawab.Text = nama_penanggung_jawab;
        }

        private void AddKategoriBuku_Shown(object sender, EventArgs e)
        {
        }

        public void Clear()
        {
            txtNamaKat.Text = string.Empty;
        }

        private void btnCreateKat_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtNamaKat.Text) || string.IsNullOrEmpty(cmbPenanggungJawab.Text))
            {
                MessageBox.Show("Isi semua kolom dengan benar!");
                return;
            }

            if (btnCreateKat.Text == "Simpan")
            {
                KatBuku std = new KatBuku(txtNamaKat.Text.Trim(), cmbPenanggungJawab.Text.Trim());
                DbPerpustakaan.AddKategori(std);
                Clear();
            }
            if (btnCreateKat.Text == "Update")
            {
                KatBuku std = new KatBuku(txtNamaKat.Text.Trim(), cmbPenanggungJawab.Text.Trim());
                DbPerpustakaan.UpdateKategori(std, id_kategori);
            }
            // CheckSelectedValue();
            _parent.Display();
        }
    }
}
