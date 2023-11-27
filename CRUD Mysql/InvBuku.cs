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
    public partial class InvBuku : Form
    {
        FormInvBuku form;

        public InvBuku()
        {
            InitializeComponent();
            form = new FormInvBuku(this);
        }

        public void Display()
        {
            DbPerpustakaan.DisplayAndSearch("SELECT id_buku, judul_buku, kategori_buku, penulis, penerbit, tahun_terbit FROM inv_buku", dataGridView1);
        }

        private void InvBuku_Shown(object sender, EventArgs e)
        {
            Display();
        }

        private void newKatBuku_Click(object sender, EventArgs e)
        {
            form.Clear();
            form.ShowDialog();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            HomePage hp = new HomePage();
            hp.ShowDialog();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            DbPerpustakaan.DisplayAndSearch("SELECT id_buku, judul_buku, kategori_buku, penulis, penerbit, tahun_terbit FROM inv_buku WHERE judul_buku LIKE '%" + txtSearch.Text + "%' OR kategori_buku LIKE '%" + txtSearch.Text + "%' OR penulis LIKE '%" + txtSearch.Text + "%' OR penerbit LIKE '%" + txtSearch.Text + "%' OR tahun_terbit LIKE '%" + txtSearch.Text + "%'", dataGridView1);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                // Edit
                form.Clear();
                form.id_buku = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                form.judul_buku = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                form.kategori_buku = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                form.penulis = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                form.penerbit = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                form.tahun_terbit = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();

                form.UpdateInfo();
                form.ShowDialog();
                return;
            }
            if (e.ColumnIndex == 1)
            {
                // Delete
                if (MessageBox.Show("Apakah anda yakin ingin menghapus data ini?", "Information", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    DbPerpustakaan.DeleteBuku(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
                    Display();
                }
                return;
            }
        }
    }
}
