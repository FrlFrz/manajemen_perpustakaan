using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Mysql
{
    internal class Inven
    {
        public string judul_buku { get; set; }

        public string kategori_buku { get; set; }
        
        public string penulis { get; set; }
        
        public string penerbit { get; set; }
        
        public string tahun_terbit { get; set; }

        public Inven(string judul_buku, string kategori_buku, string penulis, string penerbit, string tahun_terbit)
        {
            this.judul_buku = judul_buku;
            this.kategori_buku = kategori_buku;
            this.penulis = penulis;
            this.penerbit = penerbit;
            this.tahun_terbit = tahun_terbit;
        }
    }
}
