using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Mysql
{
    internal class KatBuku
    {
        public string nama_kategori { get; set; }

        public string nama_penanggung_jawab { get; set; }

        public KatBuku(string nama_kategori, string nama_penanggung_jawab)
        {
            this.nama_kategori = nama_kategori;
            this.nama_penanggung_jawab = nama_penanggung_jawab;
        }
    }
}
