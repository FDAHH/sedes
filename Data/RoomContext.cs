using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using sedes.Models;

namespace sedes.Data
{
    public class RoomContext : DbContext
    {
        public RoomContext (DbContextOptions<RoomContext> options)
            : base(options)
        {
        }

        public DbSet<sedes.Models.Room> Room { get; set; }

        public DbSet<sedes.Models.Seat> Seats { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Room>().ToTable("Room");
            modelBuilder.Entity<Enrollment>().ToTable("Enrollment");
            modelBuilder.Entity<Seat>().ToTable("Seat");
        }
    }
}
