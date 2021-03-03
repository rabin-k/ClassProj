using ClassProj.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace ClassProj.Data
{
    public class ClassDbContext : IdentityDbContext
    {
        public ClassDbContext(DbContextOptions<ClassDbContext> options) : base(options)
        {

        }
        public DbSet<College> College { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<College>().ToTable("College");
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole { Name = "Admin" },
                new IdentityRole { Name = "Student" }
                );
        }
    }
}
