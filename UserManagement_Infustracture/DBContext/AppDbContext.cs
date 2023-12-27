using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement_Domain.Entities;

namespace UserManagement_Infustracture.DBContext
{
    public class AppDbContext:DbContext
    {
      
            public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
            {

            }


            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                if (!optionsBuilder.IsConfigured)
                {
                var connection = "DefaultConnectionString"; // Replace with your actual connection string
                optionsBuilder.UseSqlServer(connection, b => b.MigrationsAssembly("UserManagement_WebApi"));
                }
            }

            public DbSet<User>? Users { get; set; }
            public DbSet<Role>? Roles { get; set; }
            public DbSet<UserRole>? UserRoles { get; set; }
            public DbSet<Group>? Groups { get; set; }
            public DbSet<UserGroup>? UserGroups { get; set; }
            public DbSet<Permission>? Permissions { get; set; }
            public DbSet<PermissionRole>? PermissionRoles { get; set; }
    }
}
