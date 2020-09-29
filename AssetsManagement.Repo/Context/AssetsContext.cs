using AssetsManagement.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetsManagement.Repo.Context
{
    public class AssetsContext : DbContext
    {
        public AssetsContext(DbContextOptions<AssetsContext> options) : base(options) { }
        public DbSet<Assets> Assets { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Assets>().HasIndex(x => x.AssetNumber).IsUnique(true);
            modelBuilder.Entity<Brand>().HasIndex(x => x.Name).IsUnique(true);
            modelBuilder.Entity<User>().HasIndex(x => x.Email).IsUnique(true);
        }
    }
}
