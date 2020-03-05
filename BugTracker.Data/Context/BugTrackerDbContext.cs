using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BugTracker.Data.Entities;

namespace BugTracker.Web.Data
{
    public class BugTrackerDbContext : IdentityDbContext
    {
        public BugTrackerDbContext(DbContextOptions<BugTrackerDbContext> options)
            : base(options)
        {
        }
        public DbSet<Bug> Bugs { get; set; }
        public DbSet<Status> Status { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Status>().HasData(
              new Status { Id = 1, Description = "Open" },
              new Status { Id = 2, Description = "Close" }
            );
        }
    }
}
