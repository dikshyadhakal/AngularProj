using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.persistence.Context;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):DbContext(options)
{   
  public DbSet<User>Users { get; set; }
  public DbSet<Role> Roles { get; set; }

  public DbSet<UserRole> UserRoles { get; set; }

  public DbSet<Blog> Blogs { get; set; }
  public DbSet<Comment> Comments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}
