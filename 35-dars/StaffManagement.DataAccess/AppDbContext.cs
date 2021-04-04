using Microsoft.EntityFrameworkCore;
using StaffManagement.DataAccess.Models;
using StaffManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StaffManagement.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) 
            : base(options)
        {

        }

        public DbSet<Staff> Staffs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
        }
    }
}
