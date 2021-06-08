using DevFitness.API.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevFitness.API.Persistencia
{
    public class DevFitnessDbContext : DbContext
    {
        /*Construtor - Atalho criar contrutor CTOR*/
        public DevFitnessDbContext(DbContextOptions<DevFitnessDbContext> options) : base()
        {                
        }

        /*Tabelas*/
        public DbSet<User> Users { get; set; }
        public DbSet<Meal> Meals { get; set; }

        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-1OGBH22\SQLEXPRESS;Database=DevFitness;User ID=sa;Password=123456");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(e =>
            {
                e.HasKey(u => u.Id);
                e.HasMany(u => u.Meals)
                    .WithOne()
                    .HasForeignKey(m => m.UserId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Meal>(e =>
            {
                e.HasKey(m => m.Id);
            });

        }
    }
}
