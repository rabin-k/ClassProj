using ClassProj.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassProj.Data
{
    public class ClassDbContext : DbContext
    {
        public ClassDbContext(DbContextOptions<ClassDbContext> options) : base(options)
        {

        }
        public DbSet<College> College { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<College>().ToTable("College");
        }
    }
}
