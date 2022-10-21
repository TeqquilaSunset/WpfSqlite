using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

namespace WpfSqlite
{
    internal class Storage
    {
        public long Id { get; set; }
        public string? Adress { get; set; }
        public long? Area { get; set; }
    }
}
