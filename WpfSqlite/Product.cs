using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfSqlite
{
    internal class Product
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public long? Quantity { get; set; }

        public Storage? Storage { get; set; }
    }
}
