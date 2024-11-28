using DemoEinfacherKalender.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DemoEinfacherKalender.Data
{
    public class CalendarContext : DbContext
    {
        public DbSet<CalendarEntry> CalendarEntries { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=CalendarDB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CalendarEntry>().Property(c => c.Title).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<CalendarEntry>().Property(c => c.Description).HasMaxLength(255);
        }
    }
}
