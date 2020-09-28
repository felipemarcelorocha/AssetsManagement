using AssetsManagement.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetsManagement.Repo
{
    public class AssetsContext : DbContext
    {
        public AssetsContext(DbContextOptions<AssetsContext> options) : base(options) { }
        public DbSet<Assets> Assets { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
