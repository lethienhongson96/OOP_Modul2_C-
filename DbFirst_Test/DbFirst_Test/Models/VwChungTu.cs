using System;
using System.Collections.Generic;

namespace DbFirst_Test.Models
{
    public partial class VwChungTu
    {
        public int Sochungtu { get; set; }
        public DateTime Ngaylap { get; set; }
        public string Tenkhachhang { get; set; }
        public string Diachikhachhang { get; set; }
        public int Mahang { get; set; }
        public int Soluong { get; set; }
        public decimal Dongia { get; set; }
    }
}
