using System;
using System.Collections.Generic;
using System.Text;

namespace MyLibrary1.Entity
{
    public class Category
    {
        public int id { get; set; }
        public string name { get; set; }

        public List<Product> Products { get; set; }
    }
}
