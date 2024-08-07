using Microsoft.EntityFrameworkCore;
using CDNFreelancers.Models;
using System.Collections.Generic;

namespace CDNFreelancers.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}