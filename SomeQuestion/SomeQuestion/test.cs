using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace SomeQuestion
{
    class test
    {
        public int id { get; set; }
        public string name{ get; set; }
        public string addrress { get; set; }
        public int phonenum { get; set; }
        public int[] ratings = { 1, 2, 3, 4, 5 };
        public override string ToString()=> JsonSerializer.Serialize<test>(this);
    }
}
