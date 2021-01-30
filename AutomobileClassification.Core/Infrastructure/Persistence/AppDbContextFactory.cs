using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomobileClassification.Core.Infrastructure.Persistence
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var serverVersion = new Version(10,1,47);
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            var cs = "server=localhost;user=admin;password=admin;database=automobile_classification;CharSet=utf8;";
            optionsBuilder.UseMySql(cs, new MySqlServerVersion (serverVersion));
            return new AppDbContext(optionsBuilder.Options);
        }



    }
}