using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WpfSqlite
{
    internal class Sale
    {
        public long Id { get; set; }
        public string? Date { get; set; }

        public  Client? Client { get; set;} 
        public  Staff? Staff { get; set; }
        public  Product? Product { get; set; }

        
    }
}
