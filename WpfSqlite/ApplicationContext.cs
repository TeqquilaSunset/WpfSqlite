using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace WpfSqlite
{
    internal class ApplicationContext : DbContext
    {
        public DbSet<Client> Clients { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=dbtest.db");
        }
    }
}
