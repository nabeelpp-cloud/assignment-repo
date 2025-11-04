using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp_Entity
{
    public class BankingAppDbContext : DbContext
    {
        private readonly string _connectionString = "Data Source=localhost,1433;Initial Catalog=entityTesting;User ID=sa;Password=123456789aA;Trust Server Certificate=True";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        public DbSet<Customer> Customers {  get; set; }

    }
}
