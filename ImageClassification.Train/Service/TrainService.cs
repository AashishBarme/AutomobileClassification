using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using AutomobileClassification.Core.Infrastructure.Persistence;
using AutomobileClassification.Core.Application.Common.Helpers;
using AutomobileClassification.Core.Domain.Entities;

namespace ImageClassification.Train.Service
{
    public class TrainService
    {
        protected readonly AppDbContext _context;


        public TrainService()
        {
            //_context = CreateDbContext();
        }

        protected IConfigurationRoot GetConfiguration()
        {
            var configurationBuilder = new ConfigurationBuilder();
            //Add default configuration fille
        //    configurationBuilder.AddJsonFile("appsettings.json", optional: false);
            var configuration = configurationBuilder.Build();
            return configuration;
        }
        public AppDbContext CreateDbContext()
        {
            // Configuring services so we can mak e use of it
            //var configurationBuilder = new ConfigurationBuilder();
            ////Add default configuration fille
            //configurationBuilder.AddJsonFile("appsettings.json", optional: false);
            //var configuration = configurationBuilder.Build();
            var configuration = GetConfiguration();

            var serverVersion = new Version(10,1,47);
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            var cs = "server=localhost;user=admin;password=admin;database=automobile_classification;CharSet=utf8;";
            optionsBuilder.UseMySql(cs, new MySqlServerVersion (serverVersion));
            return new AppDbContext(optionsBuilder.Options);

        }

        public void RunMigration()
        {
            var context = CreateDbContext();
            context.Database.Migrate();
        }

        public  int AddCategories(string title)
        {
            using var context = CreateDbContext();
            var url = SlugHelper.Create(true, title); 
            if(context.Categories.Any(e => e.Slug == url))
            {
                return 0;
            }

            Category category = new Category
            {
                Title = title,
                Slug = url
            };
            context.Add(category);
            return  context.SaveChanges();
        }


    }
}