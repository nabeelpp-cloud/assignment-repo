using BankingConsoleApp_Entity_27_10_25.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingConsoleApp_Entity_27_10_25
{
    public class BankingAppDbContext : DbContext
    {
        private readonly string _connectionString = "Data Source=localhost,1433;Initial Catalog=bankingApp;User ID=sa;Password=123456789aA;Trust Server Certificate=True";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
        public DbSet<Customer> Customers {  get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Address> Address { get; set; }
    }
}
