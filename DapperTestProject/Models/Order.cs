using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperTestProject.Models
{
    public class Order
    {
        public int id { get; set; }

        public int customerid { get; set; }

        public int productid { get; set; }

        public int quantity { get; set; }
    }
}
