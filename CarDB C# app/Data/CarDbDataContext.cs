using CarDB.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDB.Data
{
    internal class CarDbDataContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql(
                    "server=localhost;" +
                    "port=3306;" +
                    "user=dev;" +
                    "password=dev;" +
                    "database=csd_iv_CarDb_v1_0_0;"
                    , Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.17-mariadb")
                );
            }
        }
    }
}
