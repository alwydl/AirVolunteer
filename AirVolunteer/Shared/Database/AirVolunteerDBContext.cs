using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Shared.Models;
using Microsoft.Extensions.Options;
using MySql.EntityFrameworkCore;

namespace Shared.Database
{
    internal class AirVolunteerDBContext : DbContext
    {
        public virtual DbSet<PilotMOD> Pilots { get; set; }
        public virtual DbSet<FlightMOD> Flights { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfiguration configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();


            string connectionString = configuration.GetConnectionString("DefaultConnection"); // Replace "DefaultConnection" with your actual connection string name
            optionsBuilder.UseMySQL(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FlightMOD>()
                .HasIndex(d => new { d.PilotId })
                .IsUnique(true);

        }
    }
}
