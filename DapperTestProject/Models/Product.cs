﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperTestProject.Models
{
    public class Product
    {
        public int id { get; set; }

        public string name { get; set; }

        public string description { get; set; }

        public int stockquantity { get; set; }

        public double price { get; set; }
    }
}
