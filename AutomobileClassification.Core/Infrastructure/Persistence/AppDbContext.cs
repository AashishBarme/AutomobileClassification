using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Reflection;
using System.Threading.Tasks;
using AutomobileClassification.Core.Domain.Entities;

namespace AutomobileClassification.Core.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<Category> Categories {get; set;}
        public DbSet<Model> Models {get; set;}
        public DbSet<Post> Posts {get; set;}
        public DbSet<PostComment> PostComments {get; set;}
        public DbSet<PostImage> PostImages {get; set;}
        public DbSet<PostLike> PostLikes {get; set;} 
        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}