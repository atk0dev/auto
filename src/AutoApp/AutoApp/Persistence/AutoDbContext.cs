using AutoApp.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoApp.Persistence
{
    public class AutoDbContext : DbContext
    {
        public DbSet<Make> Makes { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Vehicle> Vehicles {get; set;}

        public DbSet<Model> Models {get; set;}

        public AutoDbContext(DbContextOptions<AutoDbContext> options) : base(options)
        {            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VehicleFeature>().HasKey(vf => new { vf.FeatureId, vf.VehicleId });
        }
    }
}