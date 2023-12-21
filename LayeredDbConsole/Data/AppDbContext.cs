using LayeredDbConsole.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayeredDbConsole.Data
{
    public class AppDbContext: DbContext 
    {
        private string _connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=LayeredDb;Integrated Security=True;TrustServerCertificate=True;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        public DbSet<Vehicle> Vehicles { get; set; } = null!;
        public DbSet<Lease> Leases { get; set; } = null!;
        public DbSet<Customer> Customers { get; set; } = null!;
    }
}
