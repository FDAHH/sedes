using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using sedes.Models;

namespace sedes.Data
{
    public class SedesContext : DbContext
    {
        public SedesContext(DbContextOptions<SedesContext> options)
            : base(options)
        {
        }
        public DbSet<Building> Building { get; set; }
        public DbSet<Room> Room { get; set; }

        public DbSet<Seat> Seat { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Room>()
                .HasIndex(u => u.Name)
                .IsUnique();
            modelBuilder.Entity<Building>()
                .HasIndex(u => u.Name)
                .IsUnique();
            modelBuilder.Entity<Seat>()
                .HasIndex(u => u.Name)
                .IsUnique();
            
            modelBuilder.Entity<Building>().HasMany(c => c.Rooms);
            modelBuilder.Entity<Room>().HasMany(c => c.Seats);
            modelBuilder.Entity<Building>().ToTable("Building");
            modelBuilder.Entity<Room>().ToTable("Room");
            modelBuilder.Entity<Seat>().ToTable("Seat");
        }
    }
}
