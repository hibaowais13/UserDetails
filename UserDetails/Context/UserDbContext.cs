using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.Entity;
using UserDetails.Models;



namespace UserDetails.Context
{
    public class UserDbContext : DbContext
          
    {
        public UserDbContext() : base("DefaultConnection") {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<UserDbContext, UserDetails.Migrations.Configuration>());

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role>Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}

