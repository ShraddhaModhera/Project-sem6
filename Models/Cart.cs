using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EcommerceProject.Models
{
    public class Cart
    {
        public int Proid { get; set; }

        public string Pic { get; set; }

        public string Pname { get; set; }

        public int Qty { get; set; }

        public int Price { get; set; }

        public int Bill { get; set; }
    }
}