using System;
using System.Collections.Generic;

namespace DbFirst_Test.Models
{
    public partial class Mathang
    {
        public Mathang()
        {
            Chungtu = new HashSet<Chungtu>();
        }

        public int Mahang { get; set; }
        public string Tenhang { get; set; }
        public string Chitietmathang { get; set; }
        public decimal Giaban { get; set; }
        public int Soluong { get; set; }

        public virtual ICollection<Chungtu> Chungtu { get; set; }
    }
}
