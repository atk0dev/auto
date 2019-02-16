using AutoApp.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoApp.Persistence
{
    public class AutoDbContext : DbContext
    {
        public AutoDbContext(DbContextOptions<AutoDbContext> options) : base(options)
        {            
        }

        public DbSet<Make> Makes { get; set; }
        public DbSet<Feature> Features { get; set; }
    }
}