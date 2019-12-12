using CookiWebAppLesson.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookiWebAppLesson.DataAccess
{
    public class AuthContext : DbContext
    {
        public AuthContext(DbContextOptions options):base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User {
            Email = "admin@lol.com",
            Password ="123456"
            });

        }
    }
}
