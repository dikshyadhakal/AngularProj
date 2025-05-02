using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infrastructure.persistence.Context;

public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
       var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
       optionBuilder.UseSqlServer("Server=.; Database=BlogDB;Trusted_Connection=True;TrustServerCertificate=True;");
       return new ApplicationDbContext(optionBuilder.Options);
    }
}
